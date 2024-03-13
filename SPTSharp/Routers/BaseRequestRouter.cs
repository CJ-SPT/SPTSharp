using NetCoreServer;
using SPTSharp.Helpers;

namespace SPTSharp.Routers
{
    public static class BaseRequestRouter
    {
        private static readonly Dictionary<string, Action<HttpSession, HttpRequest, HttpResponse, string>> _getRoutes =
            new Dictionary<string, Action<HttpSession, HttpRequest, HttpResponse, string>>
            {
                { "/launcher/server/connect",                   LauncherRouter.HandleConnect                },
                { "/launcher/ping" ,                            LauncherRouter.HandlePing                   },
                { "/launcher/server/version",                   LauncherRouter.HandleVersion                },
                { "/launcher/profiles",                         LauncherRouter.HandleGetAllMiniProfiles     },
                { "/launcher/server/loadedServerMods",          LauncherRouter.HandleGetLoadedServerMods    },
                { "/launcher/server/serverModsUsedByProfile",   LauncherRouter.HandleGetModsUsedByProfile   }
            };

        private static readonly Dictionary<string, Action<HttpSession, HttpRequest, HttpResponse, string>> _postRoutes =
            new Dictionary<string, Action<HttpSession, HttpRequest, HttpResponse, string>>
            {
                { "/launcher/profile/login",    LauncherRouter.HandleLogin              },
                { "/launcher/profile/register", LauncherRouter.HandleRegister           },
                { "/launcher/profile/get",      LauncherRouter.HandleGetProfile         },
                { "/launcher/profile/info",     LauncherRouter.HandleGetProfileInfo     },
                { "/launcher/profile/remove",   LauncherRouter.HandleRemoveProfile      }
            };

        public static void RouteRequest(HttpSession session, HttpRequest request, HttpResponse response)
        {
            var url = request.Url;

            // Extract the SessionID from the header
            var cookies = GetCookies(request);
            string sessionID = string.Empty;
            
            foreach (var cookie in cookies)
            {
                if (cookie.Value.Contains("PHPSESSID")) 
                {
                    sessionID = cookie.Value.Split("=")[1];
                }
            }

            // Handle GET routes
            if (_getRoutes.TryGetValue(url, out var getHandler))
            {
                getHandler.Invoke(session, request, response, sessionID);
                return;
            }

            // Handle image routes
            if (url.EndsWith(".png") || url.EndsWith(".jpg"))
            {
                RouteImages(session, request, response);
                return;
            }

            // handle POST routes
            if (_postRoutes.TryGetValue(url, out var postHandler))
            {
                postHandler.Invoke(session, request, response, sessionID);
                return;
            }

            Logger.LogError($"UNHANDLED: {url}");
        }

        public static void RouteImages(HttpSession session, HttpRequest request, HttpResponse response)
        {
            var url = request.Url;

            if (url.EndsWith(".png") || url.EndsWith(".jgp"))
            {
                ImageRouter.SendImage(session, request, response);
            }
        }

        // Build a dictionary of cookies for the request
        private static Dictionary<string, string> GetCookies(HttpRequest request)
        {
            var headerCount = request.Headers;
            Dictionary<string, string> cookies = new Dictionary<string, string>();

            for (int i = 0; i < headerCount; i++)
            {
                cookies[request.Header(i).Item1] = request.Header(i).Item2;
                Logger.LogDebug($"\nCookie {i}\nKey: {request.Header(i).Item1}\nValue: {request.Header(i).Item2}\n");
            }

            return cookies;
        }
    }
}

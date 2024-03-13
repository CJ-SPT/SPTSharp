using NetCoreServer;
using SPTSharp.Helpers;

namespace SPTSharp.Routers
{
    public static class BaseRequestRouter
    {
        private static readonly Dictionary<string, Action<HttpSession, HttpRequest, HttpResponse>> _getRoutes =
            new Dictionary<string, Action<HttpSession, HttpRequest, HttpResponse>>
            {
                { "/launcher/server/connect",   LauncherRouter.HandleConnect },
                { "/launcher/ping" ,            LauncherRouter.HandlePing },
                { "/launcher/server/version",   LauncherRouter.HandleVersion },
                { "/launcher/profiles",         ProfileRouter.HandleGetAllMiniProfiles }  
            };

        private static readonly Dictionary<string, Action<HttpSession, HttpRequest, HttpResponse>> _postRoutes =
            new Dictionary<string, Action<HttpSession, HttpRequest, HttpResponse>>
            {
                { "/launcher/profile/login",    LauncherRouter.HandleLogin  },
                { "/launcher/profile/register", LauncherRouter.HandleRegister}
            };

        public static void RouteRequest(HttpSession session, HttpRequest request, HttpResponse response)
        {
            var url = request.Url;

            // Handle GET routes
            if (_getRoutes.TryGetValue(url, out var getHandler))
            {
                getHandler.Invoke(session, request, response);
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
                postHandler.Invoke(session, request, response);
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
    }
}

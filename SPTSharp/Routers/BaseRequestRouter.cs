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
                { "/launcher/server/version",   LauncherRouter.HandleVersion }
            };

        public static void RouteRequest(HttpSession session, HttpRequest request, HttpResponse response)
        {
            var url = request.Url;

            // Handle get routes
            if (_getRoutes.TryGetValue(url, out var handler))
            {
                handler.Invoke(session, request, response);
                return;
            }

            Logger.LogError($"UNHANDLED: {url}");
        }

        public static void RouteFiles(HttpSession session, HttpRequest request, HttpResponse response)
        {
            var url = request.Url;

            if (url.EndsWith(".png") || url.EndsWith(".jgp"))
            {
                ImageRouter.SendImage(session, request, response);
            }
        }
    }
}

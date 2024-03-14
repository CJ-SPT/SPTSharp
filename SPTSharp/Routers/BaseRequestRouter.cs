﻿using NetCoreServer;
using SPTSharp.CallBacks;
using SPTSharp.Helpers;

namespace SPTSharp.Routers
{
    internal static partial class BaseRequestRouter
    {
        public static string sessionID = string.Empty;

        public static void RouteRequest(HttpSession session, HttpRequest request, HttpResponse response)
        {
            var url = request.Url;

            // Extract the SessionID from the header
            var cookies = GetCookies(request);
            
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

            if (RouteDynamic(session, request, response, sessionID))
            {
                return;
            }

            Logger.LogError($"UNHANDLED: {url}");
        }

        public static void CompressAndSend(HttpSession session, HttpRequest request, HttpResponse response, string content)
        {
            Logger.LogDebug($"Response: \n{content}\n");
            byte[] bytes = HttpServerHelper.CompressStringZlib(content);
            var resp = response.MakeGetResponse(bytes);

            

            session.SendResponseAsync(resp);
        }

        private static bool RouteDynamic(HttpSession session, HttpRequest request, HttpResponse response, string SessionID)
        {
            var url = request.Url;

            var routeKey = _dynamicRoutes.Keys
                .FirstOrDefault(key => url.Contains(key, StringComparison.OrdinalIgnoreCase));

            if (routeKey == null)
            {
                return false;
            }

            if (routeKey.Any())
            {
                _dynamicRoutes[routeKey].Invoke(session, request, response, sessionID);
                return true;
            }

            return false;
        }

        private static void RouteImages(HttpSession session, HttpRequest request, HttpResponse response)
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
            }

            return cookies;
        }
    }
}

using SPTSharp.CallBacks;
using SPTSharp.Helpers;
using NetCoreServer;
using SPTSharp.Controllers;

namespace SPTSharp.Routers
{
    public static class LauncherRouter
    {
        /**
         * Handle /launcher/server/connect
         */
        public static void HandleConnect(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var content = LauncherCallbacks.Connect();
            Logger.LogDebug($"Response: \n{content}\n");
            byte[] bytes = HttpServerHelper.CompressString(content);
            var resp = response.MakeGetResponse(bytes);
            session.SendResponseAsync(resp);
        }

        /**
         * Handle /launcher/ping
         */
        public static void HandlePing(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var content = LauncherCallbacks.Ping();
            Logger.LogDebug($"Response: \n{content}\n");
            byte[] bytes = HttpServerHelper.CompressString(content);
            var resp = response.MakeGetResponse(bytes);
            session.SendResponseAsync(resp);
        }

        /**
         * Handle /launcher/server/version
         */
        public static void HandleVersion(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var content = LauncherCallbacks.GetVersion();
            Logger.LogDebug($"Response: \n{content}\n");
            byte[] bytes = HttpServerHelper.CompressString(content);
            var resp = response.MakeGetResponse(bytes);
            session.SendResponseAsync(resp);
        }

        /**
         * Handle /launcher/profile/login
         */
        public static void HandleLogin(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var body = HttpServerHelper.DecompressZlibToJSON(request.BodyBytes);

            var content = LauncherCallbacks.Login(body);
            Logger.LogDebug($"Response: \n{content}\n");
            byte[] bytes = HttpServerHelper.CompressString(content);
            var resp = response.MakeGetResponse(bytes);
            session.SendResponseAsync(resp);
        }

        /**
         * Handle /launcher/profile/register
         */
        public static void HandleRegister(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var body = HttpServerHelper.DecompressZlibToJSON(request.BodyBytes);

            var content = LauncherCallbacks.Register(body);
            Logger.LogDebug($"Response: \n{content}\n");
            byte[] bytes = HttpServerHelper.CompressString(content);
            var resp = response.MakeGetResponse(bytes);
            session.SendResponseAsync(resp);
        }

        /**
         * Handle /launcher/profiles
         */
        public static void HandleGetAllMiniProfiles(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var content = LauncherCallbacks.GetAllMiniProfiles();
            Logger.LogDebug($"\nResponse: \n{content}\n");
            byte[] bytes = HttpServerHelper.CompressString(content);
            var resp = response.MakeGetResponse(bytes);
            session.SendResponseAsync(resp);
        }

        /**
         * Handle /launcher/profile/get
         */
        public static void HandleGetProfile(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var body = HttpServerHelper.DecompressZlibToJSON(request.BodyBytes);

            var content = LauncherCallbacks.GetProfile(body);
            Logger.LogDebug($"Response: \n{content}\n");
            byte[] bytes = HttpServerHelper.CompressString(content);
            var resp = response.MakeGetResponse(bytes);
            session.SendResponseAsync(resp);
        }

        public static void HandleGetProfileInfo(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var content = LauncherCallbacks.GetProfileInfo(sessionID);
            Logger.LogDebug($"Response: \n{content}\n");
            byte[] bytes = HttpServerHelper.CompressString(content);
            var resp = response.MakeGetResponse(bytes);
            session.SendResponseAsync(resp);
        }

        public static void HandleGetLoadedServerMods(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var content = LauncherCallbacks.GetServerMods(sessionID);
            Logger.LogDebug($"Response: \n{content}\n");
            byte[] bytes = HttpServerHelper.CompressString(content);
            var resp = response.MakeGetResponse(bytes);
            session.SendResponseAsync(resp);
        }

        public static void HandleGetModsUsedByProfile(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var content = LauncherCallbacks.GetProfileMods(sessionID);
            Logger.LogDebug($"Response: \n{content}\n");
            byte[] bytes = HttpServerHelper.CompressString(content);
            var resp = response.MakeGetResponse(bytes);
            session.SendResponseAsync(resp);
        }

        public static void HandleRemoveProfile(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {

        }
    }
}

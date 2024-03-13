using Newtonsoft.Json;
using SPTSharp.Controllers;
using SPTSharp.Helpers;
using SPTSharp.Models.Eft.Launcher;
using SPTSharp.Routers;
using SPTSharp.Server;
using SPTSharp.Utils;
using NetCoreServer;

#pragma warning disable CS8604

namespace SPTSharp.CallBacks
{
    public static class LauncherCallbacks
    {
        private static LauncherController _launcherController => Singleton<LauncherController>.Instance;
        private static ProfileController _profileController => Singleton<ProfileController>.Instance;
        private static SaveServer saveServer => Singleton<SaveServer>.Instance;

        /**
         * Handle /launcher/server/connect
         */
        public static void Connect(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var content = HttpResponseUtil.NoBody(_launcherController.Connect());
            BaseRequestRouter.CompressAndSend(session, request, response, content);         
        }

        /**
         * Handle /launcher/ping
         */
        public static void Ping(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var content = HttpResponseUtil.NoBody("pong!");
            BaseRequestRouter.CompressAndSend(session, request, response, content);
        }

        /**
         * Handle /launcher/server/version
         */
        public static void GetVersion(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var content = HttpResponseUtil.NoBody(WatermarkUtil.GetVersionTag());
            BaseRequestRouter.CompressAndSend(session, request, response, content);
        }

        /**
         * Handle /launcher/profile/login
         */
        public static void Login(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var body = HttpServerHelper.DecompressZlibToJSON(request.BodyBytes);

            var req = JsonConvert.DeserializeObject<LoginRequestData>(body);
            
            var content = _launcherController.Login(req) != string.Empty 
                ? _launcherController.Login(req)
                : "FAILED";

            BaseRequestRouter.CompressAndSend(session, request, response, content);
        }

        /**
         * Handle /launcher/profile/register
         */
        public static void Register(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var body = HttpServerHelper.DecompressZlibToJSON(request.BodyBytes);

            var req = JsonConvert.DeserializeObject<LoginRegisterData>(body);

            var content = _launcherController.Register(req) != string.Empty
                ? "OK"
                : "FAILED";

            BaseRequestRouter.CompressAndSend(session, request, response, content);
        }

        /**
        * Handle /launcher/profiles
        */
        public static void GetAllMiniProfiles(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var content = HttpResponseUtil.NoBody(_profileController.GetMiniProfiles());
            BaseRequestRouter.CompressAndSend(session, request, response, content);
        }

        /**
         * Handle /launcher/profile/get
         */
        public static void GetProfile(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var body = HttpServerHelper.DecompressZlibToJSON(request.BodyBytes);

            var req = JsonConvert.DeserializeObject<LoginRequestData>(body);

            var content = HttpResponseUtil.NoBody(_launcherController.Find(_launcherController.Login(req)));

            BaseRequestRouter.CompressAndSend(session, request, response, content);
        }

        /***
         * Handle /launcher/profile/info
         */
        public static void GetProfileInfo(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var content = HttpResponseUtil.NoBody(_profileController.GetMiniProfile(sessionID));
            BaseRequestRouter.CompressAndSend(session, request, response, content);
        }

        /***
         * Handle /launcher/server/loadedServerMods
         */
        public static void GetServerMods(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var content = HttpResponseUtil.NoBody(new Dictionary<string, string>());
            BaseRequestRouter.CompressAndSend(session, request, response, content);
        }

        /***
         * Handle /launcher/server/serverModsUsedByProfile
         */
        public static void GetProfileMods(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var content = HttpResponseUtil.NoBody(new Dictionary<string, string>());
            BaseRequestRouter.CompressAndSend(session, request, response, content);
        }

        /***
         * Handle /launcher/profile/remove
         */
        public static void RemoveProfile(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var content = HttpResponseUtil.NoBody(saveServer.RemoveProfile(sessionID));
            BaseRequestRouter.CompressAndSend(session, request, response, content);
        }
    }
}

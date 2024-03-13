using ComponentAce.Compression.Libs.zlib;
using Newtonsoft.Json;
using SPTSharp.Controllers;
using SPTSharp.Helpers;
using SPTSharp.Models.Eft.Launcher;
using SPTSharp.Utils;


namespace SPTSharp.CallBacks
{
    public static class LauncherCallbacks
    {
        private static LauncherController _launcherController => Singleton<LauncherController>.Instance;
        private static ProfileController _profileController => Singleton<ProfileController>.Instance;

        /**
         * Handle /launcher/server/connect
         */
        public static string Connect()
        {
            return HttpResponseUtil.NoBody(_launcherController.Connect());
        }

        /**
         * Handle /launcher/ping
         */
        public static string Ping()
        {
            return HttpResponseUtil.NoBody("pong!");
        }

        /**
         * Handle /launcher/server/version
         */
        public static string GetVersion()
        {
            return HttpResponseUtil.NoBody(WatermarkUtil.GetVersionTag());
        }

        /**
         * Handle /launcher/profile/login
         */
        public static string Login(string body)
        {
            var req = JsonConvert.DeserializeObject<LoginRequestData>(body);
            
            if (req == null)
            {
                // Request is null, failed
                return "FAILED";
            }

            return _launcherController.Login(req) != string.Empty 
                ? _launcherController.Login(req)
                : "FAILED";
        }

        /**
         * Handle /launcher/profile/register
         */
        public static string Register(string body)
        {
            var req = JsonConvert.DeserializeObject<LoginRegisterData>(body);

            if (req == null)
            {
                // Request is null, failed
                return "FAILED";
            }

            return _launcherController.Register(req) != string.Empty
                ? "OK"
                : "FAILED";
        }

        /**
        * Handle /launcher/profiles
        */
        public static string GetAllMiniProfiles()
        {
            return HttpResponseUtil.NoBody(_profileController.GetMiniProfiles());
        }

        /**
         * Handle /launcher/profile/get
         */
        public static string GetProfile(string body)
        {
            var req = JsonConvert.DeserializeObject<LoginRequestData>(body);
            #pragma warning disable CS8604
            return HttpResponseUtil.NoBody(_launcherController.Find(_launcherController.Login(req)));
            #pragma warning restore
        }

        /***
         * Handle /launcher/profile/info
         */
        public static string GetProfileInfo(string sessionID)
        {
            return HttpResponseUtil.NoBody(_profileController.GetMiniProfile(sessionID));
        }

        /***
         * Handle /launcher/server/loadedServerMods
         */
        public static string GetServerMods(string sessionID)
        {
            return HttpResponseUtil.NoBody(new Dictionary<string, string>());
        }

        /***
         * Handle /launcher/server/serverModsUsedByProfile
         */
        public static string GetProfileMods(string sessionID)
        {
            return HttpResponseUtil.NoBody(new Dictionary<string, string>());
        }
    }
}

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

        public static string Connect()
        {
            return HttpResponseUtil.NoBody(_launcherController.Connect());
        }

        public static string Ping()
        {
            return HttpResponseUtil.NoBody("pong!");
        }

        public static string GetVersion()
        {
            return HttpResponseUtil.NoBody(WatermarkUtil.GetVersionTag());
        }

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
    }
}

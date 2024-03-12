using SPTSharp.Controllers;
using SPTSharp.Helpers;
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
    }
}

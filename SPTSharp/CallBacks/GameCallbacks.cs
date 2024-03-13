using NetCoreServer;
using SPTSharp.Helpers;
using SPTSharp.Models.Eft.Common;
using SPTSharp.Models.Eft.Game;
using SPTSharp.Routers;
using SPTSharp.Utils;

namespace SPTSharp.CallBacks
{
    internal static class GameCallbacks
    {
        public static void GetVersion(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var versionLabel = WatermarkUtil.GetInGameVersionLabel();
            var content = HttpResponseUtil.NoBody(new VersionResponse(versionLabel));
            BaseRequestRouter.CompressAndSend(session, request, response, content);
        }
        
        public static void GameStart(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            DateTime today = DateTime.UtcNow;
            long startTimeStampMS = (long)(today - new DateTime(1970, 1, 1)).TotalMilliseconds;

            var content = HttpResponseUtil.GetBody(new { utc_time = startTimeStampMS / 1000 });
            BaseRequestRouter.CompressAndSend(session, request, response, content);
        }
    }
}

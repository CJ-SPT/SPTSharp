using NetCoreServer;
using SPTSharp.Controllers;
using SPTSharp.Helpers;
using SPTSharp.Models.Eft.Common;
using SPTSharp.Models.Eft.Game;
using SPTSharp.Models.Spt.Server;
using SPTSharp.Routers;
using SPTSharp.Utils;

namespace SPTSharp.CallBacks
{
    internal static class GameCallbacks
    {
        private static GameController _controller => Singleton<GameController>.Instance;

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

        public static void Validate(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var content = HttpResponseUtil.NullResponse();
            BaseRequestRouter.CompressAndSend(session, request, response, content);
        }

        public static void GetGameConfig(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var config = Singleton<GameController>.Instance.GetGameConfig(sessionID);
            var content = HttpResponseUtil.GetBody(config);
            BaseRequestRouter.CompressAndSend(session, request, response, content);
        }

        public static void KeepAlive(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var content = HttpResponseUtil.GetBody(_controller.GetKeepGameAlive());
            BaseRequestRouter.CompressAndSend(session, request, response, content);
        }
    }
}

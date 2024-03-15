using NetCoreServer;
using SPTSharp.Controllers;
using SPTSharp.Helpers;
using SPTSharp.Routers;
using SPTSharp.Utils;

namespace SPTSharp.CallBacks
{
    internal static class TraderCallbacks
    {
        private static TraderController _controller => Singleton<TraderController>.Instance;

        public static void GetTraderSettings(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var content = HttpResponseUtil.GetBody(_controller.GetAllTraders(sessionID));
            BaseRequestRouter.CompressAndSend(session, request, response, content);
        }
    }
}

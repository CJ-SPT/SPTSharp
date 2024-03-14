using NetCoreServer;
using SPTSharp.Routers;
using SPTSharp.Utils;

namespace SPTSharp.CallBacks
{
    internal class TraderCallbacks
    {
        public static void GetTraderSettings(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var content = HttpResponseUtil.NoBody(new { });
            BaseRequestRouter.CompressAndSend(session, request, response, content);
        }
    }
}

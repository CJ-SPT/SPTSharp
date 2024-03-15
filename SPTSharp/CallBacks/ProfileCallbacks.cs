using NetCoreServer;
using SPTSharp.Controllers;
using SPTSharp.Helpers;
using SPTSharp.Routers;
using SPTSharp.Utils;

namespace SPTSharp.CallBacks
{
    internal static class ProfileCallbacks
    {
        private static ProfileController _controller => Singleton<ProfileController>.Instance;

        public static void GetProfileData(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var content = HttpResponseUtil.GetBody(_controller.GetCompleteProfile(sessionID));
            BaseRequestRouter.CompressAndSend(session, request, response, content);
        }
    }
}

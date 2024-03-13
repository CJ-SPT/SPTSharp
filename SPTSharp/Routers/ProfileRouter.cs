
using NetCoreServer;
using SPTSharp.CallBacks;
using SPTSharp.Helpers;

namespace SPTSharp.Routers
{
    public static class ProfileRouter
    {
        /**
         * Handle /launcher/profiles
         */
        public static void HandleGetAllMiniProfiles(HttpSession session, HttpRequest request, HttpResponse response)
        {
            var content = ProfileCallbacks.GetAllMiniProfiles();
            byte[] bytes = HttpServerHelper.CompressString(content);
            var resp = response.MakeGetResponse(bytes);
            session.SendResponseAsync(resp);
        }
    }
}

using NetCoreServer;
using Newtonsoft.Json;
using SPTSharp.Controllers;
using SPTSharp.Helpers;
using SPTSharp.Utils;

namespace SPTSharp.CallBacks
{
    public static class ProfileCallbacks
    {
        private static ProfileController _controller => Singleton<ProfileController>.Instance;

        // Handle /launcher/profiles
        public static string GetAllMiniProfiles()
        {
            return HttpResponseUtil.NoBody(_controller.GetMiniProfiles());
        }
    }
}

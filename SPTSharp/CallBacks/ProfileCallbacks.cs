using NetCoreServer;
using Newtonsoft.Json;
using SPTSharp.Controllers;
using SPTSharp.Helpers;
using SPTSharp.Models.Eft.Common;
using SPTSharp.Models.Eft.Profile;
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

        public static void GetNicknameReserved(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var content = HttpResponseUtil.GetBody("SPTSharp");
            BaseRequestRouter.CompressAndSend(session, request, response, content);
        }

        #pragma warning disable
        public static void ValidateNickname(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            string body = HttpServerHelper.DecompressZlibToJSON(request.BodyBytes);

            if (body == null)
            {
                throw new NullReferenceException("Request body was null for nickname validation");
            }

            ValidateNicknameRequestData requestData = JsonConvert.DeserializeObject<ValidateNicknameRequestData>(body);
            var validation = _controller.ValidateNickname(requestData, sessionID);

            string content = string.Empty;

            if (validation == "taken")
            {
                content = HttpResponseUtil.GetBody(null, 255, "255 - ");
            }

            if (validation == "tooshort")
            {
                content = HttpResponseUtil.GetBody(null, 256, "256 - ");
            }    

            content = HttpResponseUtil.GetBody(new { status = "ok"});
            BaseRequestRouter.CompressAndSend(session, request, response, content);
        }
        #pragma warning restore

        public static void CreateProfile(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            string body = HttpServerHelper.DecompressZlibToJSON(request.BodyBytes);

            if (body == null)
            {
                throw new NullReferenceException("Request body was null for profile creation");
            }

            ProfileCreateRequestData requestData = JsonConvert.DeserializeObject<ProfileCreateRequestData>(body);

            var id = _controller.CreateProfile(requestData, sessionID);
            
            var content = HttpResponseUtil.GetBody(new { uid = id });
            BaseRequestRouter.CompressAndSend(session, request, response, content);
        }
    }
}

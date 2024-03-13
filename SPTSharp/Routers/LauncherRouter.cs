using SPTSharp.CallBacks;
using SPTSharp.Helpers;
using NetCoreServer;
using SPTSharp.Controllers;

namespace SPTSharp.Routers
{
    public static class LauncherRouter
    {
        public static void HandleConnect(HttpSession session, HttpRequest request, HttpResponse response)
        {
            var content = LauncherCallbacks.Connect();
            byte[] bytes = HttpServerHelper.CompressString(content);
            var resp = response.MakeGetResponse(bytes);
            session.SendResponseAsync(resp);
        }

        public static void HandlePing(HttpSession session, HttpRequest request, HttpResponse response)
        {
            var content = LauncherCallbacks.Ping();
            byte[] bytes = HttpServerHelper.CompressString(content);
            var resp = response.MakeGetResponse(bytes);
            session.SendResponseAsync(resp);
        }

        public static void HandleVersion(HttpSession session, HttpRequest request, HttpResponse response)
        {
            var content = LauncherCallbacks.GetVersion();
            byte[] bytes = HttpServerHelper.CompressString(content);
            var resp = response.MakeGetResponse(bytes);
            session.SendResponseAsync(resp);
        }

        public static void HandleLogin(HttpSession session, HttpRequest request, HttpResponse response)
        {
            var body = HttpServerHelper.DecompressZlibToJSON(request.BodyBytes);

            var content = LauncherCallbacks.Login(body);
            byte[] bytes = HttpServerHelper.CompressString(content);
            var resp = response.MakeGetResponse(bytes);
            session.SendResponseAsync(resp);
        }

        public static void HandleRegister(HttpSession session, HttpRequest request, HttpResponse response)
        {
            var body = HttpServerHelper.DecompressZlibToJSON(request.BodyBytes);

            var content = LauncherCallbacks.Register(body);
            byte[] bytes = HttpServerHelper.CompressString(content);
            var resp = response.MakeGetResponse(bytes);
            session.SendResponseAsync(resp);
        }
    }
}

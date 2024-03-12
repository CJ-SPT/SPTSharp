using SPTSharp.CallBacks;
using SPTSharp.Helpers;
using System.IO.Compression;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using NetCoreServer;


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
    }
}

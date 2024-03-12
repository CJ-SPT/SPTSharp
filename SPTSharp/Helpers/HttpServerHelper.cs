using ComponentAce.Compression.Libs.zlib;
using SPTSharp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SPTSharp.Helpers
{
    public static class HttpServerHelper
    {
        private static Dictionary<string, string> _mime = new Dictionary<string, string>
        {
            {"css", "text/css"},
            {"bin", "application/octet-stream"},
            {"html", "text/html"},
            {"jpg", "image/jpeg"},
            {"js", "text/javascript"},
            {"json", "application/json"},
            {"png", "image/png"},
            {"svg", "image/svg+xml"},
            {"txt", "text/plain"},
        };

        public static string GetMineText(string key)
        {
            return _mime[key];
        }

        // Combine ip and port into url
        public static string BuildUrl()
        {
            var cfg = Singleton<ConfigController>.Instance.http;
            return $"{cfg.ip}:{cfg.port}";
        }

        // Prepend http to the url:port
        public static string GetBackendUrl()
        {
            return $"http://{BuildUrl()}";
        }

        // Get websocket url + port
        public static string GetWebSocketUrl()
        {
            return $"ws://{BuildUrl()}";
        }

        // Compress string into a byte array
        public static byte[] CompressString(string data)
        {
            return SimpleZlib.CompressToBytes(data, zlibConst.Z_BEST_COMPRESSION);
        }

        // Compress byte data
        public static byte[] CompressBytes(byte[] data)
        {
            return SimpleZlib.CompressToBytes(data, zlibConst.Z_BEST_COMPRESSION);
        }
    }
}

using ComponentAce.Compression.Libs.zlib;
using SPTSharp.Controllers;
using System;
using System.Collections.Generic;
using System.IO.Compression;
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

        // Compress using Zlib
        public static byte[] CompressStringZlib(string data)
        {
            return SimpleZlib.CompressToBytes(data, zlibConst.Z_BEST_COMPRESSION);
        }

        public static string DecompressZlibToJSON(byte[] compressedBytes)
        {
            using (MemoryStream compressedStream = new MemoryStream(compressedBytes))
            using (ZLibStream gzipStream = new ZLibStream(compressedStream, CompressionMode.Decompress))
            using (StreamReader reader = new StreamReader(gzipStream, Encoding.UTF8))
            {
                // Read the decompressed data and convert it to a JSON string
                return reader.ReadToEnd();
            }
        }

        static byte[] CompressStringGzipGZip(string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
                {
                    gzipStream.Write(buffer, 0, buffer.Length);
                }

                return memoryStream.ToArray();
            }
        }

        static string DecompressBytesGZip(byte[] compressedBytes)
        {
            using (MemoryStream memoryStream = new MemoryStream(compressedBytes))
            {
                using (GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                {
                    using (StreamReader reader = new StreamReader(gzipStream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
    }
}

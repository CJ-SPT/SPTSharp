using NetCoreServer;
using SPTSharp.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTSharp.Utils
{
    public static class HttpFileUtil
    {
        public static void SendFile(HttpSession session, HttpResponse response, string file)
        {
            var ext = Path.GetExtension(file) ?? HttpServerHelper.GetMineText("txt");
            byte[] bytes = File.ReadAllBytes(file);

            response.SetHeader("Content-Type", ext);
            var resp = response.MakeGetResponse(bytes);
            session.SendResponseAsync(resp);
        }
    }
}

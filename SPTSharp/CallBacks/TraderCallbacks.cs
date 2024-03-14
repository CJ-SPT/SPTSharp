using NetCoreServer;
using SPTSharp.Routers;
using SPTSharp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

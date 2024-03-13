using SPTSharp.Helpers;
using SPTSharp.Loaders;
using SPTSharp.Models.Eft.Common.Tables;
using SPTSharp.Models.Eft.Common;
using SPTSharp.Routers;
using SPTSharp.Server;
using SPTSharp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCoreServer;

namespace SPTSharp.CallBacks
{
    internal class BundleCallbacks
    {
        /***
         * Handle /singleplayer/bundles
         */
        public static void GetBundles(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var content = HttpResponseUtil.NoBody(Singleton<BundleLoader>.Instance.GetBundles(true));
            BaseRequestRouter.CompressAndSend(session, request, response, content);
        }

        public static void GetBundle(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var content = "BUNDLE";
            BaseRequestRouter.CompressAndSend(session, request, response, content);
        }
    }
}

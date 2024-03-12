using NetCoreServer;
using SPTSharp.Helpers;
using SPTSharp.Services;
using SPTSharp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTSharp.Routers
{
    public static class ImageRouter
    {
        public static void AddRoute(string key, string valueToAdd)
        {
            ImageRouterService.AddRoute(key, valueToAdd);
        }

        public static void SendImage(HttpSession session, HttpRequest request, HttpResponse response)
        {
            var url = request.Url.Split('.')[0];

            if (ImageRouterService.ExistsByKey(url))
            {
                HttpFileUtil.SendFile(session, response, ImageRouterService.GetByKey(url));
            }
        }

        public static string GetImage()
        {
            return "IMAGE";
        }
    }
}

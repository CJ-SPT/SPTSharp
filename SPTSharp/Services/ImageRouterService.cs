using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTSharp.Services
{
    public static class ImageRouterService
    {
        private static Dictionary<string, string> _routes = new Dictionary<string, string>();

        public static void AddRoute(string urlKey, string route)
        {
            _routes.Add(urlKey, route);
        }

        public static string GetByKey(string urlKey)
        {
            return _routes[urlKey];
        }

        public static bool ExistsByKey(string urlKey)
        {
            return _routes.ContainsKey(urlKey);
        }
    }
}

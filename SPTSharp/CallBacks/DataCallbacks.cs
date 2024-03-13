using NetCoreServer;
using SPTSharp.Controllers;
using SPTSharp.Helpers;
using SPTSharp.Models.Spt.Server;
using SPTSharp.Routers;
using SPTSharp.Services;
using SPTSharp.Utils;

namespace SPTSharp.CallBacks
{
    internal static class DataCallbacks
    {
        private static DatabaseTables _tables => Singleton<DatabaseController>.Instance.GetTables();

        public static void GetLocaleMenu(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var culture = LocalizationService.culture;
            var locale = _tables.Locales.Menu[culture];

            if (locale == null)
            {
                locale = _tables.Locales.Menu["en"];
            }

            MenuRootObject menu = new MenuRootObject();
            menu.Menu = locale;

            var content =  HttpResponseUtil.GetBody(menu);
            BaseRequestRouter.CompressAndSend(session, request, response, content);
        }

        public static void GetLocaleLanguages(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var content = HttpResponseUtil.GetBody(_tables.Locales.Languages);
            BaseRequestRouter.CompressAndSend(session, request, response, content);
        }

        public static void GetTemplateItems(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {
            var content = HttpResponseUtil.GetUnclearedBody(_tables.templates.items);
            BaseRequestRouter.CompressAndSend(session, request, response, content);
        }

        public static void GetTemplateSuits(HttpSession session, HttpRequest request, HttpResponse response, string sessionID)
        {

        }
    }
}

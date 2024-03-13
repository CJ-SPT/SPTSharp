using SPTSharp.Controllers;
using SPTSharp.Helpers;
using SPTSharp.Models.Spt.Server;
using SPTSharp.Services;
using SPTSharp.Utils;

namespace SPTSharp.CallBacks
{
    internal static class DataCallbacks
    {
        private static DatabaseTables _tables => Singleton<DatabaseController>.Instance.GetTables();

        public static string GetLocaleMenu()
        {
            var culture = LocalizationService.culture;
            var locale = _tables.Locales.Menu[culture];

            if (locale == null)
            {
                locale = _tables.Locales.Menu["en"];
            }

            return HttpResponseUtil.GetBody(locale);
        }
    }
}

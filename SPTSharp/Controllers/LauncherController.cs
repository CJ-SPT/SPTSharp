using SPTSharp.Helpers;
using SPTSharp.Models.Eft.Profile;
using SPTSharp.Services;

namespace SPTSharp.Controllers
{
    public class LauncherController
    {
        public SConnectResponse Connect()
        {
            return new SConnectResponse
            {
                backendUrl = HttpServerHelper.GetBackendUrl(),
                name = Singleton<ConfigController>.Instance.core.serverName,
                editions = DatabaseHelpers.GetProfileEditions(),
                //profileDescriptions = GetProfileDescriptions()
            };
        }
        /*
        // Get descriptive text for each of the profile editions a player can choose,
        // keyed by profile.json profile type e.g. "Edge Of Darkness"
        private Dictionary<string, string> GetProfileDescriptions()
        {
            var tables = Singleton<DatabaseController>.Instance.Tables;

            var result = new Dictionary<string, string>();

            foreach (var profile in tables.templates.profiles.ProfileSideDict)
            {
                var localeKey = tables.templates.profiles.ProfileSideDict[profile.Key].descriptionLocaleKey;

                if (localeKey == null || localeKey == string.Empty)
                {
                    Logger.LogWarning($"Missing locale key for {profile.Key}");
                    continue;
                }

                result[profile.Key] = tables.Locales.Server[LocalizationService.culture][localeKey];
            }

            return result;
        }*/
    }
}
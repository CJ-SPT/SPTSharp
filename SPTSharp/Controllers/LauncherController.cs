using SPTSharp.Helpers;
using SPTSharp.Models.Eft.Launcher;
using SPTSharp.Models.Eft.Profile;
using SPTSharp.Server;
using SPTSharp.Services;
using SPTSharp.Utils;

namespace SPTSharp.Controllers
{
    public class LauncherController
    {
        private SaveServer _saveServer => Singleton<SaveServer>.Instance;

        public SConnectResponse Connect()
        {
            return new SConnectResponse
            {
                backendUrl = HttpServerHelper.GetBackendUrl(),
                name = Singleton<ConfigController>.Instance.core.serverName,
                editions = DatabaseHelpers.GetProfileEditions(),
                profileDescriptions = GetProfileDescriptions()
            };
        }
        
        public Info? Find(string SessionId)
        {
            if (_saveServer.GetProfiles().ContainsKey(SessionId))
            {
                return _saveServer.GetProfile(SessionId).info;
            }

            return null;
        }

        public string Login(LoginRequestData data)
        {
            foreach (var profile in _saveServer.GetProfiles())
            {
                var account = _saveServer.GetProfile(profile.Key).info;

                if (data.username == account.username)
                {
                    // Returns session ID
                    return profile.Key;
                }
            }

            return string.Empty;
        }

        public string Register(LoginRegisterData data)
        {
            foreach (var profile in _saveServer.GetProfiles())
            {
                if (data.username == _saveServer.GetProfile(profile.Key).info.username)
                {
                    // Username exists, return empty
                    return string.Empty;
                }
            }

            // return profileId on success
            return CreateAccount(data);
        }

        public string WipeProfile(LoginRegisterData data)
        {
            var sessionId = Login(data);

            if (sessionId != null)
            {
                var profile = _saveServer.GetProfile(sessionId);

                profile.info.edition = data.edition;
                profile.info.wipe = true;
            }

            return sessionId;
        }

        private string CreateAccount(LoginRegisterData data)
        {
            var profileId = GenerateProfileId();
            var scavId = GenerateProfileId();

            var info = new Info
            {
                id = profileId,
                scavId = scavId,
                aid = HashUtil.GenerateAccountId(),
                username = data.username,
                password = data.password,
                wipe = true,
                edition = data.edition
            };

            _saveServer.CreateProfile(info);
            _saveServer.LoadProfile(profileId);
            _saveServer.SaveProfile(profileId);

            return profileId;
        }

        private string GenerateProfileId()
        {
            var guidString = Guid.NewGuid().ToString("N");
            var timeString = System.DateTime.Now.Ticks.ToString("X");
            var randomString = guidString + timeString;

            if (randomString.Length > 24)
            {
                randomString = randomString.Substring(0, 24);
            }
            else if (randomString.Length < 24)
            {
                randomString = randomString.PadRight(24, '0');
            }

            return randomString;
        }

        // Get descriptive text for each of the profile editions a player can choose,
        // keyed by profile.json profile type e.g. "Edge Of Darkness"
        private Dictionary<string, string> GetProfileDescriptions()
        {
            var tables = Singleton<DatabaseController>.Instance.GetTables();

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
        }
    }
}
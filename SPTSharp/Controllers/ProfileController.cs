﻿using SPTSharp.Helpers;
using SPTSharp.Models.Eft.Common;
using SPTSharp.Models.Eft.Launcher;
using SPTSharp.Models.Eft.Profile;
using SPTSharp.Models.Spt.Server;
using SPTSharp.Server;
using SPTSharp.Services;
using System.Data;

namespace SPTSharp.Controllers
{
    public class ProfileController
    {
        private SaveServer _saveServer => Singleton<SaveServer>.Instance;
        private DatabaseTables _tables => Singleton<DatabaseController>.Instance.GetTables();

        public List<MiniProfile> GetMiniProfiles()
        {
            List<MiniProfile> miniProfiles = new List<MiniProfile>();

            foreach (var sessionIdKey in _saveServer.GetProfiles())
            {
                miniProfiles.Add(GetMiniProfile(sessionIdKey.Key));
            }

            return miniProfiles;
        }

        public MiniProfile GetMiniProfile(string sessionId)
        {
            var maxLvl = ProfileHelper.GetMaxLevel();
            var profile = Singleton<SaveServer>.Instance.GetProfile(sessionId);
            var pmc = profile.characters.pmc;

            if (pmc?.Info?.Level == null)
            {
                return new MiniProfile
                {
                    username = profile.info.username,
                    nickname = "unknown",
                    side = "unknown",
                    currlvl = 0,
                    currexp = 0,
                    prevexp = 0,
                    nextlvl = 0,
                    maxlvl = maxLvl,
                    akiData = ProfileHelper.GetDefaultAkiDataObject()
                };
            }

            var currlvl = pmc.Info.Level;
            var nextlvl = ProfileHelper.GetExperience(currlvl + 1);

            return new MiniProfile
            {
                username = profile.info.username,
                nickname = pmc.Info.Nickname,
                side = pmc.Info.Side,
                currlvl = pmc.Info.Level,
                currexp = pmc.Info.Experience,
                prevexp = currlvl == 0 ? 0 : ProfileHelper.GetExperience(currlvl),
                nextlvl = nextlvl,
                maxlvl = maxLvl,
                akiData = new AkiData
                {
                    version = profile.aki.version
                }
            };
        }

        public List<PmcData> GetCompleteProfile(string sessionID)
        {
            return ProfileHelper.GetCompleteProfile(sessionID);
        }

        public string CreateProfile(ProfileCreateRequestData data, string sessionID)
        {
            var account = _saveServer.GetProfile(sessionID).info;
            var profile = data.side == "bear"
                ? _tables.templates.profiles.ProfileSideDict[account.edition].bear
                : _tables.templates.profiles.ProfileSideDict[account.edition].usec;

            var pmcData = profile.character;

            // Delete existing profile
            DeleteProfileBySessionID(sessionID);

            // PMC
            pmcData._id = account.id;
            pmcData.aid = account.aid;
            pmcData.savage = account.scavId;
            pmcData.sessionId = sessionID;
            pmcData.Info.Nickname = data.nickname;
            pmcData.Info.LowerNickname = data.nickname.ToLower();
            pmcData.Info.RegistrationDate = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            pmcData.Info.Voice = _tables.templates.customization[data.voidId]._name;
            pmcData.Stats = null; //TODO
            pmcData.Info.NeedWipeOptions = [];
            pmcData.Customization.Head = data.headId;
            pmcData.Health.UpdateTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            pmcData.Quests = [];
            pmcData.Hideout.Seed = DateTimeOffset.UtcNow.AddYears(8).ToUnixTimeSeconds(); // 8 years in future why? who knows, we saw it in live
            pmcData.RepeatableQuests = [];
            pmcData.CarExtractCounts = new Dictionary<string, int>();
            pmcData.CoopExtractCounts = new Dictionary<string, int>();
            pmcData.Achievements = new Dictionary<string, int>();

            // TODO - REST
        }

        private void DeleteProfileBySessionID(string sessionID)
        {
            if (_saveServer.GetProfiles().ContainsKey(sessionID))
            {
                _saveServer.DeleteProfileBySessionId(sessionID);
                return;
            }

            Logger.LogWarning(LocalizationService.GetText("profile-unable_to_find_profile_by_id_cannot_delete"));
        }

        public string ValidateNickname(ValidateNicknameRequestData data, string sessionID)
        {
            if (data.nickname.Length < 3)
            {
                return "tooshort";
            }

            if (ProfileHelper.IsNicknameTaken(data, sessionID))
            {
                return "taken";
            }

            return "OK";
        }
    }
}

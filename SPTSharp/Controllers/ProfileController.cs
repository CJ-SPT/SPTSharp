using SPTSharp.Helpers;
using SPTSharp.Models.Eft.Common;
using SPTSharp.Models.Eft.Launcher;
using SPTSharp.Server;

namespace SPTSharp.Controllers
{
    public class ProfileController
    {
        private SaveServer _saveServer => Singleton<SaveServer>.Instance;

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
    }
}

using SPTSharp.Controllers;
using SPTSharp.Models.Eft.Common;
using SPTSharp.Models.Eft.Launcher;
using SPTSharp.Models.Eft.Profile;
using SPTSharp.Models.Spt.Server;
using SPTSharp.Server;
using SPTSharp.Services;

namespace SPTSharp.Helpers
{
    public static class ProfileHelper
    {
        private static DatabaseTables _tables => Singleton<DatabaseController>.Instance.GetTables();
        private static SaveServer _saveServer => Singleton<SaveServer>.Instance;

        /// <summary>
        /// Get the pmc and scav profiles as a list by profile id
        /// </summary>
        /// <param name="sessionID"></param>
        /// <returns>List of IPmcData objects</returns>
        public static List<PmcData> GetCompleteProfile(string sessionID)
        {
            List<PmcData> output = new List<PmcData>();

            if (IsWiped(sessionID))
            {
                return output;
            }

            var pmcProfile = GetPmcProfile(sessionID);
            var scavProfile = GetScavProfile(sessionID);

            if (ProfileSnapshotService.HasProfileSnapshot(sessionID))
            {
                return PostRaidXpWorkaroundFix(sessionID, output, pmcProfile, scavProfile);
            }

            output.Add(pmcProfile);
            output.Add(scavProfile);

            return output;
        }

        private static List<PmcData> PostRaidXpWorkaroundFix(string sessionID, List<PmcData> output, PmcData pmcProfile, PmcData scavProfile)
        {
            PmcData clonedPmc = (PmcData)pmcProfile.Clone();
            PmcData clonedScav = (PmcData)scavProfile.Clone();

            var profileSnapshot = ProfileSnapshotService.GetProfileSnapshot(sessionID);

            clonedPmc.Info.Level = profileSnapshot.characters.pmc.Info.Level;
            clonedPmc.Info.Experience = profileSnapshot.characters.pmc.Info.Experience;

            clonedScav.Info.Level = profileSnapshot.characters.scav.Info.Level;
            clonedScav.Info.Level = profileSnapshot.characters.scav.Info.Experience;

            ProfileSnapshotService.ClearProfileSnapshot(sessionID);

            output.Add(clonedPmc);
            output.Add(clonedScav);

            return output;
        }

        /// <summary>
        /// Check if a nickname is used by another profile loaded by the server
        /// </summary>
        /// <param name="data"></param>
        /// <param name="sessionID"></param>
        /// <returns>True if already used</returns>
        public static bool IsNicknameTaken(ValidateNicknameRequestData data, string sessionID)
        {
            foreach (var profile in _saveServer.GetProfiles())
            {
                if (!ProfileHasInfoProperty(profile.Value))
                {
                    continue;
                }

                // SessionIds don't match + nicknames do
                if (!StringsMatch(profile.Value.info.id, sessionID) 
                    && StringsMatch(profile.Value.characters.pmc.Info.LowerNickname.ToLower(), data.nickname.ToLower()))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool ProfileHasInfoProperty(AkiProfile profile)
        {
            if (profile?.characters?.pmc?.Info == null)
            {
                return false;
            }
            return true;
        }

        private static bool StringsMatch(string a, string b)
        {
            return a == b;
        }

        /// <summary>
        /// Get the experience for the given level
        /// </summary>
        /// <param name="level"></param>
        /// <returns>Number of xp points for level</returns>
        public static int GetExperience(int level)
        {
            var playerLevel = level;
            var expTable = _tables.globals.config.exp.level.exp_table;
            var exp = 0;

            if (playerLevel >= expTable.Length)
            {
                // Make sure we don't go out of bounds
                playerLevel = expTable.Length - 1;
            }

            for ( var i = 0; i < level; i++ )
            {
                exp += expTable[i].exp;
            }

            return exp;
        }

        /// <summary>
        /// Get the max level a player can be
        /// </summary>
        /// <returns>Max level</returns>
        public static int GetMaxLevel()
        {
            return _tables.globals.config.exp.level.exp_table.Length - 1;
        }

        public static AkiData GetDefaultAkiDataObject()
        {
            return new AkiData
            {
                version = GetServerVersion(),
            };
        }

        public static string GetServerVersion()
        {
            return WatermarkUtil.GetVersionTag(true);
        }

        /// <summary>
        /// Get full representation of a players profile json
        /// </summary>
        /// <param name="sessionID"></param>
        /// <returns>AkiProfile object</returns>
        public static AkiProfile GetFullProfile(string sessionID)
        {
            return _saveServer.GetProfile(sessionID);
        }

        /// <summary>
        /// Get a full profiles pmc-specific sub-profile
        /// </summary>
        /// <param name="sessionID"></param>
        /// <returns>PmcData object</returns>
        public static PmcData GetPmcProfile(string sessionID)
        {
            var fullProfile = GetFullProfile(sessionID);

            return fullProfile.characters.pmc;
        }

        /// <summary>
        /// Get a full profiles scav-specific sub-profile
        /// </summary>
        /// <param name="sessionID"></param>
        /// <returns>PmcData object</returns>
        public static PmcData GetScavProfile(string sessionID) 
        {
            var fullProfile = GetFullProfile(sessionID);

            return fullProfile.characters.scav;
        }

        /// <summary>
        /// is this profile flagged for data removal
        /// </summary>
        /// <param name="sessionID"></param>
        /// <returns>true if profile is to be wiped of data</returns>
        public static bool IsWiped(string sessionID)
        {
            return _saveServer.GetProfile(sessionID).info.wipe;
        }
    }
}

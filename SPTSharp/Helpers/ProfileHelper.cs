using SPTSharp.Controllers;
using SPTSharp.Models.Eft.Common;
using SPTSharp.Models.Eft.Launcher;
using SPTSharp.Models.Eft.Profile;
using SPTSharp.Models.Spt.Server;
using SPTSharp.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTSharp.Helpers
{
    public static class ProfileHelper
    {
        private static DatabaseTables _tables => Singleton<DatabaseController>.Instance.GetTables();
        private static SaveServer _saveServer => Singleton<SaveServer>.Instance;

        // Gets the experience for a given level
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

        // returns the max level a player can be
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

        public static AkiProfile GetFullProfile(string sessionID)
        {
            return _saveServer.GetProfile(sessionID);
        }

        public static PmcData GetPmcProfile(string sessionID)
        {
            var fullProfile = GetFullProfile(sessionID);

            return fullProfile.characters.pmc;
        }

        public static PmcData GetScavProfile(string sessionID) 
        {
            var fullProfile = GetFullProfile(sessionID);

            return fullProfile.characters.scav;
        }
    }
}

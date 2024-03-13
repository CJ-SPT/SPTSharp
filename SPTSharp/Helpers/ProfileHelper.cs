using SPTSharp.Controllers;
using SPTSharp.Models.Eft.Launcher;
using SPTSharp.Models.Spt.Server;
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
    }
}

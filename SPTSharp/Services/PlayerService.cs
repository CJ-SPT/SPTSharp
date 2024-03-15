
using SPTSharp.Controllers;
using SPTSharp.Helpers;
using SPTSharp.Models.Eft.Common;
using SPTSharp.Models.Spt.Server;

namespace SPTSharp.Services
{
    public static class PlayerService
    {
        private static DatabaseTables _tables => Singleton<DatabaseController>.Instance.GetTables();

        public static int CalculateLevel(PmcData pmcData)
        {
            int accExp = 0;

            foreach (var level in _tables.globals.config.exp.level.exp_table)
            {
                accExp += level.exp;

                if (pmcData.Info.Experience < accExp)
                {
                    break;
                }

                pmcData.Info.Level += 1;
            }

            return pmcData.Info.Level;
        }
    }
}

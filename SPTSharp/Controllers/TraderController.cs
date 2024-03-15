using SPTSharp.Helpers;
using SPTSharp.Models.Eft.Common.Tables;
using SPTSharp.Models.Enums;
using SPTSharp.Models.Spt.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTSharp.Controllers
{
    public class TraderController
    {
        private DatabaseTables _tables => Singleton<DatabaseController>.Instance.GetTables();

        public List<TraderBase> GetAllTraders(string sessionID)
        {
            var traderBase = new List<TraderBase>();
            var pmcData = ProfileHelper.GetPmcProfile(sessionID);

            foreach (var trader in _tables.traders)
            {
                if (trader.Key == "ragfair")
                {
                    continue;
                }

               traderBase.Add(TraderHelper.GetTrader(trader.Key, sessionID));

                if (pmcData.Info != null)
                {
                    TraderHelper.LevelUpTrader(trader.Key, pmcData);
                }
            }

            // traderBase.Sort(); // TODO: FIX THIS

            return traderBase;
        }
    }
}

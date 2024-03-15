using SPTSharp.Controllers;
using SPTSharp.Models.Eft.Common;
using SPTSharp.Models.Eft.Common.Tables;
using SPTSharp.Models.Enums;
using SPTSharp.Models.Spt.Server;
using SPTSharp.Server;
using SPTSharp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTSharp.Helpers
{
    public static class TraderHelper
    {
        private static DatabaseTables _tables => Singleton<DatabaseController>.Instance.GetTables();

        public static TraderBase? GetTrader(string traderID, string sessionID)
        {
            var pmcData = ProfileHelper.GetPmcProfile(sessionID);

            if (pmcData == null)
            {
                Logger.LogError($"No profile with sessionID: {sessionID}");
            }

            // Profile has traderInfo dict (profile beyond creation stage) but no requested trader in profile
            if (pmcData?.TradersInfo  != null && !pmcData.TradersInfo.ContainsKey(traderID))
            {
                // Add trader values to profile
                ResetTrader(traderID, sessionID);
                LevelUpTrader(traderID, pmcData);
            }

            var trader = _tables?.traders[traderID]?.Base;

            if (trader == null)
            {
                Logger.LogError($"Trader is either null or not found {traderID}");
            }

            return trader;
        }

        public static void ResetTrader(string traderID, string sessionID)
        {
            var account = Singleton<SaveServer>.Instance.GetProfile(sessionID);
            var pmcData = ProfileHelper.GetPmcProfile(sessionID);

            ProfileTraderTemplate profileTemplate;

            profileTemplate = pmcData.Info.Side == "bear"
                ? _tables.templates.profiles.ProfileSideDict[account.info.edition].bear.trader
                : _tables.templates.profiles.ProfileSideDict[account.info.edition].usec.trader;


            pmcData.TradersInfo[traderID] = new TraderInfo
            {
                disabled = false,
                loyaltyLevel = profileTemplate.initialLoyaltyLevel[traderID],
                salesSum = profileTemplate.initialSalesSum,
                standing = GetStartingStanding(traderID, profileTemplate),
                nextResupply = _tables.traders[traderID].Base.nextResupply,
                unlocked = _tables.traders[traderID].Base.unlockedByDefault,
            };

            if (traderID == ETraders.JAEGER)
            {
                pmcData.TradersInfo[traderID].unlocked = profileTemplate.jaegerUnlocked;
            }
        }

        public static float GetStartingStanding(string traderID, ProfileTraderTemplate profileTemplate)
        {
            // Edge case for lightkeeper, 0 standing means seeing "Make Amends - buyout" quest
            if (traderID == ETraders.LIGHTHOUSEKEEPER && profileTemplate.initialStanding == 0)
            {
                return 0.01f;
            }

            return profileTemplate.initialStanding;
        }

        public static void LevelUpTrader(string traderID, PmcData pmcData)
        {
            var loyalLevels = _tables.traders[traderID].Base.loyaltyLevels;

            pmcData.Info.Level = PlayerService.CalculateLevel(pmcData);

            // Round standing to 2 decimal places to address floating point inaccuracies
            pmcData.TradersInfo[traderID].standing = (float)Math.Round(pmcData.TradersInfo[traderID].standing * 100, 2) / 100;

            int targetLevel = 0;

            for (int i = 0; targetLevel < loyalLevels.Length; i++)
            {
                var loyalty = loyalLevels[i];

                if ((loyalty.minLevel <= pmcData.Info.Level 
                    && loyalty.minSalesSum <= pmcData.TradersInfo[traderID].salesSum
                    && loyalty.minStanding <= pmcData.TradersInfo[traderID].standing)
                    && i < 4)
                {
                    targetLevel++;
                }
            }

            pmcData.TradersInfo[traderID].loyaltyLevel = targetLevel;
        }
    }
}

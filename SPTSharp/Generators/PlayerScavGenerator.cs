using SPTSharp.Controllers;
using SPTSharp.Helpers;
using SPTSharp.Models.Eft.Common;
using SPTSharp.Models.Enums;
using SPTSharp.Server;
using SPTSharp.Services;
using System.Runtime.CompilerServices;

namespace SPTSharp.Generators
{
    public static class PlayerScavGenerator
    {
        private static SaveServer _saveServer => Singleton<SaveServer>.Instance;
        private static ConfigController _config => Singleton<ConfigController>.Instance;

        /// <summary>
        /// Update a player profile to include a new player scav profile
        /// </summary>
        /// <param name="sessionID"></param>
        /// <returns>profile object</returns>
        public static PmcData Generate(string sessionID)
        {
            var profile = _saveServer.GetProfile(sessionID);
            var pmcClone = (PmcData)profile.characters.pmc.Clone();

            var scavKarmaLevel = GetScavKarma(pmcClone);

            var playerScavKarmaSettings = _config.playerScavConfig.karmaLevel[scavKarmaLevel.ToString()];
            if (playerScavKarmaSettings == null)
            {
                Logger.LogError(LocalizationService.GetText("scav-missing_karma_settings"));
            }

            Logger.LogDebug($"Generated player scav loadout for karma level {scavKarmaLevel}");



            return new PmcData();
        }

        /// <summary>
        /// Get the scav karma level for a profile
        /// Is also the fence trader rep level
        /// </summary>
        /// <param name="pmcData"></param>
        /// <returns>karma level</returns>
        private static int GetScavKarma(PmcData pmcData)
        {
            var fenceInfo = pmcData.TradersInfo[ETraders.FENCE];

            if (fenceInfo == null)
            {
                Logger.LogWarning(LocalizationService.GetText("scav-missing_karma_level_getting_default"));
                return 0;
            }

            if (fenceInfo.standing > 6f)
            {
                return 6;
            }

            // e.g. 2.09 becomes 2
            return (int)Math.Floor(fenceInfo.standing);
        }
    }
}

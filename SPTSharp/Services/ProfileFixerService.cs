using SPTSharp.Controllers;
using SPTSharp.Helpers;
using SPTSharp.Models.Eft.Common;
using SPTSharp.Models.Eft.Common.Tables;
using SPTSharp.Models.Enums;
using SPTSharp.Models.Spt.Server;

namespace SPTSharp.Services
{
    public static class ProfileFixerService
    {
        private static DatabaseTables _tables => Singleton<DatabaseController>.Instance.GetTables();

        /// <summary>
        /// Find issues in the pmc profile data that may cause issues and fix them
        /// </summary>
        public static void CheckForAndFixProfileIssues(PmcData pmcData)
        {
            RemoveDanglingConditionCounters(pmcData);
            RemoveDanglingTaskConditionCounters(pmcData);
            AddMissingRepeatableQuestsProperty(pmcData);
            AddLighthouseKeeperIfMissing(pmcData);
            AddUnlockedInfoObjectIfMissing(pmcData);
            RemoveOrphanedQuests(pmcData);

            if (pmcData.Inventory != null)
            {
                AddHideoutAreaStashes(pmcData);
            }

            if (pmcData.Hideout != null)
            {
                MigrateImprovements(pmcData);
                AddMissingBonusProperty(pmcData);
                AddMissingWallImprovements(pmcData);
                AddMissingHideoutWallAreas(pmcData);
                AddMissingGunStandContainerImprovements(pmcData);
                AddMissingHallOfFameContainerImprovements(pmcData);
                EnsureGunStandLevelsMatch(pmcData);
                RemoveResourcesFromSlotsInHideoutWithoutLocationIndexValue(pmcData);
                ReorderHideoutAreasWithResourceInputs(pmcData);

                if (pmcData.Hideout.Areas.Single(x => x.type == EHideoutAreas.GENERATOR).slots.Count < 
                    (6 + _tables.globals.config.SkillsSettings.HideoutManagement.EliteSlots.Generator.Slots))
                {
                    //Logger.LogDebug("[PFS] Updating generator area slots to a size of 6 + hideout management skill");

                    // TODO
                }
            }
        }

        /// <summary>
        /// TODO - make this non-public - currently used by RepeatableQuestController
        /// Remove unused condition counters
        /// </summary>
        public static void RemoveDanglingConditionCounters(PmcData pmcData)
        {
            if (pmcData.TaskConditionCounters != null)
            {
                foreach(var counterId in pmcData.TaskConditionCounters)
                {
                    var counter = pmcData.TaskConditionCounters[counterId.Key];

                    if (counter.sourceId == null)
                    {
                        pmcData.TaskConditionCounters.Remove(counterId.Key);
                        Logger.LogDebug($"[PFS] Removing task condition counter {counterId.Key}");
                    }
                }
            }
        }

        private static void RemoveDanglingTaskConditionCounters(PmcData pmcData)
        {
            // TODO
        }

        private static void AddMissingRepeatableQuestsProperty(PmcData pmcData)
        {
            // TODO
        }

        private static void AddLighthouseKeeperIfMissing(PmcData pmcData)
        {
           
        }

        private static void AddUnlockedInfoObjectIfMissing(PmcData pmcData)
        {
            // TODO
        }

        private static void RemoveOrphanedQuests(PmcData pmcData)
        {
            // TODO
        }

        /// <summary>
        /// Add missing hideout area stashes
        /// </summary>
        /// <param name="pmcData"></param>
        private static void AddHideoutAreaStashes(PmcData pmcData)
        {
            if (pmcData?.Inventory?.hideoutAreaStashes == null)
            {
                pmcData.Inventory.hideoutAreaStashes = new Dictionary<string, string>();
            }
        }

        private static void MigrateImprovements(PmcData pmcData)
        {
            // TODO
        }

        private static void AddMissingBonusProperty(PmcData pmcData)
        {
            // TODO
        }

        private static void AddMissingWallImprovements(PmcData pmData)
        {
            // TODO
        }

        private static void AddMissingHideoutWallAreas(PmcData pmcData)
        {
            // TODO
        }

        private static void AddMissingGunStandContainerImprovements(PmcData pmcData)
        {
            // TODO
        }

        private static void AddMissingHallOfFameContainerImprovements(PmcData pmcData)
        {
            // TODO
        }

        private static void EnsureGunStandLevelsMatch(PmcData pmData)
        {
            // TODO
        }

        private static void RemoveResourcesFromSlotsInHideoutWithoutLocationIndexValue(PmcData pmData)
        {
            // TODO
        }

        private static void ReorderHideoutAreasWithResourceInputs(PmcData pmData)
        {
            // TODO
        }

        /*
        private static List<HideoutSlot> AddObjectsToList(int count, List<HideoutSlot> slots)
        {
            
        } */
    }
}

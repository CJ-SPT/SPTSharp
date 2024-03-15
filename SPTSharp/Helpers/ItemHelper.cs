using Newtonsoft.Json;
using SPTSharp.Models.Eft.Common;
using SPTSharp.Models.Eft.Common.Tables;
using SPTSharp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SPTSharp.Helpers
{
    public static class ItemHelper
    {
        /// <summary>
        /// Regenerate all GUIDs with new IDs, with the exception of special item types (e.g. quest, sorting table, etc.) This
        /// function will not mutate the original items array, but will return a new array with new GUIDs. THIS IS CANCER
        /// </summary>
        /// <param name="origItems"></param>
        /// <param name="pmcData"></param>
        /// <param name="insuredItems"></param>
        /// <param name="fastPanel"></param>
        /// <returns></returns>
        public static List<Item> ReplaceIDs(List<Item> origItems, PmcData pmcData, List<InsuredItem> insuredItems)
        {
            List<Item> newItemList = new List<Item>();

            // clone the original items list
            foreach (var item in origItems)
            {
                newItemList.Add((Item)item.Clone());
            }

            foreach (var item in newItemList)
            {
                if (pmcData != null)
                {
                    // Insured items should not be renamed. Only works for PMC's
                    if (insuredItems.Where(i => i.itemId == item._id).Any())
                    {
                        continue;
                    }

                    // Do not replace the IDs of specific types of items
                    if (item._id == pmcData.Inventory.equipment
                        || item._id == pmcData.Inventory.questRaidItems
                        || item._id == pmcData.Inventory.questStashItems
                        || item._id == pmcData.Inventory.stash)
                    {
                        continue;
                    }

                    // Replace the ID of the item in the serialized inventory.
                    string oldId = item._id;
                    string newId = HashUtil.GenerateHash();

                    foreach (var item2 in newItemList)
                    {
                        if (oldId.Equals(item2._id))
                        {
                            item2._id = newId;
                        }
                    }

                    var fastPanel = pmcData.Inventory.fastPanel;

                    if (fastPanel != null)
                    {
                        foreach (var itemSlot in fastPanel)
                        {
                            if (fastPanel[itemSlot.Key] == oldId)
                            {
                                fastPanel[itemSlot.Key] = Regex.Replace(fastPanel[itemSlot.Key], oldId, newId);
                            }
                        }
                    }
                }
            }

            // Fix duplicate Id's
            Dictionary<string, int > dupes = new Dictionary<string, int>();
            Dictionary<string, List<Item>> newParents = new Dictionary<string, List<Item>>();
            Dictionary<string, Dictionary<string, int>> childrenMapping = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, List<string>> oldToNewIds = new Dictionary<string, List<string>>();

            // Finding duplicate IDs involves scanning the item three times.
            // First scan - Check which ids are duplicated.
            // Second scan - Map parents to items.
            // Third scan - Resolve IDs.
            foreach (var item in newItemList)
            {
                // if dupes contains this item id, increment the count.
                if (dupes.ContainsKey(item._id))
                    dupes[item._id]++;
                else 
                {
                    // If not, add it with a count of 1.
                    dupes.Add(item._id, 1);
                }
            }

            foreach (var item in newItemList)
            {
                // if the count of this item is more than 1.
                if (dupes[item._id] > 1)
                {
                    var newId = HashUtil.GenerateHash();

                    // If the newParents dict has no entry
                    // Add an empty entry
                    if (!newParents.ContainsKey(item.parentId))
                        newParents.Add(item.parentId, new List<Item>());

                    newParents[item.parentId].Add(item);

                    // if the oldToNewIds dict has no entry
                    // Add an empty entry
                    if (!oldToNewIds.ContainsKey(item._id))
                        oldToNewIds.Add(item._id, new List<string>());

                    oldToNewIds[item._id].Add(newId);
                }
            }

            foreach (var item in newItemList)
            {
                if (dupes[item._id] > 1)
                {
                    string oldId = item._id;

                    // Get the first newId
                    string newId = oldToNewIds[oldId].FirstOrDefault(); 
                    
                    if (newId != null)
                    {
                        oldToNewIds[oldId].RemoveAt(0); // Remove the used newId
                        item._id = newId;

                        // Extract one of the children that's also duplicated.
                        if (newParents.ContainsKey(oldId) && newParents[oldId].Count > 0)
                        {
                            childrenMapping[newId] = new Dictionary<string, int>();
                            for (int childIndex = newParents[oldId].Count - 1; childIndex >= 0; childIndex--)
                            {
                                // Make sure we haven't already assigned another duplicate child of
                                // same slot and location to this parent.
                                string childId = GetChildId(newParents[oldId][childIndex]);

                                if (!childrenMapping[newId].ContainsKey(childId))
                                {
                                    childrenMapping[newId][childId] = 1;
                                    newParents[oldId][childIndex].parentId = newId;
                                    newParents[oldId].RemoveAt(childIndex);
                                }
                            }
                        }
                    }
                }
            }

            return newItemList;
        }

        private static string GetChildId(Item item)
        {
            if (item.location == null)
            {
                return item.slotId;
            }

            Location loc = (Location)item.location;
            return $"{item.slotId},{loc.x},{loc.y}";
        }
    }
}

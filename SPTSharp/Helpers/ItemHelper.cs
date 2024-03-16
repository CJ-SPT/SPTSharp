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

            Dictionary<string, int> dupes = new Dictionary<string, int>();
            Dictionary<string, List<Item>> newParents = new Dictionary<string, List<Item>>();
            Dictionary<string, string[]> oldToNewIds = new Dictionary<string, string[]>();
            Dictionary<string, Dictionary<string, int>> childrenMapping = new Dictionary<string, Dictionary<string, int>>();


            // First scan - Check which ids are duplicated.
            foreach (var item in newItemList)
            {
                if (!dupes.ContainsKey(item._id))
                    dupes[item._id] = 1;
                else
                    dupes[item._id]++;
            }

            foreach (var item in newItemList)
            {
                if (dupes[item._id] > 1)
                {
                    string newId = Guid.NewGuid().ToString(); // Using GUID as a replacement for this.hashUtil.generate()

                    if (!newParents.ContainsKey(item.parentId))
                        newParents[item.parentId] = new List<Item>();

                    newParents[item.parentId].Add(item);

                    if (!oldToNewIds.ContainsKey(item._id))
                        oldToNewIds[item._id] = new string[] { newId };
                    else
                    {
                        var ids = new List<string>(oldToNewIds[item._id])
                        {
                            newId
                        };
                        oldToNewIds[item._id] = ids.ToArray();
                    }
                }
            }

            foreach (var item in newItemList)
            {
                if (dupes[item._id] > 1)
                {
                    string oldId = item._id;
                    string newId = oldToNewIds[oldId][0];
                    item._id = newId;

                    if (newParents.ContainsKey(oldId) && newParents[oldId].Count > 0)
                    {
                        childrenMapping[newId] = new Dictionary<string, int>();
                        foreach (var childItem in newParents[oldId])
                        {
                            string childId = GetChildId(childItem);

                            if (!childrenMapping[newId].ContainsKey(childId))
                            {
                                childrenMapping[newId][childId] = 1;
                                childItem.parentId = newId;
                                newParents[oldId].Remove(childItem); // Remove the child from the list
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

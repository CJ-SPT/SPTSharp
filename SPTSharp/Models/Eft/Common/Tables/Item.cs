#pragma warning disable
using Newtonsoft.Json;
using System.Globalization;

namespace SPTSharp.Models.Eft.Common.Tables
{
    public class Item
    {
        public string _id { get; set; }
        public string _tpl { get; set; }
        public string? parentId { get; set; }
        public string? slotId { get; set; }
        public Upd upd { get; set; }

        // TODO: this needs to be a number as well, wtf?
        public dynamic location { get; set; }
    }

    public class Upd
    {
        public Buff? Buff { get; set; }
        public int? OriginalStackObjectsCount { get; set; }
        public Togglable? Togglable { get; set; }
        public Map? Map { get; set; }
        public Tag? Tag { get; set; }

        // SPT specific property, not made by BSG
        public string? sptPresetId { get; set; }
        public FaceShield? FaceShield { get; set; }
        public int? StackObjectsCount { get; set; }
        public bool UnlimitedCount { get; set; }
        public Repairable? Repairable { get; set; }
        public RecodableComponent? RecodableComponent { get; set; }
        public FireMode? FireMode { get; set; }
        public bool? SpawnedInSession { get; set; }
        public Light? Light { get; set; }
        public Key? Key { get; set; }
        public Resource? Resource { get; set; }
        public Sight? Sight { get; set; }
        public MedKit? MedKit { get; set; }
        public FoodDrink? FoodDrink { get; set; }
        public DogTag? DogTag { get; set; }
        public int? BuyRestrictionMax { get; set; }
        public int? BuyRestrictionCurrent { get; set; }
        public Foldable? Foldable { get; set; }
        public SideEffect? SideEffect { get; set; }
        public RepairKit? RepairKit { get; set; }
        public CultistAmulet? CultistAmulet { get; set; }
    }

    public class Buff
    {
        public string rarity { get; set; }
        public string buffType { get; set; }
        public float value { get; set; }
        public float thresholdDurability { get; set; }
    }

    public class Togglable
    {
        public bool On { get; set; }
    }

    public class Map
    {
        public MapMarker[] Markers { get; set; }
    }

    public class MapMarker
    {
        public float X { get; set; }
        public float Y { get; set; }
    }

    public class Tag
    {
        public float Color { get; set; }
        public string Name { get; set; }
    }

    public class FaceShield
    {
        public int Hits { get; set; }
    }

    public class Repairable
    {
        public int Durability { get; set; }
        public int MaxDurability { get; set; }
    }

    public class RecodableComponent
    {
        public bool IsEncoded { get; set; }
    }

    public class MedKit
    {
        public int HpResource { get; set; }
    }

    public class Sight
    {
        public int[] ScopesCurrentCalibPointIndexes { get; set; }
        public int[] ScopesSelectedModes { get; set; }
        public int SelectedScope { get; set; }
    }

    public class Foldable
    {
        public bool Folded { get; set; }
    }

    public class FireMode
    {
        [JsonProperty("FireMode")]
        public string Fire_Mode { get; set; }
    }

    public class FoodDrink
    {
        public int HpPercent { get; set; }
    }

    public class Key
    {
        public int NumberOfUsages { get; set; }
    }

    public class Resource
    {
        public int Value { get; set; }
        public int UnitsConsumed { get; set; }
    }

    public class Light
    {
        public bool IsActive { get; set; }
        public int SelectedMode { get; set; }
    }

    public class DogTag
    {
        public string AccountId { get; set; }
        public string ProfileId { get; set; }
        public string Nickname { get; set; }
        public string Side { get; set; }
        public int Level { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
        public string KillerAccountId { get; set; }
        public string KillerProfileId { get; set; }
        public string KillerName { get; set;}
        public string WeaponName { get; set; }
    }

    public class Location
    {
        public float x { get; set; }
        public float y { get; set; }

        // string or number
        public object r { get; set; }
        public bool? isSearched { get; set; }

        // string or bool, SPT property
        public object? rotation { get; set; }
    }

    public class SideEffect
    {
        public float Value { get; set; }
    }

    public class RepairKit
    {
        public float Resource { get; set; }
    }

    public class CultistAmulet
    {
        public int NumberOfUsages { get; set; }
    }
}

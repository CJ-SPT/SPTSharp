#pragma warning disable 
using Newtonsoft.Json;
using SPTSharp.Converters;
using System.Numerics;

namespace SPTSharp.Models.Eft.Common.Tables
{
    public class BotType
    {
        public Appearance appearance {  get; set; }
        public Chances chances { get; set; }
        public Experience experience { get; set; }

        [JsonConverter(typeof(EmptyPropertyConverter))]
        public List<string> firstName { get; set; }

        [JsonConverter(typeof(EmptyPropertyConverter))]
        public List<string> lastName { get; set; }
        public Generation generation { get; set; }
        public BotHealth health { get; set; }
        public BotInventory inventory { get; set; }
        public BotSkills skills { get; set; }

    }

    // Clothing ID, weighting
    public class Appearance
    {
        [JsonConverter(typeof(EmptyPropertyConverter))]
        public Dictionary<string, int>? body { get; set; }

        [JsonConverter(typeof(EmptyPropertyConverter))]
        public Dictionary<string, int>? feet { get; set; }

        [JsonConverter(typeof(EmptyPropertyConverter))]
        public Dictionary<string, int>? hands { get; set; }
        
        [JsonConverter(typeof(EmptyPropertyConverter))]
        public Dictionary<string, int>? head { get; set; }
        
        [JsonConverter(typeof(EmptyPropertyConverter))]
        public Dictionary<string, int>? voice { get; set; }
    }

    public class Chances
    {
        public EquipmentChances equipment { get; set; }
        public ModsChances weaponMods { get; set; }
        public ModsChances equipmentMods { get; set; }
    }

    public class EquipmentChances
    {
        public int Armband { get; set; }
        public int ArmorVest { get; set; }
        public int Backpack { get; set; }
        public int Earpiece { get; set; }
        public int Eyewear { get; set; }
        public int FaceCover { get; set; }
        public int FirstPrimaryWeapon { get; set; }
        public int Headwear { get; set; }
        public int Holster { get; set; }
        public int Pockets { get; set; }
        public int Scabbard { get; set; }
        public int SecondPrimaryWeapon { get; set; }
        public int SecuredContainer { get; set; }
        public int TacticalVest { get; set; }
    }

    public class ModsChances
    {
        public int mod_charge { get; set; }
        public int mod_equipment { get; set; }
        public int mod_equipment_000 { get; set; }
        public int mod_equipment_001 { get; set; }
        public int mod_equipment_002 { get; set; }
        public int mod_flashlight { get; set; }
        public int mod_foregrip { get; set; }
        public int mod_launcher { get; set; }
        public int mod_magazine { get; set; }
        public int mod_mount { get; set; }
        public int mod_mount_000 { get; set; }
        public int mod_mount_001 { get; set; }
        public int mod_muzzle { get; set; }
        public int mod_nvg { get; set; }
        public int mod_pistol_grip { get; set; }
        public int mod_reciever { get; set; }
        public int mod_scope { get; set; }
        public int mod_scope_000 { get; set; }
        public int mod_scope_001 { get; set; }
        public int mod_scope_002 { get; set; }
        public int mod_scope_003 { get; set; }
        public int mod_sight_front { get; set; }
        public int mod_sight_rear { get; set; }
        public int mod_stock { get; set; }
        public int mod_stock_000 { get; set; }
        public int mod_stock_akms { get; set; }
        public int mod_tactical { get; set; }
        public int mod_tactical_000 { get; set; }
        public int mod_tactical_001 { get; set; }
        public int mod_tactical_002 { get; set; }
        public int mod_tactical_003 { get; set; }
        public int mod_handguard { get; set; }
    }

    public class Difficulties
    {
        public Difficulty easy { get; set; }
        public Difficulty normal { get; set; }
        public Difficulty hard { get; set; }
        public Difficulty impossible { get; set; }
    }

    // string | string[] | int | float | bool
    public class Difficulty
    {
        public Dictionary<string, object> Aiming { get; set; }
        public Dictionary<string, object> Boss { get; set; }
        public Dictionary<string, object> Change { get; set; }
        public Dictionary<string, object> Core { get; set; }
        public Dictionary<string, object> Cover { get; set; }
        public Dictionary<string, object> Grenade { get; set; }
        public Dictionary<string, object> Hearing { get; set; }
        public Dictionary<string, object> Lay { get; set; }
        public Dictionary<string, object> Look { get; set; }
        public Dictionary<string, object> Mind { get; set; }
        public Dictionary<string, object> Move { get; set; }
        public Dictionary<string, object> Patrol { get; set; }
        public Dictionary<string, object> Scattering { get; set; }
        public Dictionary<string, object> Shoot { get; set; }
    }

    public class Experience
    {
        public float agressorBonus { get; set; }
        public MinMax level { get; set; }
        public MinMax reward { get; set; }
        public float standingForKill { get; set; }
    }

    public class Generation
    {
        public GenerationWeightingItems items { get; set; }
    }

    public class GenerationWeightingItems
    {
        public GenerationData grenades { get; set; }
        public GenerationData healing { get; set; }
        public GenerationData drugs { get; set; }
        public GenerationData stims { get; set; }
        public GenerationData backpackLoot { get; set; }
        public GenerationData pocketLoot { get; set; }
        public GenerationData vestLoot { get; set; }
        public GenerationData magazines { get; set; }
        public GenerationData specialItems { get; set; }
    }

    public class GenerationData
    {
        /** key: number of items, value: weighting */
        public Dictionary<string, int> weights { get; set; }

        /** Array of item tpls */
        public List<string> whitelist { get; set; }
    }

    public class BotHealth
    {
        public List<BotBodyPart> bodyParts { get; set; }
        public MinMax Energy { get; set; }
        public MinMax Hydration { get; set; }
        public MinMax Temperature { get; set; }
    }

    public class BotBodyPart
    {
        public MinMax Chest { get; set; }
        public MinMax Head { get; set; }
        public MinMax LeftArm { get; set; }
        public MinMax LeftLeg { get; set; }
        public MinMax RightArm { get; set; }
        public MinMax RightLeg { get; set; }
        public MinMax Stomach { get; set; }
    }

    public class BotInventory
    {
        public BotEquipment equipment { get; set; }
        public Dictionary<string, Dictionary<string, int>> Ammo { get; set; }
        public BotItems items { get; set; }

        // { weapon, { weapon_mod_type, list_of_parts } }
        public Dictionary<string, Dictionary<string, List<string>>> mods { get; set; }
    }

    public class BotEquipment
    {
        [JsonConverter(typeof(EmptyPropertyConverter))]
        public Dictionary<string, int> ArmBand { get; set; }

        [JsonConverter(typeof(EmptyPropertyConverter))]
        public Dictionary<string, int> ArmorVest { get; set; }

        [JsonConverter(typeof(EmptyPropertyConverter))]
        public Dictionary<string, int> Backpack { get; set; }

        [JsonConverter(typeof(EmptyPropertyConverter))]
        public Dictionary<string, int> Earpiece { get; set; }

        [JsonConverter(typeof(EmptyPropertyConverter))]
        public Dictionary<string, int> Eyewear { get; set; }

        [JsonConverter(typeof(EmptyPropertyConverter))]
        public Dictionary<string, int> FaceCover { get; set; }

        [JsonConverter(typeof(EmptyPropertyConverter))]
        public Dictionary<string, int> FirstPrimaryWeapon { get; set; }

        [JsonConverter(typeof(EmptyPropertyConverter))]
        public Dictionary<string, int> Headwear { get; set; }

        [JsonConverter(typeof(EmptyPropertyConverter))]
        public Dictionary<string, int> Holster { get; set; }

        [JsonConverter(typeof(EmptyPropertyConverter))]
        public Dictionary<string, int> Pockets { get; set; }

        [JsonConverter(typeof(EmptyPropertyConverter))]
        public Dictionary<string, int> Scabbard { get; set; }

        [JsonConverter(typeof(EmptyPropertyConverter))]
        public Dictionary<string, int> SecondPrimaryWeapon { get; set; }

        [JsonConverter(typeof(EmptyPropertyConverter))]
        public Dictionary<string, int> SecuredContainer { get; set; }

        [JsonConverter(typeof(EmptyPropertyConverter))]
        public Dictionary<string, int> TacticalVest { get; set; }
    }

    public class BotItems
    {
        [JsonConverter(typeof(EmptyPropertyConverter))]
        public Dictionary<string, int> Backpack { get; set; }

        [JsonConverter(typeof(EmptyPropertyConverter))]
        public Dictionary<string, int> Pockets { get; set; }

        [JsonConverter(typeof(EmptyPropertyConverter))]
        public Dictionary<string, int> SecuredContainer { get; set; }

        [JsonConverter(typeof(EmptyPropertyConverter))]
        public Dictionary<string, int> SpecialLoot { get; set; }

        [JsonConverter(typeof(EmptyPropertyConverter))]
        public Dictionary<string, int> TacticalVest { get; set; }
    }

    public class BotSkills
    {
        public Dictionary<string, MinMax> Common { get; set; }
        public Dictionary<string, MinMax> Assault { get; set; }
        public Dictionary<string, MinMax> CovertMovement { get; set; }
        public Dictionary<string, MinMax> DMR { get; set; }
        public Dictionary<string, MinMax> Endurance { get; set; }
        public Dictionary<string, MinMax> Health { get; set; }
        public Dictionary<string, MinMax> Immunity { get; set; }
        public Dictionary<string, MinMax> LMG { get; set; }
        public Dictionary<string, MinMax> Metabolism { get; set; }
        public Dictionary<string, MinMax> Pistol { get; set; }
        public Dictionary<string, MinMax> ProneMovement { get; set; }
        public Dictionary<string, MinMax> RecoilControl { get; set; }
        public Dictionary<string, MinMax> SMG { get; set; }
        public Dictionary<string, MinMax> Shotgun { get; set; }
        public Dictionary<string, MinMax> Sniper { get; set; }
        public Dictionary<string, MinMax> Strength { get; set; }
        public Dictionary<string, MinMax> StressResistance { get; set; }
        public Dictionary<string, MinMax> Throwing { get; set; }
        public Dictionary<string, MinMax> Vitality { get; set; }
    }
}

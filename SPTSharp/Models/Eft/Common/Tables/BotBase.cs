#pragma warning disable
using Newtonsoft.Json;
using SPTSharp.Models.Eft.Ragfair;
using SPTSharp.Models.Enums;
using System.Data;

namespace SPTSharp.Models.Eft.Common.Tables
{
    public class BotBase : ICloneable
    {
        public object Clone()
        {
            return new BotBase
            {
                _id = this._id,
                sessionId = this.sessionId,
                savage = this.savage,
                Info = this.Info,
                Customization = this.Customization,
                Health = this.Health,
                Inventory = this.Inventory,
                Skills = this.Skills,
                Stats = this.Stats,
                Encyclopedia = this.Encyclopedia,
                TaskConditionCounters = this.TaskConditionCounters,
                InsuredItems = this.InsuredItems,
                Hideout = this.Hideout,
                Quests = this.Quests,
                TradersInfo = this.TradersInfo,
                UnlockedInfo = this.UnlockedInfo,
                RagfairInfo = this.RagfairInfo,
                Achievements = this.Achievements,
                RepeatableQuests = this.RepeatableQuests,
                Bonuses = this.Bonuses,
                Notes = this.Notes,
                CarExtractCounts = this.CarExtractCounts,
                CoopExtractCounts = this.CoopExtractCounts,
                SurvivorClass = this.SurvivorClass,
                WishList = this.WishList,
                sptIsPmc = this.sptIsPmc,
            };
        }


        public string _id { get; set; }
        
        // Starts as a string, but is an int when saved.
        // When loaded from templates its value is __REPLACEME__
        public dynamic aid { get; set; }

        /** SPT property - use to store player id - TODO - move to AID ( account id as guid of choice) */
        public string sessionId { get; set; }
        public string? savage { get; set; }
        public Info Info { get; set; }
        public Customization Customization { get; set; }
        public Health Health { get; set; }
        public Inventory Inventory { get; set; }
        public Skills Skills { get; set; }
        public Stats Stats { get; set; }
        public Dictionary<string, bool> Encyclopedia { get; set; }
        public Dictionary<string, TaskConditionCounter> TaskConditionCounters { get; set; }
        public InsuredItem[] InsuredItems { get; set; }
        public Hideout Hideout { get; set; }
        public QuestStatus[] Quests { get; set; }
        public Dictionary<string, TraderInfo> TradersInfo { get; set; }
        public UnlockedInfo UnlockedInfo { get; set; }
        public RagfairInfo RagfairInfo { get; set; }

        /** Achievement id and timestamp */
        public Dictionary<string, int> Achievements { get; set; }
        public PmcDataRepeatableQuest[] RepeatableQuests { get; set; }
        public Bonus[] Bonuses { get; set; }
        public Notes Notes { get; set; }
        public Dictionary<string, int> CarExtractCounts { get; set; }
        public Dictionary<string, int> CoopExtractCounts { get; set; }
        public SurvivorClass SurvivorClass { get; set; }
        public string[] WishList { get; set; }

        /** SPT specific property used during bot generation in raid */
        public bool? sptIsPmc { get; set; }
    }

    public class TaskConditionCounter
    {
        public string id { get; set; }
        public string type { get; set; }
        public int value { get; set; }

        // Quest Id
        public string sourceId { get; set; }
    }

    public class UnlockedInfo
    {
        public string[] unlockedProductionRecipe { get; set; }
    }

    public class Info
    {
        public string EntryPoint { get; set; }
        public string Nickname { get; set; }
        public string LowerNickname { get; set; }
        public string Side { get; set; }
        public bool SquadInviteRestriction { get; set; }
        public bool HasCoopExtension { get; set; }
        public string Voice { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public dynamic RegistrationDate { get; set; }
        public string GameVersion { get; set; }
        public int AcountType { get; set; }
        public EMemberCategory MemberCategory { get; set; }
        public bool lockedMoveCommands { get; set; }
        public int SavageLockTime { get; set; }
        public int LastTimePlayedAsSavage { get; set; }
        public Settings Settings { get; set; }
        public int NicknameChangeDate { get; set; }
        public object[] NeedWipeOptions { get; set; }
        public LastCompleted lastCompleteWipe { get; set; }
        public Ban[] Bans { get; set; }
        public bool BannedState { get; set; }
        public int BannedUntil { get; set; }
        public bool IsStreamerModeAvailable { get; set; }
        public LastCompleted? lastCompletedEvent { get; set; }

    }

    public class Settings
    {
        public string BotDifficulty { get; set; }
        public int Experience { get; set; }
        public string Role { get; set; }
        public int AggressorBonus { get; set; }
        public int StandingForKill { get; set; }
    }

    public class Ban
    {
        public BanType type { get; set; }
        public int dateTime { get; set; }

    }

    public enum BanType
    {
        CHAT = 0,
        RAGFAIR = 1,
        VOIP = 2,
        TRADING = 3,
        ONLINE = 4,
        FRIENDS = 5,
        CHANGE_NICKNAME = 6
    }

    public class Customization
    {
        public string Head { get; set; }
        public string Body { get; set; }
        public string Feet { get; set; }
        public string Hands { get; set; }
    }

    public class Health
    {
        public CurrentMax Hydration { get; set; }
        public CurrentMax Energy { get; set; }
        public CurrentMax Temperature { get; set; }
        public BodyPartsHealth BodyParts { get; set; }
        public int UpdateTime { get; set; }
    }

    public class BodyPartsHealth
    {
        public BodyPartHealth Head { get; set; }
        public BodyPartHealth Chest { get; set; }
        public BodyPartHealth Stomach { get; set; }
        public BodyPartHealth LeftArm { get; set; }
        public BodyPartHealth RightArm { get; set; }
        public BodyPartHealth LeftLeg { get; set; }
        public BodyPartHealth RightLeg { get; set; }
    }

    public class BodyPartHealth
    {
        public CurrentMax Health { get; set; }
        public Dictionary<string, BodyPartEffectProperties>? Effects { get; set; }
    }

    public class BodyPartEffectProperties
    {
        public int Time { get; set; }
    }

    public class CurrentMax
    {
        public float Current { get; set; }
        public float Maximum { get; set; }
    }

    public class Inventory
    {
        public Item[] items { get; set; }
        public string equipment { get; set; }
        public string stash { get; set; }
        public string sortingTable { get; set; }
        public string questRaidItems { get; set; }
        public string questStashItems { get; set; }
        // Key is hideout area enum numeric as string e.g. "24", value is area _id
        public Dictionary<string, string> hideoutAreaStashes { get; set; }
        public Dictionary<string, string> fastPanel { get; set; }
        public string[] favoriteItems { get; set; }
    }

    public class BaseJsonSkills
    {
        public Dictionary<string, Common> Common { get; set; }
        public Dictionary<string, Mastering> Mastering { get; set; }
        public int points { get; set; }
    }

    public class Skills
    {
        public Common[] Common { get; set; }
        public Mastering[] Mastering { get; set; }
        public int Points { get; set; }
    }

    public class BaseSkill
    {
        public string Id { get; set; }
        public float Progress { get; set; }
        public int? max { get; set; }
        public int? min { get; set; }
    }

    public class Common : BaseSkill
    {
        public float? PointsEarnedDuringSession { get; set; }
        public int? LastAccess { get; set; }
    }

    public class Mastering : BaseSkill
    {
        // Intentionally empty
    }

    public class Stats
    {
        public EftStats Eft { get; set; }
    }

    public class EftStats
    {
        public string[] CarriedQuestItems { get; set; }
        public Victim[] Victims { get; set; }
        public int TotalSessionExperience { get; set; }
        public int LastSessionDate { get; set; }
        public SessionCounters SessionCounters { get; set; }
        public OverallCounters OverallCounters { get; set; }
        public float? SessionExperienceMult { get; set; }
        public float? ExperienceBonusMult { get; set; }
        public Agressor? Agressor { get; set; }
        public DroppedItem[]? DroppedItems { get; set; }
        public FoundInRaidItem[]? FoundInRaidItems { get; set; }
        public DamageHistory? DamageHistory { get; set; }
        public DeathCause? DeathCause { get; set; }
        public LastPlayerState? LastPlayerState { get; set; }
        public string? SurvivorClass { get; set; }
    }

    public class DroppedItem
    {
        public string QuestId { get; set; }
        public string ItemId { get; set; }
        public string ZoneId { get; set; }
    }

    public class FoundInRaidItem
    {
        public string QuestId { get; set; }
        public string ItemId { get; set; }
    }

    public class Victim
    {
        public string AccountId { get; set; }
        public string ProfileId { get; set; }
        public string Name { get; set; }
        public string Side { get; set; }
        public string BodyPart { get; set; }
        public string Time { get; set; }
        public float Distance { get; set; }
        public int Level { get; set; }
        public string Weapon { get; set; }
        public string Role { get; set; }
    }

    public class SessionCounters
    {
        public CounterKeyValue[] Items { get; set; }
    }

    public class OverallCounters
    {
        public CounterKeyValue[] Items { get; set; }
    }

    public class CounterKeyValue
    {
        public string[] Key { get; set; }
        public float Value { get; set; }
    }

    public class Agressor
    {
        public string AccountId { get; set; }
        public string ProfileId { get; set; }
        public string MainProfileNickname { get; set; }
        public string Name { get; set; }
        public string Side { get; set; }
        public string BodyPart { get; set; }
        public string HeadSegment { get; set; }
        public string WeaponName { get; set; }
        public string Category { get; set; }
    }

    public class DamageHistory
    {
        public string LethalDamagePart { get; set; }
        public LethalDamage LethalDamage { get; set; }
        public BodyPartsDamageHistory[] BodyParts { get; set; }
    }

    public class LethalDamage
    {
        public float Amount { get; set; }
        public string Type { get; set; }
        public string SourceId { get; set; }
        public string OverDamageFrom { get; set; }
        public bool Blunt { get; set; }
        public int ImpactsCount { get; set; }
    }

    public class BodyPartsDamageHistory
    {
        public DamageStats[] Head { get; set; }
        public DamageStats[] Chest { get; set; }
        public DamageStats[] Stomach { get; set; }
        public DamageStats[] LeftArm { get; set; }
        public DamageStats[] RightArm { get; set; }
        public DamageStats[] LeftLeg { get; set; }
        public DamageStats[] RightLeg { get; set; }
        public DamageStats[] Common { get; set; }
    }

    public class DamageStats
    {
        public float Amount { get; set; }
        public string Type { get; set; }
        public string SourceId { get; set; }
        public string OverDamageFrom { get; set; }
        public bool Blunt { get; set; }
        public int ImpactsCount { get; set; }
    }

    public class DeathCause
    {
        public string DamageType { get; set; }
        public string Side { get; set; }
        public string Role { get; set; }
        public string WeaponId { get; set; }
    }

    public class LastPlayerState
    {
        public LastPlayerStateInfo Info { get; set; }
        public Dictionary<string, string> Customization { get; set; }
        public object Equipment { get; set; }
    }

    public class LastPlayerStateInfo
    {
        public string Nickname { get; set; }
        public string Side { get; set; }
        public int Level { get; set; }
        public EMemberCategory MemberCategory { get; set; }
    }

    public class BackendCounter
    {
        public string id { get; set; }
        public string? qid { get; set; }
        public int number { get; set; }
    }

    public class InsuredItem
    {
        // Trader Id item was insured by
        public string tid { get; set; }
        public string itemId { get; set; }
    }

    public class Hideout
    {
        public Dictionary<string, Productive> Production { get; set; }
        public HideoutArea[] Areas { get; set; }
        public Dictionary<string, HideoutImprovement> Improvement { get; set; }
        public int Seed { get; set; }
        public int sptUpdateLastRunTimestamp { get; set; }
    }

    public class HideoutImprovement
    {
        public bool completed { get; set; }
        public int improveCompleteTimestamp { get; set; }
    }

    public class Productive
    {
        public Product[] Products { get; set; }
        
        // Seconds passed of production
        public int? Progress { get; set; }
        
        // Is craft in some state of being worked on by client (crafting/ready to pick up)
        public bool? inProgress { get; set; }
        public int? StartTimeStamp { get; set; }
        public int? SkipTime { get; set; }

        // Seconds needed to fully craft
        public int? ProductiveTime { get; set; }
        public string[]? GivenItemsInStart { get; set; }
        public bool? Interrupted { get; set; }

        // Used in hideout production.json
        public bool? needFuelForAllProductionTime { get; set; }

        // Used when sending data to client
        public bool? NeedFuelForAllProductionTime { get; set; }
        public bool? sptIsScavCase { get; set; }

        // Some crafts are always inProgress, but need to be reset, e.g. water collector
        public bool? sptIsComplete { get; set; }

        // Is the craft a Continuous, e.g bitcoins/water collector 
        public bool? sptIsContinuous { get; set; }

        // Stores a list of tools used in this craft and whether they're FiR, to give back once the craft is done
        public Item[]? sptRequiredTools { get; set; }
    }

    public class Production : Productive
    {
        public string RecipeId { get; set; }
        public int SkipTime { get; set; }
        public int ProductionTime { get; set; }
    }

    public class ScavCase : Productive
    {
        public string RecipeId { get; set; }
    }

    public class Product
    {
        public string _id { get; set; }
        public string _tpl { get; set; }
        public Upd? upd { get; set; }
    }

    public class HideoutArea
    {
        public EHideoutAreas type { get; set; }
        public int level { get; set; }
        public bool active { get; set; }
        public bool passiveBonusesEnabled {  get; set; }
        public int completeTime { get; set; }
        public bool constructing { get; set; }
        public HideoutSlot[] slots { get; set; }
        public string lastRecipe {  get; set; }
    }

    public class HideoutSlot
    {
        public int locationIndex { get; set; }
        public HideoutItem[]? items { get; set; }
    }

    public class HideoutItem
    {
        public string _id { get; set; }
        public string _tpl { get; set; }
        public Upd? upd { get; set; }
    }

    public class LastCompleted
    {
        [JsonProperty("$oid")]
        public string oid { get; set;}
    }

    public class Notes
    {
        [JsonProperty("Notes")]
        public Note[] notes { get; set; }
    }

    public class CarExtractCounts
    {
        // Intentionally empty
    }

    public enum SurvivorClass
    {
        UNKNOWN = 0,
        NEUTRALIZER = 1,
        MARAUDER = 2,
        PARAMEDIC = 3,
        SURVIVOR = 4
    }

    public class QuestStatus
    {
        public string qid { get; set; }
        public int startTime { get; set; }
        public EQuestStatus status { get; set; }
        public Dictionary<string, int>? statusTimers { get; set; }
        public string[]? completedConditions { get; set; }
        public int? availableAfter { get; set; }
    }

    public class TraderInfo
    {
        public int loyaltyLevel { get; set; }
        public int salesSum { get; set; }
        public float standing { get; set; }
        public int nextResupply { get; set; }
        public bool unlocked { get; set; }
        public bool disabled { get; set; }
    }

    public class RagfairInfo
    {
        public float rating { get; set; }
        public bool isRatingGrowing { get; set; }
        public RagfairOffer[] offers { get; set; }
    }

    public class Bonus
    {
        public string? id { get; set; }

        // EBonusType string hack!
        public string type { get; set; }
        public string? templateId { get; set; }
        public bool? passive { get; set; }
        public bool? production { get; set; }
        public bool? visible { get; set; }
        public int? value { get; set; }
        public string? icon { get; set; }
        public string[]? filter { get; set; }

        // EBonusSkillType string hack!
        public string? skillType { get; set; }
    }

    public class Note
    {
        public int Time { get; set; }
        public string Text { get; set; }
    }
}

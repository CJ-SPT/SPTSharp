#pragma warning disable

namespace SPTSharp.Models.Eft.Common.Tables
{
    public class Quest
    {
        /// <summary>
        /// SPT addition - human readable quest name
        /// </summary>
        public string QuestName { get; set; }

        public string _id { get; set; }
        public bool canShowNotificationsInGame { get; set; }
        public QuestConditionTypes conditions { get; set; }
        public string description { get; set; }
        public string failMessageText { get; set; }
        public string name { get; set; }
        public string note { get; set; }
        public string traderId { get; set; }
        public string location { get; set; }
        public string image { get; set; }

        // EQuestTypeEnum, string hack!
        public string type { get; set; }
        public bool isKey { get; set; }

        /// deprecated - Likely not used, use 'status' instead
        public QuestStatus questStatus { get; set; }
        public bool restartable { get; set; }
        public bool instantComplete { get; set; }
        public bool secretQuest { get; set; }
        public string startedMessageText { get; set; }
        public string successMessageText { get; set; }
        public string acceptPlayerMessage { get; set; }
        public string declinePlayerMessage { get; set; }
        public string completePlayerMessage { get; set; }
        public string templateId { get; set; }
        public QuestRewards rewards { get; set; }

        /// Becomes 'AppearStatus' inside client
        public string status { get; set; }
        public bool KeyQuest { get; set; }
        public string changeQuestMessageText { get; set; }

        /// "Pmc" or "Scav"
        public string side { get; set; }

        /// Status of quest to player
        public QuestStatus sptStatus { get; set; }
    }

    public class QuestConditionTypes
    {
        QuestCondition[] Started { get; set; }
        QuestCondition[] AvailableForFinish { get; set; }
        QuestCondition[] AvailableForStart { get; set; }
        QuestCondition[] Success { get; set; }
        QuestCondition[] Fail { get; set; }
    }

    public class QuestCondition
    {
        public string id { get; set; }
        public int? index { get; set; }
        public string compareMethod { get; set; }
        public bool dynamicLocale { get; set; }
        public VisibilityCondition[] visibilityConditions { get; set; }
        public string globalQuestCounterId { get; set; }
        public string parentId { get; set; }
        public string[] target { get; set; }
        public string value { get; set; }
        public bool type { get; set; }
        public QuestStatus[] status { get; set; }
        public int? availableAfter { get; set; }
        public int? dispersion { get; set; }
        public bool onlyFoundInRaid { get; set; }
        public bool oneSessionOnly { get; set; }
        public bool doNotResetIfCounterCompleted { get; set; }
        public int? dogtagLevel { get; set; }
        public int? maxDurability { get; set; }
        public int? minDurability { get; set; }
        public QuestConditionCounter counter { get; set; }
        public int? plantTime { get; set; }
        public string zoneId { get; set; }
        public bool countInRaid { get; set; }
        public int? completeInSeconds { get; set; }
        public bool isEncoded { get; set; }
        public string conditionType { get; set; }
    }

    public class QuestConditionCounter
    {
        public string id { get; set; }
        public QuestConditionCounterCondition[] conditions { get; set; }
    }

    public class QuestConditionCounterCondition
    {
        public string id { get; set; }
        public bool dynamicLocale { get; set; }
        public string[] target { get; set; } // TODO: some objects have an array and some are just strings, thanks bsg very cool
        public int? completeInSeconds { get; set; }
        public ValueCompare energy { get; set; }
        public string exitName { get; set; }
        public ValueCompare hydration { get; set; }
        public ValueCompare time { get; set; }
        public string compareMethod { get; set; }
        public int? value { get; set; }
        public string[] weapon { get; set; }
        public CounterConditionDistance distance { get; set; }
        public string[][] equipmentInclusive { get; set; }
        public string[][] weaponModsInclusive { get; set; }
        public string[][] weaponModsExclusive { get; set; }
        public string[][] enemyEquipmentInclusive { get; set; }
        public string[][] enemyEquipmentExclusive { get; set; }
        public string[] weaponCaliber { get; set; }
        public string[] savageRole { get; set; }
        public string[] status { get; set; }
        public string[] bodyPart { get; set; }
        public DaytimeCounter daytime { get; set; }
        public string conditionType { get; set; }
        public EnemyHealthEffect[] enemyHealthEffects { get; set; }
        public bool resetOnSessionEnd { get; set; }
    }

    public class EnemyHealthEffect
    {
        public string[] bodyParts { get; set; }
        public string[] effects { get; set; }
    }

    public class ValueCompare
    {
        public string compareMethod { get; set; }
        public int value { get; set; }
    }

    public class CounterConditionDistance
    {
        public int value { get; set; }
        public string compareMethod { get; set; }
    }

    public class DaytimeCounter
    {
        public int from { get; set; }
        public int to { get; set; }
    }

    public class VisibilityCondition
    {
        public string id { get; set; }
        public string target { get; set; }
        public int? value { get; set; }
        public bool dynamicLocale { get; set; }
        public bool oneSessionOnly { get; set; }
        public string conditionType { get; set; }
    }

    public class QuestRewards
    {
        public QuestReward[] AvailableForStart { get; set; }
        public QuestReward[] AvailableForFinish { get; set; }
        public QuestReward[] Started { get; set; }
        public QuestReward[] Success { get; set; }
        public QuestReward[] Fail { get; set; }
        public QuestReward[] FailRestartable { get; set; }
        public QuestReward[] Expired { get; set; }
    }

    public class QuestReward
    {
        public string value { get; set; }
        public string id { get; set; }

        // EQuestRewardType, String hack!
        public string type { get; set; }
        public int index { get; set; }
        public string target { get; set; }
        public Item[] items { get; set; }
        public int loyaltyLevel { get; set; }
        public string traderId { get; set; }
        public bool unknown { get; set; }
        public bool findInRaid { get; set; }
    }
}

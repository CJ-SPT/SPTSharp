#pragma warning disable 
namespace SPTSharp.Models.Eft.Common.Tables
{
    public class RepeatableQuest
    {
        public ChangeCost[] changeCosts { get; set; }
        public int changeStandingCost { get; set; }
        public string sptRepeatableGroupName { get; set; }
    }

    public class RepeatableQuestDatabase
    {
        public RepeatableTemplates templates { get; set; }
        public RewardOptions rewards { get; set; }
        public Options data { get; set; }
        public SampleQuests[] samples { get; set; }
    }

    public class RepeatableTemplates
    {
        public Quest Elimination { set; get; }
        public Quest Completion { set; get; }
        public Quest Exploration { set; get; }
    }

    public class PmcDataRepeatableQuest
    {
        public string? id { set; get; }
        public string name { set; get; }
        public RepeatableQuest[] activeQuests { set; get; }
        public RepeatableQuest[] inactiveQuests { set; get; }
        public int endTime { set; get; }

        // What it costs to reset <QuestId, ChangeRequirement> redundant to change requirements within IRepeatableQuest
        public Dictionary<string, ChangeRequirement> changeRequirement { set; get; }
    }

    public class ChangeRequirement
    {
        public ChangeCost[] changeCost { set; get; }
        public float changeStandingCost { set; get; }
    }

    public class ChangeCost
    {
        // what item it will take to reset daily
        public string templateId { set; get; }

        // amount of item needed to reset
        public int count { set; get; }
    }

    // Config Options

    public class RewardOptions
    {
        public string[] itemsBlacklist { set; get; }
    }

    public class Options
    {
        public CompletionFilter Completion { set; get; }
    }

    public class CompletionFilter
    {
        public ItemsBlackList[] itemsBlackLists { set; get; }
        public ItemsWhiteList[] itemsWhiteLists { set; get; }

    }

    public class ItemsBlackList
    {
        public int minPlayerLevel { set; get; }
        public string[] itemIds { set; get; }
    }

    public class ItemsWhiteList
    {
        public int minPlayerLevel { set; get; }
        public string[] itemIds { set; get; }
    }

    public class SampleQuests
    {
        public string _id { set; get; }
        public string traderId { set; get; }
        public string location { set; get; }
        public string image {  set; get; }
        public string type { set; get; }
        public bool isKey { set; get; }
        public bool restartable { set; get; }
        public bool instantComplete { set; get; }
        public bool secretQuest { set; get; }
        public bool canShowNotificationsInGame { set; get; }
        public QuestRewards rewards { set; get; }
        public QuestConditionTypes conditions { set; get; }
        public string name { set; get; }
        public string note { set; get; }
        public string description { set; get; }
        public string successMessageText { set; get; }
        public string failMessageText { set; get; }
        public string startedMessageText { set; get; }
        public string templateId { set; get; }
    }
}

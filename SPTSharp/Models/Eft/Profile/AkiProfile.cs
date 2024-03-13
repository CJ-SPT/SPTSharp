using Newtonsoft.Json;
using SPTSharp.Models.Eft.Common;
using SPTSharp.Models.Eft.Common.Tables;
using SPTSharp.Models.Enums;
using SPTSharp.Models.Spt.Dialog;

#pragma warning disable

namespace SPTSharp.Models.Eft.Profile
{
    public class AkiProfile
    {
        public Info info { get; set; }
        public Characters characters { get; set; }

        /** Clothing purchases */
        public string[] suits { get; set; }
        public Dictionary<string, Dialogue> dialogues { get; set; }
        public Aki aki { get; set; }
        public Vitality vitality { get; set; }
        public Inraid inraid { get; set; }
        public Insurance[] insurances { get; set; }

        /** Assort purchases made by player since last trader refresh */
        public Dictionary<string, Dictionary<string, TraderInfo>>? traders { get; set; }

        /** Achievements earned by player */
        public Dictionary<string, int> achievements { get; set; }
    }

    public class TraderPurchaseData
    {
        public int count { get; set; }
        public int purchaseTimestamp { get; set; }
    }

    public class Info
    {
        /** main profile id */
        public string id { get; set; }
        public string scavId { get; set; }
        public int aid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool wipe { get; set; }
        public string edition { get; set; }
    }

    public class Characters
    {
        public PmcData pmc {  get; set; }
        public PmcData scav { get; set; }
    }

    public class UserBuilds
    {
        public WeaponBuild[] weaponBuilds { get; set; }
        public EquipmentBuild[] equipmentBuilds { get; set; }
        public MagazineBuild[] magazineBuilds { get; set; }
    }

    public class UserBuild
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
       
    public class WeaponBuild : UserBuild
    {
        public string Root { get; set; }
        public Item[] Items { get; set; }
    }

    public class EquipmentBuild : UserBuild 
    {
        public string Root { get; set; }
        public Item[] Items { get; set; }
        public EEquipmentBuildType buildType { get; set; }
    }

    public class MagazineBuild : UserBuild 
    { 
        public string Caliber { get; set; }
        public int TopCount { get; set; }
        public int BottomCount { get; set; }
        public MagazineTemplateAmmoItem[] Items { get; set; }
    }

    public class MagazineTemplateAmmoItem
    {
        public string TemplateId { get; set; }
        public int Count { get; set; }
    }

    public class DefaultEquipmentPreset : UserBuild
    {
        public Item[] Items { get; set; }
        public string Root { get; set; }
        public EEquipmentBuildType BuildType { get; set; }
        public string type { get; set; }
    }

    public class Dialogue
    {
        public int attachmentsNew { get; set; }

        [JsonProperty("new")] // new is a keyword in c#
        public int newMessages { get; set; } 
        public EMessageType type { get; set; }
        public UserDialogInfo[]? Users { get; set; }
        public bool pinned { get; set; }
        public Message[] messages { get; set; }
        public string _id { get; set; }
    }

    public class UserDialogInfo
    {
        public string _id { get; set; }
        public int aid { get; set; }

        public UserDialogDetails Info { get; set; }
    }

    public class UserDialogDetails
    {
        public string Nickname { get; set; }
        public string Side { get; set; }
        public int Level { get; set; }

        // EMemberCategory string hack!
        public string MemberCategory { get; set; }
    }

    public class DialogueInfo
    {
        public int attachmentsNew { get; set; }

        [JsonProperty("new")] // new is a keyword in c#
        public int newMessages { get; set; }
        public string _id { get; set; }
        public EMessageType type { get; set; }
        public MessagePreview message { get; set; }
    }

    public class Message
    {
        public string _id { get; set; }
        public string uid { get; set; }
        public EMessageType type { get; set; }
        public int dt { get; set; }
        public int? UtcDateTime { get; set; }
        public UpdatableChatMember? Member { get; set; }
        public string? templateId { get; set; }
        public string? text { get; set; }
        public bool? hasRewards { get; set; }
        public bool rewardCollected { get; set; }
        public MessageItems? items { get; set; }
        public int? maxStorageTime {get; set; }
        public SystemData? systemData { get; set; }
        public ProfileChangeEvent[]? profileChangeEvents { get; set; } 
    }

    public class MessagePreview
    {
        public string uid { get; set; }
        public EMessageType type { get; set; }
        public int dt { get; set; }
        public string templateId { get; set; }
        public string? text { get; set; }
        public SystemData? systemData { get; set; }
    }

    public class MessageItems
    {
        public string? stash { get; set; }
        public Item[]? data { get; set; }
    }

    public class SystemData
    {
        public string? date { get; set; }
        public string? time { get; set; }
        public string? location { get; set; }
        public string? buyerNickname { get; set; }
        public string? soldItem { get; set; }
        public int? itemCount { get; set; }
    }

    public class UpdatableChatMember
    {
        public string NickName { get; set; }
        public string Side { get; set; }
        public int Level { get; set; }

        //EMemberCategory string hack!
        public string MemberCategory { get; set; }
        public bool Ingored { get; set; }
        public bool Banned { get; set; }
    }

    public class DateTime
    {
        public string date { get; set; }
        public string time { get; set; }
    }

    public class Aki
    {
        public string version { get; set; }
        public ModDetails[]? mods { get; set; }
        public RecievedGift[] recievedGifts { get; set; }
    }

    public class ModDetails 
    { 
        public string name { get; set; }
        public string version { get; set; }
        public string author { get; set; }
        public int dateAdded { get; set; }
        public string url { get; set; }
    }

    public class RecievedGift
    {
        public string giftId { get; set; }
        public int timestampAccepted { get; set; }
    }

    public class Vitality
    {
        public Health health { get; set; }
        public Effects effects { get; set; }
    }

    public class Health
    {
        public float Hydration { get; set; }
        public float Energy { get; set; }
        public float Temperature { get; set; }
        public int Head {  get; set; }
        public int Chest { get; set; }
        public int Stomach { get; set; }
        public int LeftArm { get; set; }
        public int RightArm { get; set; }
        public int LeftLeg { get; set; }
        public int RightLeg { get; set; }
    }

    public class Effects
    {
        public Head Head { get; set; }
        public Chest Chest { get; set; }
        public Stomach Stomach { get; set; }
        public LeftArm LeftArm { get; set; }
        public RightArm RightArm { get; set; }
        public LeftLeg LeftLeg { get; set; }
        public RightLeg RightLeg { get; set; }
    }

    // Intentionally empty
    public class Head { }
    public class Chest { }
    public class Stomach { }
    
    public class LeftArm 
    { 
        public int? Fracture { get; set; }
    }
    
    public class RightArm
    {
        public int? Fracture { get; set; }
    }
    
    public class LeftLeg
    {
        public int? Fracture { get; set; }
    }
    
    public class RightLeg
    {
        public int? Fracture { get; set; }
    }

    public class Inraid
    {
        public string location { get; set; }
        public string character { get; set; }
    }

    public class Insurance
    {
        public int scheduledTime {  get; set; }
        public string traderId { get; set; }
        public int maxStorageTime {  get; set; }
        public SystemData systemData { get; set; }
        public EMessageType messageType { get; set; }
        public Item[] items { get; set; }
    }

    public class MessageContentRagfair
    {
        public string offerId { get; set; }
        public int count { get; set; }
        public string handbookId { get; set; }
    }
}

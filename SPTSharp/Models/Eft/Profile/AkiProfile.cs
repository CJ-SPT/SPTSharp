using Newtonsoft.Json;
using SPTSharp.Models.Eft.Common;
using SPTSharp.Models.Eft.Common.Tables;
using SPTSharp.Models.Eft.Launcher;
using SPTSharp.Models.Enums;
using SPTSharp.Models.Spt.Dialog;

#pragma warning disable

namespace SPTSharp.Models.Eft.Profile
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class AkiProfile : ICloneable
    {
        public object Clone()
        {
            return new AkiProfile
            {
                info = this.info,
                characters = this.characters,
                suits = this.suits,
                dialogues = this.dialogues,
                aki = this.aki,
                vitality = this.vitality,
                inraid = this.inraid,
                insurances = this.insurances,
                traders = this.traders,
                achievements = this.achievements,
            };
        }

        public Info info { get; set; }
        public Characters characters { get; set; }

        /** Clothing purchases */
        public List<string> suits { get; set; }
        public Dictionary<string, Dialogue> dialogues { get; set; }
        public Aki aki { get; set; }
        public Vitality vitality { get; set; }
        public Inraid inraid { get; set; }
        public List<Insurance> insurances { get; set; }

        /** Assort purchases made by player since last trader refresh */
        public Dictionary<string, Dictionary<string, TraderInfo>>? traders { get; set; }

        /** Achievements earned by player */
        public Dictionary<string, int> achievements { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class TraderPurchaseData
    {
        public int count { get; set; }
        public int purchaseTimestamp { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
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

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Characters
    {
        public PmcData pmc { get; set; } = new PmcData();
        public PmcData scav { get; set; } = new PmcData();
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class UserBuilds
    {
        public List<WeaponBuild> weaponBuilds { get; set; }
        public List<EquipmentBuild> equipmentBuilds { get; set; }
        public List<MagazineBuild> magazineBuilds { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class UserBuild
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class WeaponBuild : UserBuild
    {
        public string Root { get; set; }
        public List<Item> Items { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class EquipmentBuild : UserBuild 
    {
        public string Root { get; set; }
        public Item[] Items { get; set; }
        public EEquipmentBuildType buildType { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class MagazineBuild : UserBuild 
    { 
        public string Caliber { get; set; }
        public int TopCount { get; set; }
        public int BottomCount { get; set; }
        public MagazineTemplateAmmoItem[] Items { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class MagazineTemplateAmmoItem
    {
        public string TemplateId { get; set; }
        public int Count { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class DefaultEquipmentPreset : UserBuild
    {
        public List<Item> Items { get; set; }
        public string Root { get; set; }
        public EEquipmentBuildType BuildType { get; set; }
        public string type { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Dialogue
    {
        public int attachmentsNew { get; set; }

        [JsonProperty("new")] // new is a keyword in c#
        public int newMessages { get; set; } 
        public EMessageType type { get; set; }
        public List<UserDialogInfo>? Users { get; set; }
        public bool pinned { get; set; }
        public List<Message> messages { get; set; }
        public string _id { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class UserDialogInfo
    {
        public string _id { get; set; }
        public int aid { get; set; }

        public UserDialogDetails Info { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class UserDialogDetails
    {
        public string Nickname { get; set; }
        public string Side { get; set; }
        public int Level { get; set; }

        // EMemberCategory string hack!
        public string MemberCategory { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class DialogueInfo
    {
        public int attachmentsNew { get; set; }

        [JsonProperty("new")] // new is a keyword in c#
        public int newMessages { get; set; }
        public string _id { get; set; }
        public EMessageType type { get; set; }
        public MessagePreview message { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
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
        public List<ProfileChangeEvent>? profileChangeEvents { get; set; } 
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class MessagePreview
    {
        public string uid { get; set; }
        public EMessageType type { get; set; }
        public int dt { get; set; }
        public string templateId { get; set; }
        public string? text { get; set; }
        public SystemData? systemData { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class MessageItems
    {
        public string? stash { get; set; }
        public List<Item>? data { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SystemData
    {
        public string? date { get; set; }
        public string? time { get; set; }
        public string? location { get; set; }
        public string? buyerNickname { get; set; }
        public string? soldItem { get; set; }
        public int? itemCount { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
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

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class DateTime
    {
        public string date { get; set; }
        public string time { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Aki
    {
        public string version { get; set; }
        public List<ModDetails>? mods { get; set; }
        public List<RecievedGift>? recievedGifts { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ModDetails 
    { 
        public string name { get; set; }
        public string version { get; set; }
        public string author { get; set; }
        public int dateAdded { get; set; }
        public string url { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class RecievedGift
    {
        public string giftId { get; set; }
        public int timestampAccepted { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Vitality
    {
        public Health health { get; set; } = new Health();
        public Effects effects { get; set; } = new Effects();
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Health
    {
        public float Hydration { get; set; } = 0f;
        public float Energy { get; set; } = 0f;
        public float Temperature { get; set; } = 0f;
        public int Head { get; set; } = 0;
        public int Chest { get; set; } = 0;
        public int Stomach { get; set; } = 0;
        public int LeftArm { get; set; } = 0;
        public int RightArm { get; set; } = 0;
        public int LeftLeg { get; set; } = 0;
        public int RightLeg { get; set; } = 0;
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
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
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Head { }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Chest { }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Stomach { }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class LeftArm 
    { 
        public int? Fracture { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class RightArm
    {
        public int? Fracture { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class LeftLeg
    {
        public int? Fracture { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class RightLeg
    {
        public int? Fracture { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Inraid
    {
        public string location { get; set; }
        public string character { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Insurance
    {
        public int scheduledTime {  get; set; }
        public string traderId { get; set; }
        public int maxStorageTime {  get; set; }
        public SystemData systemData { get; set; }
        public EMessageType messageType { get; set; }
        public List<Item> items { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class MessageContentRagfair
    {
        public string offerId { get; set; }
        public int count { get; set; }
        public string handbookId { get; set; }
    }
}

#pragma warning disable
using Newtonsoft.Json;
using SPTSharp.Models.Spt.Services;

namespace SPTSharp.Models.Eft.Common.Tables
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Trader
    {
        public TraderAssort? assort {  get; set; }

        [JsonProperty("base")]
        public TraderBase Base { get; set; }
        public Dictionary<string, string[]>? dialogue { get; set; }
        public QuestAssort? questAssort { get; set; }
        public List<Suit>? suits { get; set; }
        public List<TraderServiceModel>? traderServices { get; set; }

    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class QuestAssort
    {
        public Dictionary<string, string> started { get; set; }
        public Dictionary<string, string> success { get; set; }
        public Dictionary<string, string> fail { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class TraderBase
    {
        public bool refreshTraderRagfairOffers { get; set; }
        public string _id { get; set; }
        public bool availableInRaid { get; set; }
        public string avatar { get; set; }
        public int balance_dol { get; set; }
        public int balance_eur { get; set; }
        public int balance_rub { get; set; }
        public bool buyer_up { get; set; }
        public string currency { get; set; }
        public bool customization_seller { get; set; }
        public double discount { get; set; }
        public double discount_end { get; set; }
        public int gridHeight { get; set; }
        public Insurance insurance { get; set; }
        public ItemBuyData items_buy { get; set; }
        public ItemBuyData items_buy_prohibited { get; set; }
        public string location { get; set; }
        public LoyaltyLevel[] loyaltyLevels { get; set; }
        public bool medic { get; set; }
        public string name { get; set; }
        public double nextResupply { get; set; }
        public string nickname { get; set; }
        public Repair repair { get; set; }
        public string[] sell_category { get; set; }
        public string surname { get; set; }
        public bool unlockedByDefault { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ItemBuyData
    {
        public string[] category { get; set; }
        public string[] id_list { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Insurace
    {
        public bool availability { get; set; }
        public string[] excluded_category { get; set; }
        public double max_return_hour { get; set; }
        public double max_storage_time { get; set; }
        public double min_payment { get; set; }
        public double min_return_hour { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class LoyaltyLevel
    {
        public double buy_price_coef { get; set; }
        public double exchange_price_coef { get; set; }
        public double heal_price_coef { get; set; }
        public double insurance_price_coef { get; set; }
        public double minLevel { get; set; }
        public double minSalesSum { get; set; }
        public double minStanding { get; set; }
        public double repair_price_coef { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Repair
    {
        public bool availability { get; set; }
        public string currency { get; set; }
        public double currency_coefficient { get; set; }
        public string[] excluded_category { get; set; }
        public object[] excluded_id_list { get; set; } // Assuming it's a list of any type
        public double quality { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class TraderAssort
    {
        public double nextResupply { get; set; }
        public Item[] items { get; set; }
        public Dictionary<string, BarterScheme[][]> barter_scheme { get; set; }
        public Dictionary<string, double> loyal_level_items { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class BarterScheme
    {
        public double count { get; set; }
        public string _tpl { get; set; }
        public bool? onlyFunctional { get; set; }
        public bool? sptQuestLocked { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Suit
    {
        public string _id { get; set; }
        public string tid { get; set; }
        public string suiteId { get; set; }
        public bool isActive { get; set; }
        public SuitRequirements requirements { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SuitRequirements
    {
        public double loyaltyLevel { get; set; }
        public double profileLevel { get; set; }
        public double standing { get; set; }
        public string[] skillRequirements { get; set; }
        public string[] questRequirements { get; set; }
        public ItemRequirement[] itemRequirements { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ItemRequirement
    {
        public double count { get; set; }
        public string _tpl { get; set; }
        public bool onlyFunctional { get; set; }
    }
}

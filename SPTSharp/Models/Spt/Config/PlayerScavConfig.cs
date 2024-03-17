#pragma warning disable
using SPTSharp.Models.Eft.Common.Tables;

namespace SPTSharp.Models.Spt.Config
{
    public class PlayerScavConfig
    {
        public Dictionary<string, KarmaLevel> karmaLevel {  get; set; }
    }

    public class KarmaLevel
    {
        public string botTypeForLoot { get; set; }
        public Modifiers modifiers { get; set; }
        public ItemLimits itemLimits { get; set; }
        public Dictionary<string, List<string>> equipmentBlacklist { get; set; }
        public Dictionary<string, int> lootItemsToAddChancePercent { get; set; }
    }

    public class Modifiers
    {
        public Dictionary<string, int> equipment { get; set; }
        public Dictionary<string, int> mod {  get; set; }

    }

    public class ItemLimits
    {
        public GenerationData healing { get; set; }
        public GenerationData drugs { get; set; }
        public GenerationData stims { get; set; }
        public GenerationData looseLoot { get; set; }
        public GenerationData magazines { get; set; }
        public GenerationData grenades { get; set; }
    }
}

#pragma warning disable
using Newtonsoft.Json;

namespace SPTSharp.Models.Spt.Services
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class TraderServiceModel
    {
        //ETraderServiceType - String hack
        public string serviceType { get; set; }
        public Dictionary<string, int>? itemsToPay { get; set; }
        public string[]? subServices { get; set; }
        public TraderServiceRequirementModel? requirements { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class TraderServiceRequirementModel
    {
        public string[]? completedQuests { get; set; }
        public Dictionary<string, float>? standings { get; set; }
    }
}

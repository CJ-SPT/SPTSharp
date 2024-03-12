#pragma warning disable
using SPTSharp.Models.Eft.Common.Tables;

namespace SPTSharp.Models.Eft.Common
{
    public class PmcData : BotBase
    {
        // Intentionally empty
    }

    public class PostRaidPmcData : BotBase
    {
        public PostRaidStats Stats { get; set; }
    }

    public class PostRaidStats
    {
        public EftStats Eft {  get; set; }
        public EftStats Arena { get; set; }
    }
}

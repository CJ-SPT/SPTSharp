using Newtonsoft.Json;
using SPTSharp.Models.Eft.Profile;
#pragma warning disable
namespace SPTSharp.Models.Eft.Launcher
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class MiniProfile
    {
        public string username {  get; set; }
        public string nickname { get; set; }
        public string side { get; set; }
        public int currlvl { get; set; }
        public int currexp { get; set; }
        public int prevexp { get; set; }
        public int nextlvl { get; set; }
        public int maxlvl { get; set; } 
        public Aki akiData { get; set; }
    }
}

#pragma warning disable

using SPTSharp.Models.Eft.Common.Tables;

namespace SPTSharp.Models.Eft.Game
{
    public class GameConfigResponse
    {
        public int aid { get; set; }
        public string lang { get; set; }
        public Dictionary<string, string> languages { get; set; }
        public bool ndaFree { get; set; }
        public int taxonomy { get; set; }
        public string activeProfileId { get; set; }
        public Backend backend { get; set; }
        public bool useProtobuf { get; set; }
        public long utc_time { get; set; }

        /** Total in game time */
        public long totalInGame {  get; set; }
        public bool reportAvailable { get; set; }
        public bool twitchEventMember { get; set; }
    }

    public class Backend
    {
        public string Lobby { get; set; }
        public string Trading { get; set; }
        public string Messaging { get; set; }
        public string Main {  get; set; }
        public string RagFair { get; set; }
    }
}

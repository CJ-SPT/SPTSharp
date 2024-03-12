using Newtonsoft.Json;
using SPTSharp.Models.Eft.Profile;

#pragma warning disable

namespace SPTSharp.Models.Eft.Common.Tables
{
    // Profile myDeserializedclass = JsonConvert.DeserializeObject<Profile>(myJsonResponse);
    public class ProfileTemplates
    {
        public Dictionary<string, ProfileSides> ProfileSideDict { get; set; } = new Dictionary<string, ProfileSides>();

        [JsonProperty("Standard")]
        public ProfileSides Standard { get; set; }

        [JsonProperty("Left Behind")]
        public ProfileSides LeftBehind { get; set; }

        [JsonProperty("Prepare To Escape")]
        public ProfileSides PrepareToEscape { get; set; }

        [JsonProperty("Edge Of Darkness")]
        public ProfileSides EdgeOfDarkness { get; set; }

        [JsonProperty("SPT Developer")]
        public ProfileSides SPTDeveloper { get; set; }

        [JsonProperty("SPT Easy start")]
        public ProfileSides SPTEasystart { get; set; }

        [JsonProperty("SPT Zero to hero")]
        public ProfileSides SPTZerotohero { get; set; }
    }

    public class ProfileSides
    {
        public string descriptionLocaleKey { get; set; }
        public TemplateSide usec { get; set; }
        public TemplateSide bear { get; set; }

    }

    public class TemplateSide
    {
        public PmcData character {  get; set; }
        public string[] suits { get; set; }
        public Dictionary<string, Dialogue> dialogues { get; set; }
        public UserBuilds userBuilds { get; set; }
        public ProfileTraderTemplate trader {  get; set; }
    }

    public class ProfileTraderTemplate
    {
        public Dictionary<string, float> initialLoyaltyLevel { get; set; }
        public bool? setQuestsAvailableForStart { get; set; }
        public bool? setQuestsAvailableForFinish { get; set; }
        public float initialStanding {  get; set; }
        public float initialSalesSum { get; set; }
        public bool jaegerUnlocked { get; set; }
    }
}

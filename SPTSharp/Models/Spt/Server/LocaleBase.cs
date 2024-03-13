#pragma warning disable

namespace SPTSharp.Models.Spt.Server
{
    // Stores all locale data  
    public class LocaleBase
    {
        public LocaleBase() { }

        public Dictionary<string, Dictionary<string, string>> Global = new Dictionary<string, Dictionary<string, string>>();

        public Dictionary<string, Dictionary<string, string>> Server = new Dictionary<string, Dictionary<string, string>>();

        public Dictionary<string, Dictionary<string, string>> Menu = new Dictionary<string, Dictionary<string, string>>();
        
        public Dictionary<string, string> Languages = new Dictionary<string, string>
        {
            {"ch", "Chinese"},
            {"cz", "Czech"},
            {"en", "English"},
            {"fr", "French"},
            {"ge", "German"},
            {"hu", "Hungarian"},
            {"it", "Italian"},
            {"jp", "Japanese"},
            {"kr", "Korean"},
            {"pl", "Polish"},
            {"po", "Portugal"},
            {"sk", "Slovak"},
            {"es", "Spanish"},
            {"es-mx", "Spanish Mexico"},
            {"tu", "Turkish"},
            {"ru", "Русский"},
            {"ro", "Romanian"}
        };      
    }

    public class Menu
    {
        public string WrongEmailOrPassword { get; set; }
        public string ErrorConnectingToAuthServer { get; set; }
        public string ServersTemporarilyUnavailable { get; set; }
        public string Assemble { get; set; }
        public string Authorization { get; set; }
        public string BadServiceVersion { get; set; }
        public string ClientNotResponding { get; set; }
        public string CorruptedData { get; set; }
        public string CorruptedMemory { get; set; }
        public string DisallowedProgram { get; set; }
        public string FailedToLoadAnticheat { get; set; }
        public string GameRestartRequired { get; set; }
        public string GlobalBan { get; set; }
        public string QueryTimeout { get; set; }
        public string WinAPIFailure { get; set; }
        public string ServiceNeedsToBeUpdated { get; set; }
        public string ServiceNotRunningProperly { get; set; }
        public string UnknownRestartReason { get; set; }
        public string Exit { get; set; }
        public string Next { get; set; }
        public string PlaceInQueue { get; set; }
        public string LoadingProfileData { get; set; }
        public string AnticheatConnectionFailed { get; set; }
        public string ServersAtFullCapacity { get; set; }
    }

    public class MenuRootObject
    {
        public Dictionary<string, string> Menu { get; set; }
    }
}

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
        
        public Dictionary<string, string> Languages = new Dictionary<string, string>();      
    }
}

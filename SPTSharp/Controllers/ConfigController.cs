using SPTSharp.Helpers;
using SPTSharp.Models.Configs;

namespace SPTSharp.Controllers
{
    public class ConfigController
    {
        public SCore core;
        internal SHttp http;

        public ConfigController() 
        {
            var dataPath = FileIOHelper.dataPath;

            core = FileIOHelper.LoadJson<SCore>([dataPath, "Server", "Configs", "core.json"]);
            http = FileIOHelper.LoadJson<SHttp>([dataPath, "Server", "Configs", "http.json"]);
        }
    }
}

using SPTSharp.Helpers;
using SPTSharp.Models.Configs;
using SPTSharp.Models.Spt.Config;

namespace SPTSharp.Controllers
{
    public class ConfigController
    {
        public Core core;
        internal SHttp http;
        public PlayerScavConfig playerScavConfig;

        public ConfigController() 
        {
            var dataPath = FileIOHelper.dataPath;

            core = FileIOHelper.LoadJson<Core>([dataPath, "Server", "Configs", "core.json"]);
            http = FileIOHelper.LoadJson<SHttp>([dataPath, "Server", "Configs", "http.json"]);
            playerScavConfig = FileIOHelper.LoadJson<PlayerScavConfig>([dataPath, "Server", "Configs", "playerscav.json"]);
        }
    }
}

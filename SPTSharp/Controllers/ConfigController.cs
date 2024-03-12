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
            var basePath = FileIOHelper.basePath;

            core = FileIOHelper.LoadJson<SCore>([basePath, "Server", "Configs", "core.json"]);
            http = FileIOHelper.LoadJson<SHttp>([basePath, "Server", "Configs", "http.json"]);
        }
    }
}

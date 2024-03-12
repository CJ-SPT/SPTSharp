using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SPTSharp.Helpers;

namespace SPTSharp.Models.Configs
{
    public struct SCore
    {
        public required string version { get; set; }

        public required string projectName { get; set; }

        public required string compatibleTarkovVersion { get; set;}

        public required string serverName { get; set; }

        public required LogLevel logLevel { get; set; }
    }
}

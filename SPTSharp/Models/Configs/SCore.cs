#pragma warning disable
using SPTSharp.Helpers;

namespace SPTSharp.Models.Configs
{
    public class Core
    {
        public required string version { get; set; }

        public required string projectName { get; set; }

        public required string compatibleTarkovVersion { get; set;}

        public required string serverName { get; set; }

        public required LogLevel logLevel { get; set; }

        public BsgLogging bsgLogging { get; set; }
    }

    public class BsgLogging
    {
        public int verbosity { get; set; }
        public bool sendToServer { get; set; }
    }
}

using Newtonsoft.Json;

namespace SPTSharp.Models.Configs
{
    public struct SHttp
    {
        public required string ip { get; set; }

        public required int port { get; set; }
    }
}

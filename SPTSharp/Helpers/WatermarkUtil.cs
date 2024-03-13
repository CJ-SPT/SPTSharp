using SPTSharp.Controllers;
using SPTSharp.Models.Spt.Server;
using SPTSharp.Services;

namespace SPTSharp.Helpers
{
    public class VersionResponse
    {
        public VersionResponse(string version)
        {
            Version = version;
        }

        public string Version { get; set; }
    }

    public static class WatermarkUtil
    {
        private static DatabaseTables _tables => Singleton<DatabaseController>.Instance.GetTables();

        /// <summary>
        /// Get a version string (x.x.x) or (x.x.x-BLEEDINGEDGE) OR (X.X.X (18xxx))
        /// </summary>
        /// <param name="withEftVersion"></param>
        /// <returns>string</returns>
        public static string GetVersionTag(bool withEftVersion = false)
        {
            #if DEBUG
            var versionTag = $"{Singleton<ConfigController>.Instance.core.version} - {LocalizationService.GetText("bleeding_edge_build")}";
            #else
            var versionTag = Singleton<ConfigController>.Instance.core.version;
            #endif

            if (withEftVersion)
            {
                var tarkovVersion = Singleton<ConfigController>.Instance.core.compatibleTarkovVersion;
                return $"{versionTag} ({tarkovVersion})";
            }

            return versionTag;
        }

        // TODO: Finish this
        public static string GetInGameVersionLabel()
        {
            #if DEBUG
            var versionTag = $"{Singleton<ConfigController>.Instance.core.projectName} - {LocalizationService.GetText("bleeding_edge_build")}";
            #else
            var versionTag = $"{Singleton<ConfigController>.Instance.core.projectName};
            #endif

            return versionTag;
        }
    }
}

using SPTSharp.Controllers;
using SPTSharp.Models.Spt.Server;
using SPTSharp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTSharp.Helpers
{
    public static class WatermarkUtil
    {
        private static DatabaseTables _tables => Singleton<DatabaseController>.Instance.Tables;

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
    }
}

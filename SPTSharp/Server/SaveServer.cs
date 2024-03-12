using SPTSharp.Helpers;
using SPTSharp.Models.Eft.Common.Tables;
using SPTSharp.Models.Eft.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTSharp.Server
{
    public sealed class SaveServer
    {
        private readonly string _profileFilePath = Path.Combine([FileIOHelper.basePath, "user", "profiles"]);
        private Dictionary<string, AkiProfile> _profiles;

        // Get all profiles from memory
        public Dictionary<string, AkiProfile> GetProfiles()
        {
            return _profiles;
        }
    }
}

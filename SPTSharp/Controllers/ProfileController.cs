using SPTSharp.Helpers;
using SPTSharp.Models.Eft.Launcher;
using SPTSharp.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTSharp.Controllers
{
    public class ProfileController
    {
        private SaveServer _saveServer => Singleton<SaveServer>.Instance;

        public List<MiniProfile> GetMiniProfiles()
        {
            List<MiniProfile> miniProfiles = new List<MiniProfile>();

            foreach (var sessionIdKey in _saveServer.GetProfiles())
            {
                miniProfiles.Add(GetMiniProfile(sessionIdKey.Key));
            }

            return miniProfiles;
        }

        public MiniProfile GetMiniProfile(string sessionId)
        {
            return new MiniProfile();
        }
    }
}

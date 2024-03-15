using SPTSharp.Models.Eft.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTSharp.Services
{
    internal static class ProfileSnapshotService
    {
        private static Dictionary<string, AkiProfile> _storedProfileSnapshots = new Dictionary<string, AkiProfile>();

        /// <summary>
        /// Clones a given profile as a new object in _storedProfileSnapshots,
        /// key = sessionID
        /// </summary>
        /// <param name="sessionID"></param>
        /// <param name="profile"></param>
        public static void StoreProfileSnapshot(string sessionID, AkiProfile profile)
        {
            AkiProfile clone = (AkiProfile)profile.Clone();
            _storedProfileSnapshots.Add(sessionID, clone);
        }

        /// <summary>
        /// Retrieve a stored profile
        /// </summary>
        /// <param name="sessionID"></param>
        /// <returns>A player profile object</returns>
        public static AkiProfile? GetProfileSnapshot(string sessionID)
        {
            if (_storedProfileSnapshots.ContainsKey(sessionID))
            {
                return _storedProfileSnapshots[sessionID];
            }

            return null;
        }

        /// <summary>
        /// Does a profile exist against the provided key
        /// </summary>
        /// <param name="sessionID"></param>
        /// <returns>true if exists</returns>
        public static bool HasProfileSnapshot(string sessionID)
        {
            if (_storedProfileSnapshots.ContainsKey(sessionID))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Remove a stored profile by key
        /// </summary>
        /// <param name="sessionID"></param>
        public static void ClearProfileSnapshot(string sessionID)
        {
            if (_storedProfileSnapshots.ContainsKey(sessionID))
            {
                _storedProfileSnapshots.Remove(sessionID);
            }
        }
    }
}

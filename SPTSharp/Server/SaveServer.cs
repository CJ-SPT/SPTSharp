using SPTSharp.Helpers;
using SPTSharp.Models.Eft.Profile;
using System.Diagnostics;

namespace SPTSharp.Server
{
    internal sealed class SaveServer
    {
        private readonly string _profileFilePath = FileIOHelper.profilePath;
        private Dictionary<string, AkiProfile> _profiles = new Dictionary<string, AkiProfile>();

        // Get a profile by sessionId from the save server
        public AkiProfile GetProfile(string sessionID)
        {
            if (sessionID == null)
            {
                throw new ArgumentException("session ID provided was null, did you restart the server while the game was running?");
            }

            if (_profiles == null)
            {
                throw new NullReferenceException("`_profiles` is null, this shouldn't happen");
            }

            return _profiles[sessionID];
        }

        // Get all profiles from memory
        public Dictionary<string, AkiProfile> GetProfiles()
        {
            return _profiles;
        }

        /// <summary>
        /// Delete a profile by id
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns>true when deleted, false when profile not found</returns>
        public bool DeleteProfileBySessionId(string sessionId)
        {
            return _profiles.Remove(sessionId);
        }

        // Creates a empty profile
        // Returns true if on success, false on failure.
        public bool CreateProfile(Info profileInfo)
        {
            if (_profiles.ContainsKey(profileInfo.id))
            {
                Logger.LogError($"A profile already exists for session ID: {profileInfo.id}");
                return false;
            }

            _profiles[profileInfo.id] = new AkiProfile
            {
                info = profileInfo,
                characters = new Characters()
            };

            return true;
        }

        /// <summary>
        /// Add full profile in memory by key (info.id)
        /// </summary>
        /// <param name="profile"></param>
        public void AddProfile(AkiProfile profile)
        {
            if (!_profiles.ContainsKey(profile.info.id))
            {
                _profiles[profile.info.id] = profile;
                return;
            }

            Logger.LogError($"No profile exists for profile: {profile.info.id}");
        }

        // Loads a profile by sessionId from disk
        // returns true on success, false on failure
        public bool LoadProfile(string sessionID)
        {
            Stopwatch stopwatch = new Stopwatch();
            var filename = $"{sessionID}.json";
            var filePath = Path.Combine(_profileFilePath, filename);

            if (File.Exists(filePath))
            {
                // Store profile on disk in memory             
                stopwatch.Start();
                _profiles[sessionID] = FileIOHelper.LoadJson<AkiProfile>([filePath]);
                stopwatch.Stop();
                
                Logger.LogDebug($"Profile {sessionID} took: {stopwatch.ElapsedMilliseconds} ms to load.");
                return true;
            }

            return false;
        }

        public void LoadAllProfilesFromDisk()
        {
            foreach (var profile in Directory.GetFiles(_profileFilePath))
            {
                var id = Path.GetFileNameWithoutExtension(profile);
                _profiles[id] = FileIOHelper.LoadJson<AkiProfile>([profile]);
                Logger.LogInfo($"Loaded profile {id}");
            }
        }

        public void SaveProfile(string sessionID)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var filename = $"{sessionID}.json";
            var filePath = Path.Combine(_profileFilePath, filename);

            if (_profiles.ContainsKey(sessionID))
            {
                FileIOHelper.SaveJson([filePath], _profiles[sessionID]);

                stopwatch.Stop();
                Logger.LogDebug($"Profile {sessionID} took {stopwatch.ElapsedMilliseconds} ms to save.");
                return;
            }

            Logger.LogError($"No profile exists in memory with sessionId {sessionID}");
        }

        /// <summary>
        /// Remove a physical profile json from user/profiles
        /// </summary>
        /// <param name="sessionID"></param>
        /// <returns>true if file no longer exists</returns>
        public bool RemoveProfile(string sessionID) 
        {
            var filename = $"{sessionID}.json";
            var filePath = Path.Combine(_profileFilePath, filename);

            if (_profiles.ContainsKey(sessionID))
            {
                _profiles.Remove(sessionID);
            }

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            Logger.LogInfo($"Profile: {sessionID} removed.");
            return !File.Exists(filePath);
        }
    }
}

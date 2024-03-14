using SPTSharp.Helpers;
using SPTSharp.Models.Eft.Common;
using SPTSharp.Models.Eft.Common.Tables;
using SPTSharp.Models.Spt.Server;
using SPTSharp.Routers;
using SPTSharp.Services;
using System.Globalization;


namespace SPTSharp.Controllers
{
    public class DatabaseController
    {
        // Global object holding all database information
        private DatabaseTables _tables { get; set; }

        public DatabaseController() 
        {       
            _tables = new DatabaseTables();
        }

        // Returns the initialized database tables for use
        public DatabaseTables GetTables()
        {
            return _tables;
        }

        // Loads and initializes all database data
        internal void InitDatabase()
        {
            Logger.LogInfo("Initializing database...");

            var dataPath = FileIOHelper.dataPath;

            // Locale data
            _tables.Locales.Global = FileIOHelper.LoadLocaleData([dataPath, "Server", "Database", "locales", "global"]);
            _tables.Locales.Server = FileIOHelper.LoadLocaleData([dataPath, "Server", "Database", "locales", "server"]);
            _tables.Locales.Menu = FileIOHelper.LoadLocaleData([dataPath, "Server", "Database", "locales", "menu"]);

            _tables.templates.items = FileIOHelper.LoadJson<Dictionary<string, TemplateItem>>([dataPath, "server", "Database", "templates", "items.json"]);

            Logger.LogDebug($"Loaded {_tables.templates.items.Count} items");

            _tables.templates.profiles = FileIOHelper.LoadJson<ProfileTemplates>([dataPath, "Server", "Database", "templates", "profiles.json"]);
            _tables.globals = FileIOHelper.LoadJson<Globals>([dataPath, "server", "Database", "globals.json"]);

            BuildProfileDict();
            LoadImages();

            Logger.LogDebug("Initializing database complete...");
        }
        
        // Builds the profile dictionary: TODO - REFACTOR
        private void BuildProfileDict()
        {
            Logger.LogDebug("Building profile dictionary...");
            var profiles = _tables.templates.profiles;

            profiles.ProfileSideDict.Add("Standard", profiles.Standard);
            profiles.ProfileSideDict.Add("Left Behind", profiles.LeftBehind);
            profiles.ProfileSideDict.Add("Prepare To Escape", profiles.PrepareToEscape);
            profiles.ProfileSideDict.Add("SPT Developer", profiles.SPTDeveloper);
            profiles.ProfileSideDict.Add("SPT Easy start", profiles.SPTEasystart);
            profiles.ProfileSideDict.Add("SPT Zero to hero", profiles.SPTZerotohero);         
        }

        /***
         * Map file routes to their respective location on disk
         */
        private void LoadImages()
        {
            var filePath = Path.Combine([FileIOHelper.dataPath, "server", "images"]);
            var directories = Directory.GetDirectories(Path.Combine([FileIOHelper.dataPath, "server", "images"]));

            string[] imageRoutes = {
            "/files/achievement/",
            "/files/CONTENT/banners/",
            "/files/handbook/",
            "/files/Hideout/",
            "/files/launcher/",
            "/files/quest/icon/",
            "/files/trader/avatar/",
            };

            foreach (var directory in directories)
            {
                var filesInDirectory = Directory.GetFiles(directory);
                var splitDir = directory.Split(Path.DirectorySeparatorChar);

                // Check if any part of the directory matches with imageRoutes
                var matchingImageRoute = Array.Find(imageRoutes, route =>
                    splitDir.Any(part => route.IndexOf(part, StringComparison.OrdinalIgnoreCase) != -1));

                if (matchingImageRoute != null)
                {               
                    foreach (var file in filesInDirectory)
                    {
                        var stripped = Path.GetFileNameWithoutExtension(file);
                        var route = Path.Combine([matchingImageRoute, stripped]);

                        ImageRouter.AddRoute(route, file);
                    }
                }
            }
        }
    }
}

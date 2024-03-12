using SPTSharp.Helpers;
using SPTSharp.Models.Eft.Common;
using SPTSharp.Models.Eft.Common.Tables;
using SPTSharp.Models.Spt.Server;
using SPTSharp.Routers;
using SPTSharp.Services;


namespace SPTSharp.Controllers
{
    public class DatabaseController
    {
        // Global object holding all database information
        public DatabaseTables Tables { get; set; }

        public DatabaseController() 
        {
            Logger.LogInfo("Initializing database...");

            var basePath = FileIOHelper.basePath;
            Tables = new DatabaseTables();

            Logger.LogDebug("Loading json from disk...");

            // Locale data
            Tables.Locales.Global = FileIOHelper.LoadLocaleData([basePath, "Server", "Database", "locales", "global"]);
            Tables.Locales.Server = FileIOHelper.LoadLocaleData([basePath, "Server", "Database", "locales", "server"]);
            //Tables.Locale.Menu = FileIOHelper.LoadLocaleData([basePath, "Server", "Database", "locales", "menu"]); //FIXME

            Tables.templates.profiles = FileIOHelper.LoadJson<ProfileTemplates>([basePath, "Server", "Database", "templates", "profiles.json"]);
            Tables.globals = FileIOHelper.LoadJson<Globals>([basePath, "server", "Database", "globals.json"]);

            Logger.LogDebug("Loading json from disk complete...");
        }

        public void InitDatabase()
        {
            BuildProfileDict();
            LoadImages();
        }
        
        private void BuildProfileDict()
        {
            Logger.LogDebug("Building profile dictionary...");
            var profiles = Tables.templates.profiles;

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
            var filePath = Path.Combine([FileIOHelper.basePath, "server", "images"]);
            var directories = Directory.GetDirectories(Path.Combine([FileIOHelper.basePath, "server", "images"]));

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

using SPTSharp.Helpers;
using SPTSharp.Models.Eft.Common;
using SPTSharp.Models.Eft.Common.Tables;
using SPTSharp.Models.Spt.Server;
using SPTSharp.Models.Spt.Services;
using SPTSharp.Routers;
using SPTSharp.Services;
using System.Globalization;


namespace SPTSharp.Controllers
{
    public class DatabaseController
    {
        // Global object holding all database information
        private DatabaseTables _tables { get; set; }
        private string _dataPath = FileIOHelper.dataPath;

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
            
            Logger.LogDebug("Loading locales...");
            // Locale data
            _tables.Locales.Global = FileIOHelper.LoadLocaleData([_dataPath, "Server", "Database", "locales", "global"]);
            _tables.Locales.Server = FileIOHelper.LoadLocaleData([_dataPath, "Server", "Database", "locales", "server"]);
            _tables.Locales.Menu = FileIOHelper.LoadLocaleData([_dataPath, "Server", "Database", "locales", "menu"]);

            Logger.LogDebug("Loading templates...");

            _tables.templates.character = FileIOHelper.LoadJson<List<string>>([_dataPath, "server", "database", "templates", "character.json"]);
            _tables.templates.items = FileIOHelper.LoadJson<Dictionary<string, TemplateItem>>([_dataPath, "server", "Database", "templates", "items.json"]);

            Logger.LogDebug($"Loaded {_tables.templates.items.Count} items");

            _tables.templates.customization = FileIOHelper.LoadJson<Dictionary<string, CustomizationItem>>([_dataPath, "server", "database", "templates", "customization.json"]);
            _tables.templates.profiles = FileIOHelper.LoadJson<ProfileTemplates>([_dataPath, "Server", "Database", "templates", "profiles.json"]);

            Logger.LogDebug("Loading Globals...");

            _tables.globals = FileIOHelper.LoadJson<Globals>([_dataPath, "server", "Database", "globals.json"]);
            _tables.settings = FileIOHelper.LoadJson<SettingsBase>([_dataPath, "server", "Database", "settings.json"]);

            BuildProfileDict();
            LoadImages();
            LoadTraderData();
            LoadBotTypes();

        }

        private void LoadBotTypes()
        {
            Logger.LogDebug("Loading bot types...");

            var botDir = Path.Combine([_dataPath, "server", "database", "bots"]);

            _tables.BotSettings.core = FileIOHelper.LoadJson<BotCore>([botDir, "core.json"]);
            _tables.BotSettings.botBase = FileIOHelper.LoadJson<BotBase>([botDir, "core.json"]);
            
            foreach (var file in Directory.GetFiles(Path.Combine(botDir, "types")))
            {
                var fileName = Path.GetFileNameWithoutExtension(file);

                var botType = FileIOHelper.LoadJson<BotType>([file]);
                
                _tables.BotSettings.types.Add(fileName, botType);
            }

        }
        
        private void LoadTraderData()
        {
            Logger.LogDebug("Loading trader data...");

            var traderDir = Path.Combine([_dataPath, "server", "database", "traders"]);
            
            // Break down trader data paths into usable segments
            foreach (var dir in Directory.GetDirectories(traderDir))
            {
                var trader = new Trader();
                var traderId = dir.Split('\\').Last();
                var added = _tables.traders.TryAdd(traderId, trader);

                _tables.traders[traderId].Base = FileIOHelper.LoadJson<TraderBase>([dir, "base.json"]);

                // Load assorts
                var assortFile = Path.Combine(dir, "assort.json");
                if (File.Exists(assortFile))
                {
                    _tables.traders[traderId].assort = FileIOHelper.LoadJson<TraderAssort>([assortFile]);
                }

                // Load quest assorts
                var questAssortFile = Path.Combine(dir, "questassort.json");
                if (File.Exists(questAssortFile))
                {
                    _tables.traders[traderId].questAssort = FileIOHelper.LoadJson<QuestAssort>([questAssortFile]);
                }

                // Load suits
                var bearSuitsFile = Path.Combine(dir, "bearsuits.json");
                var usecSuitsFile = Path.Combine(dir, "usecsuits.json");
                var suitsFile = Path.Combine(dir, "suits.json");
                if (File.Exists(suitsFile))
                {
                    var tmpBearSuits = FileIOHelper.LoadJson<List<Suit>>([bearSuitsFile]);
                    var tmpUsecSuits = FileIOHelper.LoadJson<List<Suit>>([usecSuitsFile]);
                    var suits = FileIOHelper.LoadJson<List<Suit>>([suitsFile]);

                    _tables.traders[traderId].suits = [.. tmpBearSuits, .. tmpUsecSuits, .. suits];
                }

                // Load dialogues
                var dialogueFile = Path.Combine(dir, "dialogue.json");
                if (File.Exists(dialogueFile))
                {
                    _tables.traders[traderId].dialogue = FileIOHelper.LoadJson<Dictionary<string, string[]>>([dialogueFile]);
                }

                // Load services
                var servicesFile = Path.Combine(dir, "services.json");
                if (File.Exists(servicesFile))
                {
                    _tables.traders[traderId].traderServices = FileIOHelper.LoadJson<List<TraderServiceModel>>([servicesFile]);
                }
            }
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
            Logger.LogDebug("Loading images...");

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

using SPTSharp.Controllers;
using SPTSharp.Helpers;
using SPTSharp.Server;

namespace SPTSharp
{
    public class SPTSharp
    {
        public static void Main(string[] args)
        {
            SingletonFactory();

            var server = new HttpServerRunner();
            server.StartHttpServer();

            while (true)
            {
                string line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                if (line == "!")
                {
                    Logger.LogInfo("Server restarting...");
                    server.RestartHttpServer();
                    Logger.LogInfo("Done!");
                }
            }
        }

        public static void SingletonFactory()
        {
            Logger.LogInfo("Running singleton factory...");

            Singleton<ConfigController>.Instance = new ConfigController();
            Logger.LogDebug("Configs Loaded.");

            Singleton<DatabaseController>.Instance = new DatabaseController();
            Singleton<DatabaseController>.Instance.InitDatabase();
            Logger.LogDebug("Database loaded");

            Singleton<LauncherController>.Instance = new LauncherController();
            Singleton<ProfileController>.Instance = new ProfileController();
            Singleton<SaveServer>.Instance = new SaveServer();
        }
    }
}

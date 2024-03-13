using SPTSharp.Controllers;
using SPTSharp.Helpers;
using SPTSharp.Loaders;
using SPTSharp.Server;
using System.Diagnostics;

namespace SPTSharp
{
    public class SPTSharp
    {
        public static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            SingletonFactory();

            var server = new HttpServerRunner();
            server.StartHttpServer();

            stopwatch.Stop();
            Logger.LogInfo($"Startup took {stopwatch.ElapsedMilliseconds} milliseconds");

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
            // Controllers
            Singleton<ConfigController>.Instance = new ConfigController();
            Singleton<LauncherController>.Instance = new LauncherController();
            Singleton<ProfileController>.Instance = new ProfileController();
            Singleton<BundleLoader>.Instance = new BundleLoader();

            Singleton<DatabaseController>.Instance = new DatabaseController();
            Singleton<DatabaseController>.Instance.InitDatabase();
            Logger.LogDebug("Database loaded");

            // Servers
            Singleton<SaveServer>.Instance = new SaveServer();
        }
    }
}

using SPTSharp.Helpers;
using SPTSharp.Models.Eft.Game;
using SPTSharp.Models.Spt.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTSharp.Controllers
{
    public class GameController
    {
        private DatabaseTables _tables => Singleton<DatabaseController>.Instance.GetTables();

        public GameConfigResponse GetGameConfig(string sessionId)
        {
            var profile = ProfileHelper.GetPmcProfile(sessionId);

            long gameTime = profile?.Stats?.Eft?.OverallCounters?.Items
                .FirstOrDefault(t => t != null && t.Key.Contains("LifeTime") && t.Key.Contains("Pmc"))?.Value ?? 0;

            DateTimeOffset now = DateTimeOffset.UtcNow;

            GameConfigResponse config = new GameConfigResponse
            {
                languages = _tables.Locales.Languages,
                ndaFree = false,
                reportAvailable = false,
                twitchEventMember = false,
                lang = "en",
                aid = ProfileHelper.GetFullProfile(sessionId).info.aid,
                taxonomy = 6,
                activeProfileId = sessionId,
                backend = new Backend
                {
                    Lobby = HttpServerHelper.GetBackendUrl(),
                    Trading = HttpServerHelper.GetBackendUrl(),
                    Messaging = HttpServerHelper.GetBackendUrl(),
                    Main = HttpServerHelper.GetBackendUrl(),
                    RagFair = HttpServerHelper.GetBackendUrl(),
                },
                useProtobuf = false,
                utc_time = now.ToUnixTimeMilliseconds(),
                totalInGame = gameTime
            };


            return config;
        }

        public KeepGameAliveResponse GetKeepGameAlive()
        {
            return new KeepGameAliveResponse { msg = "OK", utc_time = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()};
        }
    }
}

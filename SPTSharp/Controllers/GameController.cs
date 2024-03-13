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

            if (profile == null)
            {
                throw new NullReferenceException("GetGameConfig: Profile was null.");
            }

            var gameTime = profile?.Stats?.Eft?.OverallCounters?.Items
                .First(t => t != null && t.Key.Contains("LifeTime") && t.Key.Contains("Pmc"))?.Value;

            if (gameTime == null)
            {
                gameTime = 0;
            }

            DateTimeOffset now = DateTimeOffset.UtcNow;

            GameConfigResponse config = new GameConfigResponse
            {
                languages = _tables.Locales.Languages,
                ndaFree = false,
                reportAvailable = false,
                twitchEventMember = false,
                lang = "en",
                aid = profile?.aid ?? null,
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

            };


            return config;
        }
    }
}

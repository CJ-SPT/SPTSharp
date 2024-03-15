﻿using NetCoreServer;
using SPTSharp.CallBacks;

namespace SPTSharp.Routers
{
    internal static partial class BaseRequestRouter
    {
        private static readonly Dictionary<string, Action<HttpSession, HttpRequest, HttpResponse, string>> _getRoutes =
            new Dictionary<string, Action<HttpSession, HttpRequest, HttpResponse, string>>
            {
                { "/launcher/server/connect",                   LauncherCallbacks.Connect                   },
                { "/launcher/ping" ,                            LauncherCallbacks.Ping                      },
                { "/launcher/server/version",                   LauncherCallbacks.GetVersion                },
                { "/launcher/profiles",                         LauncherCallbacks.GetAllMiniProfiles        },
                { "/launcher/server/loadedServerMods",          LauncherCallbacks.GetServerMods             },
                { "/launcher/server/serverModsUsedByProfile",   LauncherCallbacks.GetProfileMods            },
                { "/singleplayer/bundles",                      BundleCallbacks.GetBundles                  },
                { "/singleplayer/settings/version",             GameCallbacks.GetVersion                    }
            };

        private static readonly Dictionary<string, Action<HttpSession, HttpRequest, HttpResponse, string>> _postRoutes =
            new Dictionary<string, Action<HttpSession, HttpRequest, HttpResponse, string>>
            {
                { "/launcher/profile/login",                    LauncherCallbacks.Login                     },
                { "/launcher/profile/register",                 LauncherCallbacks.Register                  },
                { "/launcher/profile/get",                      LauncherCallbacks.GetProfile                },
                { "/launcher/profile/info",                     LauncherCallbacks.GetProfileInfo            },
                { "/launcher/profile/remove",                   LauncherCallbacks.RemoveProfile             },
                { "/client/game/start",                         GameCallbacks.GameStart                     },
                { "/client/game/version/validate",              GameCallbacks.Validate                      },
                { "/client/languages",                          DataCallbacks.GetLocaleLanguages            },
                { "/client/game/config",                        GameCallbacks.GetGameConfig                 },
                { "/client/items",                              DataCallbacks.GetTemplateItems              }, // Done? POG
                { "/client/customization",                      DataCallbacks.GetTemplateSuits              }, // TODO
                { "/client/globals",                            DataCallbacks.GetGlobals                    }, // TODO
                { "/client/trading/api/traderSettings",         TraderCallbacks.GetTraderSettings           }, // Might be done?
            };

        private static readonly Dictionary<string, Action<HttpSession, HttpRequest, HttpResponse, string>> _dynamicRoutes =
            new Dictionary<string, Action<HttpSession, HttpRequest, HttpResponse, string>>
            {
                { "/client/menu/locale/",                       DataCallbacks.GetLocaleMenu                 },
            };
    }
}

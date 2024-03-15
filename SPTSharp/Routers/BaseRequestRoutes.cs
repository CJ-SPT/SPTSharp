using NetCoreServer;
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
                { "/client/items",                              DataCallbacks.GetTemplateItems              },
                { "/client/customization",                      DataCallbacks.GetTemplateSuits              },
                { "/client/globals",                            DataCallbacks.GetGlobals                    }, // Might be done?
                { "/client/trading/api/traderSettings",         TraderCallbacks.GetTraderSettings           }, // Might be done?
                { "/client/settings",                           DataCallbacks.GetSettings                   },
                { "/client/game/profile/list",                  ProfileCallbacks.GetProfileData             },
                { "/client/account/customization",              DataCallbacks.GetTemplateCharacter          },
                { "/client/game/profile/nickname/reserved",     ProfileCallbacks.GetNicknameReserved        },
                { "/client/game/profile/nickname/validate",     ProfileCallbacks.ValidateNickname           },
                { "/client/game/keepalive",                     GameCallbacks.KeepAlive                     },
                { "/client/game/profile/create",                ProfileCallbacks.CreateProfile              },   
            };

        private static readonly Dictionary<string, Action<HttpSession, HttpRequest, HttpResponse, string>> _dynamicRoutes =
            new Dictionary<string, Action<HttpSession, HttpRequest, HttpResponse, string>>
            {
                { "/client/menu/locale/",                       DataCallbacks.GetLocaleMenu                 },
                { "/client/locale/",                            DataCallbacks.GetLocaleGlobal               }
            };
    }
}

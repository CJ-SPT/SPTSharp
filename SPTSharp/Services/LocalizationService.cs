using SPTSharp.Controllers;
using SPTSharp.Helpers;
using SPTSharp.Models.Spt.Server;
using System.Globalization;

namespace SPTSharp.Services
{
    public static class LocalizationService
    {
        private static LocaleBase _locales => Singleton<DatabaseController>.Instance.GetTables().Locales;
        public static string culture => CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

        /// <summary>
        /// Get the localization text for a given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetText(string key)
        {
            if (_locales.Server[culture].ContainsKey(key))
            {
                return _locales.Server[culture][key];
            }

            if (_locales.Global[culture].ContainsKey(key))
            {
                return _locales.Global[culture][key];
            }

            if (_locales.Menu[culture].ContainsKey(key))
            {
                return _locales.Menu[culture][key];
            }

            Logger.LogError($"Could not find key {key} in any locale. for language {culture}");
            return string.Empty;
        }

        /// <summary>
        /// Get All locale keys
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static List<string> GetAllKeys()
        {
            throw new NotImplementedException("GetAllKeys");
        }

        /// <summary>
        /// From the provided partial key, find all keys that start with text and choose a random match
        /// </summary>
        /// <param name="partialKey"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static string GetRandomTextThatMatchesPartialKey(string partialKey)
        {
            throw new NotImplementedException("GetRandomTextThatMatchesPartialKey");
        }
    }
}

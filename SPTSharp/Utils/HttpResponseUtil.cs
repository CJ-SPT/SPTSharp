using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SPTSharp.Converters;
using SPTSharp.Models.Eft.HttpResponse;
using System.Text.RegularExpressions;

#pragma warning disable

namespace SPTSharp.Utils
{
    public static class HttpResponseUtil
    {
        public static string ClearString(string s)
        {
            return s.Replace("\b", "").Replace("\f", "").Replace("\n", "").Replace("\r", "").Replace("\t", "");
        }

        /**
         * Return passed-in data as JSON string
         * @param data
         * @returns
         */
        public static string NoBody(object data)
        {
            var settings = new JsonSerializerSettings();
            settings.FloatFormatHandling = FloatFormatHandling.DefaultValue;
            settings.Converters = new List<JsonConverter> { new WholeNumberFloatConverter() };
            settings.NullValueHandling = NullValueHandling.Ignore;

            return ClearString(JsonConvert.SerializeObject(data, settings));
        }

        /**
         * Game client needs server responses in a particular format
         * @param data
         * @param err
         * @param errmsg
         * @returns
         */
        public static string GetBody(object data, int err = 0, string errmsg = null, bool sanitize = true)
        {
            var settings = new JsonSerializerSettings();
            settings.FloatFormatHandling = FloatFormatHandling.DefaultValue;
            settings.Converters = new List<JsonConverter> { new WholeNumberFloatConverter() };
            settings.NullValueHandling = NullValueHandling.Ignore;

            return sanitize
                ? JsonConvert.SerializeObject(new GetBodyResponseData<object> { err = err, errmsg = errmsg, data = data }, settings)
                : GetUnclearedBody(data, err, errmsg);
        }


        public static string GetUnclearedBody(object data, int err = 0, string errmsg = null)
        {
            var settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.Indented;
            settings.FloatFormatHandling = FloatFormatHandling.DefaultValue;
            settings.Converters = new List<JsonConverter> { new WholeNumberFloatConverter() };
            settings.NullValueHandling = NullValueHandling.Ignore;

            return JsonConvert.SerializeObject(new { err = err, errmsg = errmsg, data = data }, settings);
        }

        public static string EmptyResponse()
        {
            return GetBody("");
        }

        public static string NullResponse()
        {
            return ClearString(GetUnclearedBody(null, 0, null));
        }
    }
}

using Newtonsoft.Json;
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
            return ClearString(JsonConvert.SerializeObject(data));
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
            return sanitize
                ? JsonConvert.SerializeObject(new GetBodyResponseData<object> { err = err, errmsg = errmsg, data = data })
                : GetUnclearedBody(data, err, errmsg);
        }

        public static string GetUnclearedBody(object data, int err = 0, string errmsg = null)
        {
            return JsonConvert.SerializeObject(new { err = err, errmsg = errmsg, data = data });
        }

        public static string EmptyResponse()
        {
            return GetBody("");
        }
    }
}

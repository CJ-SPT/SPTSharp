using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            // Convert data object to JObject
            JObject dataObject = JObject.FromObject(data);

            // Construct the GetBodyResponseData<JObject> object
            GetBodyResponseData<JObject> responseData = new GetBodyResponseData<JObject>
            {
                data = dataObject,
                err = err,
                errmsg = errmsg
            };

            // Serialize the GetBodyResponseData<JObject> object to JSON
            string jsonResult = JsonConvert.SerializeObject(responseData);

            // Optionally sanitize the JSON string
            if (sanitize)
            {
                jsonResult = ClearString(jsonResult);
            }

            return jsonResult;
        }


        public static string GetUnclearedBody(object data, int err = 0, string errmsg = null)
        {
            return JsonConvert.SerializeObject(new { err = err, errmsg = errmsg, data = data });
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

namespace SPTSharp.Utils
{
    public static class HttpResponseUtil
    {
        // Returns passed in data as JSON string
        public static string NoBody(object data)
        {
            return ClearString(JsonUtil.Serialize(data));
        }

        public static string getUnclearedBody(object data, int err = 0, object? errMsg = null)
        {
            return JsonUtil.Serialize(new object[] { err, errMsg, data });
        }

        // Clears the string of all escape characters
        private static string ClearString(string s)
        {
            if (s == null)
            {
                return null;
            }

            return s.Replace("\b", "")
                    .Replace("\f", "")
                    .Replace("\n", "")
                    .Replace("\r", "")
                    .Replace("\t", "");
        }
    }
}

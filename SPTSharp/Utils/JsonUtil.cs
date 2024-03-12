using Newtonsoft.Json;

namespace SPTSharp.Utils
{
    public static class JsonUtil
    {
        public static string Serialize(object data)
        {
            return JsonConvert.SerializeObject(data).ToString();
        }
    }
}

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace SPTSharp.Converters
{
    internal class EmptyPropertyConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            // This converter is applicable to all types
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load the token from the reader
            var token = JToken.Load(reader);

            // If the token is an empty object or an empty array, return null
            if (token.Type == JTokenType.Object && !token.HasValues)
            {
                return null;
            }
            else if (token.Type == JTokenType.Array && !token.HasValues)
            {
                return null;
            }

            // Otherwise, return the token as is
            return token.ToObject(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Write the value directly
            JToken.FromObject(value).WriteTo(writer);
        }
    }
}

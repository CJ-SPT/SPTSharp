
using Newtonsoft.Json;

namespace SPTSharp.Converters
{
    internal class WholeNumberFloatConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(float) || objectType == typeof(float?);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            float floatValue = (float)value;

            if (Math.Abs(floatValue % 1) < 0.00000001f)         // Check if the float value is a whole number
            {
                int intValue = (int)floatValue;
                writer.WriteValue(intValue);
            }
            else
            {
                writer.WriteValue(floatValue);                  // Write the original float value if it's not a whole number
            }

        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("This converter only supports serialization, not deserialization.");
        }
    }
}

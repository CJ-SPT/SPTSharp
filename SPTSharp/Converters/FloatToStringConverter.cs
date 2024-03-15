using Newtonsoft.Json;

namespace SPTSharp.Converters
{
    public class FloatToStringAttribute : Attribute
    {
        public JsonConverter Converter { get; }

        public FloatToStringAttribute() 
        { 
            Converter = new FloatToStringConverter();
        }

        public class FloatToStringConverter : JsonConverter
        {
            private readonly Type[] _types;

            public FloatToStringConverter(params Type[] types)
            {
                _types = types;
            }

            public override bool CanConvert(Type typeToConvert)
            {
                return _types.Any(t => t == typeToConvert);
            }

            public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }

            public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
            {
                if (value is float floatValue)
                {
                    writer.WriteValue(floatValue.ToString());
                }
                else
                {
                    throw new InvalidCastException("Expected float value");
                }
            }
        }
    } 
}

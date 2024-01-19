using System.Text.Json;
using System.Text.Json.Serialization;

namespace BookAPIagro.DataAccess
{
    public class SingleOrArrayJSONConverter<T> : JsonConverter<List<T>>
    {
        public override List<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.StartArray)
            {
                return JsonSerializer.Deserialize<List<T>>(ref reader, options);
            }
            var singleValue = JsonSerializer.Deserialize<T>(ref reader, options);
            if(singleValue == null)
            {
                return default;
            }
            return [singleValue];
        }

        public override void Write(Utf8JsonWriter writer, List<T> value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}

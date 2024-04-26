using System.Text.Json;
using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.JsonConverters;

internal class SingleOrArrayConverter<TEnumerable, TItem> : JsonConverter<TEnumerable>
    where TEnumerable : IEnumerable<TItem>
{
    public override TEnumerable Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.Null:
                return (TEnumerable) Enumerable.Empty<TItem>();
            case JsonTokenType.StartArray:
                var list = new List<TItem>();
                while (reader.Read())
                {
                    if (reader.TokenType is JsonTokenType.EndArray) break;
                    var listItem = JsonSerializer.Deserialize<TItem>(ref reader, options);
                    if (listItem != null) list.Add(listItem);
                }

                return (TEnumerable) (IEnumerable<TItem>) list;
            default:
                var item = JsonSerializer.Deserialize<TItem>(ref reader, options);
                return item != null
                    ? (TEnumerable) (IEnumerable<TItem>) new List<TItem> {item}
                    : (TEnumerable) Enumerable.Empty<TItem>();
        }
    }

    public override void Write(Utf8JsonWriter writer, TEnumerable value, JsonSerializerOptions options)
    {
        if (value.Count() == 1)
        {
            JsonSerializer.Serialize(writer, value.First(), options);
        }
        else
        {
            writer.WriteStartArray();
            foreach (var item in value)
                JsonSerializer.Serialize(writer, item, options);
            writer.WriteEndArray();
        }
    }
}

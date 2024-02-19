using System.Text.Json;
using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.JsonConverters;

internal class SingleOrArrayConverter<TCollection, TItem> : JsonConverter<TCollection>
    where TCollection : class, ICollection<TItem>, new()
{
    public override TCollection? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.Null:
                return null;
            case JsonTokenType.StartArray:
                var list = new TCollection();
                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndArray) break;
                    var listItem = JsonSerializer.Deserialize<TItem>(ref reader, options);
                    if (listItem != null) list.Add(listItem);
                }
                return list;
            default:
                var item = JsonSerializer.Deserialize<TItem>(ref reader, options);
                return item != null ? new TCollection {item} : null;
        }
    }

    public override void Write(Utf8JsonWriter writer, TCollection value, JsonSerializerOptions options)
    {
        if (value.Count == 1)
            JsonSerializer.Serialize(writer, value.First(), options);
        else
        {
            writer.WriteStartArray();
            foreach (var item in value)
                JsonSerializer.Serialize(writer, item, options);
            writer.WriteEndArray();
        }
    }
}
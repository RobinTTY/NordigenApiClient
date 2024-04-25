using System.Text.Json;
using System.Text.Json.Serialization;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.JsonConverters;

/// <summary>
/// For some errors the GoCardless API returns arrays for Summary/Detail properties inside the <see cref="BasicResponse"/>.
/// I've never actually seen them contain multiple values, but this converter merges them into one string so that the
/// <see cref="BasicResponse"/> can stay as simple as possible.
/// </summary>
internal class StringArrayMergeConverter : JsonConverter<string>
{
    public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.Null:
                return null;
            case JsonTokenType.StartArray:
                var list = new List<string>();
                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndArray) break;
                    var listItem = JsonSerializer.Deserialize<string>(ref reader, options);
                    if (listItem != null) list.Add(listItem);
                }

                return string.Join("; ", list);
            default:
                return JsonSerializer.Deserialize<string>(ref reader, options);
        }
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);
}

using System.Text.Json;
using System.Text.Json.Serialization;
using RobinTTY.NordigenApiClient.Models.Requests;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.JsonConverters;

/// <summary>
/// For some errors the GoCardless API returns arrays for Summary/Detail properties inside the
/// <see cref="BasicResponse" />
/// .
/// I've never actually seen them contain multiple values, but this converter merges them into one string so that the
/// <see cref="BasicResponse" /> can stay as simple as possible.
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
                    var listItem = reader.GetString();
                    if (listItem != null) list.Add(listItem);
                }

                return string.Join("; ", list);
            default:
                return JsonSerializer.Deserialize<string>(ref reader, options);
        }
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}

/// <summary>
/// For some errors (so far only seen when creating requisitions) the GoCardless API returns a simple array of strings
/// as response to a field in the <see cref="CreateRequisitionRequest" /> having an invalid value. To bring them in
/// line with errors from other fields in the response this converter converts them to the <see cref="BasicResponse" />
/// type.
/// Update 02.08.2025: now the API also returns simple strings instead sometimes, this is again not documented...
/// </summary>
internal class StringArrayToBasicResponseConverter : JsonConverter<BasicResponse>
{
    public override BasicResponse? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
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
                    var listItem = reader.GetString();
                    if (listItem != null) list.Add(listItem);
                }

                return new BasicResponse(list.First(), string.Join("; ", list));
            case JsonTokenType.String:
                return new BasicResponse(reader.GetString(), reader.GetString());
            default:
                return JsonSerializer.Deserialize<BasicResponse>(ref reader, options);
        }
    }

    public override void Write(Utf8JsonWriter writer, BasicResponse value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}
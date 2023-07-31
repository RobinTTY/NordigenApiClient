using System.Text.Json;
using System.Text.Json.Serialization;
using RobinTTY.NordigenApiClient.Models.Errors;

namespace RobinTTY.NordigenApiClient.JsonConverters;
internal class InstitutionsErrorConverter : JsonConverter<InstitutionsError>
{
    public override InstitutionsError Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions? options)
    {
        var error = JsonSerializer.Deserialize<InstitutionsErrorInternal>(ref reader, options);
        return new InstitutionsError(error!.Country);
    }

    public override void Write(Utf8JsonWriter writer, InstitutionsError value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}

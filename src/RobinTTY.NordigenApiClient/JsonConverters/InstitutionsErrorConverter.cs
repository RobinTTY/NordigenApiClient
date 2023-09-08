using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using RobinTTY.NordigenApiClient.Models.Errors;

namespace RobinTTY.NordigenApiClient.JsonConverters;
internal class InstitutionsErrorConverter : JsonConverter<InstitutionsError>
{
    public override InstitutionsError Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions? options)
    {
        var error = JsonSerializer.Deserialize<InstitutionsErrorInternal>(ref reader, options);
        if (error is not null)
            return error.Country is not null ? new InstitutionsError(error.Country) : new InstitutionsError(new BasicError(error.Summary!, error.Detail!));
        throw new SerializationException("Couldn't deserialize institutions error. please report this issue to the library author: https://github.com/RobinTTY/NordigenApiClient/issues.");
    }

    public override void Write(Utf8JsonWriter writer, InstitutionsError value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}

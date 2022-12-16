using System.Text.Json;
using System.Text.Json.Serialization;
using RobinTTY.NordigenApiClient.Utility;

namespace RobinTTY.NordigenApiClient.JsonConverters;

internal class EnumDescriptionConverter<T> : JsonConverter<T> where T : struct
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return EnumDescriptorExtension.StringToEnumValue<T>(value);
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.GetDescription());
    }
}

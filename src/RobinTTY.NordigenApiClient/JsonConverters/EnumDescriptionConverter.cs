using System.Text.Json;
using System.Text.Json.Serialization;
using RobinTTY.NordigenApiClient.Utility;
#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
#endif

namespace RobinTTY.NordigenApiClient.JsonConverters;


#if NET6_0_OR_GREATER
internal class
    EnumDescriptionConverter<
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields)] T> : JsonConverter<T> where T : struct
#else
    internal class EnumDescriptionConverter<T> : JsonConverter<T> where T : struct
#endif
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

using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.JsonConverters;

internal class CultureSpecificDecimalConverter : JsonConverter<decimal>
{
    private static readonly CultureInfo Culture = CultureInfo.GetCultureInfo("en-US");

    public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return string.IsNullOrEmpty(value) ? decimal.MinValue : decimal.Parse(value, NumberStyles.Number, Culture);
    }

    public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(Culture));
    }
}
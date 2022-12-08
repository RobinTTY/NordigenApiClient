using System.Text.Json;
using System.Text.Json.Serialization;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.JsonConverters;

internal class BalanceTypeConverter : JsonConverter<BalanceType>
{
    public override BalanceType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return value switch
        {
            "closingBooked" => BalanceType.ClosingBooked,
            "expected" => BalanceType.Expected,
            "forwardAvailable" => BalanceType.ForwardAvailable,
            "interimAvailable" => BalanceType.InterimAvailable,
            "interimBooked" => BalanceType.InterimBooked,
            "nonInvoiced" => BalanceType.NonInvoiced,
            "openingBooked" => BalanceType.OpeningBooked,
            _ => BalanceType.Undefined
        };
    }

    public override void Write(Utf8JsonWriter writer, BalanceType value, JsonSerializerOptions options)
    {
        var type = value switch
        {
            BalanceType.ClosingBooked => "closingBooked",
            BalanceType.Expected => "expected",
            BalanceType.ForwardAvailable => "forwardAvailable",
            BalanceType.InterimAvailable => "interimAvailable",
            BalanceType.InterimBooked => "interimBooked",
            BalanceType.NonInvoiced => "nonInvoiced",
            BalanceType.OpeningBooked => "openingBooked",
            _ => "undefined"
        };
        writer.WriteStringValue(type);
    }
}

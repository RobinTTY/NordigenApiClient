using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// Pair representing an amount and the currency the amount is denominated in.
/// </summary>
[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
public class AmountCurrencyPair
{
    /// <summary>
    /// The amount.
    /// </summary>
    [JsonPropertyName("amount")]
    public decimal Amount { get; }

    /// <summary>
    /// The currency the amount is denominated in.
    /// </summary>
    [JsonPropertyName("currency")]
    public string Currency { get; }

    /// <summary>
    /// Creates a new instance of <see cref="AmountCurrencyPair" />.
    /// </summary>
    /// <param name="amount">The balance amount.</param>
    /// <param name="currency">The currency the amount is denominated in.</param>
    [JsonConstructor]
    public AmountCurrencyPair(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }
}

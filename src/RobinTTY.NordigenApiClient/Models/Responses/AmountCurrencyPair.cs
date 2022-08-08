using System.Globalization;
using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// Pair representing an amount and currency the amount is denominated in.
/// </summary>
public class AmountCurrencyPair
{
    /// <summary>
    /// The amount as returned by the Nordigen API.
    /// </summary>
    [JsonPropertyName("amount")]
    public string Amount { get; }
    /// <summary>
    /// The parsed amount. Null if amount can't be parsed.
    /// </summary>
    public decimal? AmountParsed
    {
        get
        {
            var success = decimal.TryParse(Amount, NumberStyles.Number, CultureInfo.GetCultureInfo("en-US"), out var amount);
            return success ? amount : null;
        }
    }

    /// <summary>
    /// The currency the amount is denominated in.
    /// </summary>
    [JsonPropertyName("currency")]
    public string Currency { get; }

    /// <summary>
    /// Creates a new instance of <see cref="AmountCurrencyPair"/>.
    /// </summary>
    /// <param name="amount">The balance amount.</param>
    /// <param name="currency">The currency the amount is denominated in.</param>
    [JsonConstructor]
    public AmountCurrencyPair(string amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }
}

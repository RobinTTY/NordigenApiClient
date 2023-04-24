using System.Globalization;
using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// Detailed information about a currency exchange.
/// </summary>
public class CurrencyExchange
{
    /// <summary>
    /// Currency from which an amount is to be converted in a currency conversion. ISO 4217 Alpha 3 currency code (e.g. "USD").
    /// </summary>
    [JsonPropertyName("sourceCurrency")]
    public string SourceCurrency { get; }
    /// <summary>
    /// Currency into which an amount is to be converted in a currency conversion. ISO 4217 Alpha 3 currency code (e.g. "USD").
    /// </summary>
    [JsonPropertyName("targetCurrency")]
    public string TargetCurrency { get; }
    /// <summary>
    /// Currency in which the rate of exchange is expressed in a currency exchange. In the example 1EUR = xxxUSD, the unit currency is EUR.
    /// ISO 4217 Alpha 3 currency code (e.g. "USD").
    /// </summary>
    [JsonPropertyName("unitCurrency")]
    public string UnitCurrency { get; }
    /// <summary>
    /// Factor used to convert an amount from one currency into another. This reflects the price at which one currency was bought with another currency.
    /// </summary>
    [JsonPropertyName("exchangeRate")]
    public string ExchangeRate { get; }

    /// <summary>
    /// The <see cref="ExchangeRate"/> parsed as a decimal number. Null if amount can't be parsed.
    /// </summary>
    public decimal? ExchangeRateParsed
    {
        get
        {
            var success = decimal.TryParse(ExchangeRate, NumberStyles.Number, CultureInfo.GetCultureInfo("en-US"), out var amount);
            return success ? amount : null;
        }
    }
    /// <summary>
    /// Date at which an exchange rate is quoted.
    /// </summary>
    [JsonPropertyName("quotationDate")]
    public DateTime? QuotationDate { get; }
    /// <summary>
    /// Unique identification to unambiguously identify the foreign exchange contract.
    /// </summary>
    [JsonPropertyName("contractIdentification")]
    public string? ContractIdentification { get; }

    /// <summary>
    /// Creates a new instance of <see cref="CurrencyExchange"/>.
    /// </summary>
    /// <param name="sourceCurrency">Currency from which an amount is to be converted in a currency conversion. ISO 4217 Alpha 3 currency code (e.g. "USD").</param>
    /// <param name="targetCurrency">Currency into which an amount is to be converted in a currency conversion. ISO 4217 Alpha 3 currency code (e.g. "USD").</param>
    /// <param name="unitCurrency">Currency in which the rate of exchange is expressed in a currency exchange. In the example 1EUR = xxxUSD, the unit currency is EUR.
    /// ISO 4217 Alpha 3 currency code (e.g. "USD").</param>
    /// <param name="exchangeRate">Factor used to convert an amount from one currency into another. This reflects the price at which one currency was bought with another currency.</param>
    /// <param name="quotationDate">Date at which an exchange rate is quoted.</param>
    /// <param name="contractIdentification">Unique identification to unambiguously identify the foreign exchange contract.</param>
    public CurrencyExchange(string sourceCurrency, string targetCurrency, string unitCurrency, string exchangeRate, DateTime? quotationDate, string? contractIdentification)
    {
        SourceCurrency = sourceCurrency;
        TargetCurrency = targetCurrency;
        UnitCurrency = unitCurrency;
        ExchangeRate = exchangeRate;
        QuotationDate = quotationDate;
        ContractIdentification = contractIdentification;
    }
}

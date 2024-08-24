using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// The account details of a creditor/debtor.
/// </summary>
public class AccountDetails
{
    /// <summary>
    /// The IBAN of the bank account.
    /// </summary>
    [JsonPropertyName("iban")]
    public string? Iban { get; }

    /// <summary>
    /// Basic Bank Account Number represents a country-specific bank account number.
    /// This data element is used for payment accounts which have no IBAN.
    /// </summary>
    [JsonPropertyName("bban")]
    public string? Bban { get; }

    /// <summary>
    /// Primary account number (unique identifier on credit cards, debit cards, and other types of payment cards).
    /// </summary>
    [JsonPropertyName("pan")]
    public string? Pan { get; }

    /// <summary>
    /// Masked primary account number (unique identifier on credit cards, debit cards, and other types of payment cards).
    /// </summary>
    [JsonPropertyName("maskedPan")]
    public string? MaskedPan { get; }

    /// <summary>
    /// An alias to a payment account via a registered mobile phone number.
    /// </summary>
    [JsonPropertyName("msisdn")]
    public string? Msisdn { get; }

    /// <summary>
    /// The currency the amount is denominated in.
    /// </summary>
    [JsonPropertyName("currency")]
    public string Currency { get; }

    /// <summary>
    /// Creates a new instance of <see cref="AccountDetails" />.
    /// </summary>
    /// <param name="iban">The IBAN of the bank account.</param>
    /// <param name="bban">
    /// Basic Bank Account Number represents a country-specific bank account number.
    /// This data element is used for payment accounts which have no IBAN.
    /// </param>
    /// <param name="pan">
    /// Primary account number (unique identifier on credit cards, debit cards, and other types of payment
    /// cards).
    /// </param>
    /// <param name="maskedPan">
    /// Masked primary account number (unique identifier on credit cards, debit cards, and other types
    /// of payment cards).
    /// </param>
    /// <param name="msisdn">An alias to a payment account via a registered mobile phone number.</param>
    /// <param name="currency">The currency the amount is denominated in.</param>
    [JsonConstructor]
    public AccountDetails(string? iban, string? bban, string? pan, string? maskedPan, string? msisdn, string currency)
    {
        Iban = iban;
        Bban = bban;
        Pan = pan;
        MaskedPan = maskedPan;
        Msisdn = msisdn;
        Currency = currency;
    }
}
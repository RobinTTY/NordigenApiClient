using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// A balance of a <see cref="BankAccount"/>.
/// </summary>
public class Balance
{
    /// <summary>
    /// The balance amount including details about the currency the amount is denominated in.
    /// </summary>
    [JsonPropertyName("balanceAmount")]
    public BalanceAmount BalanceAmount { get; }
    /// <summary>
    /// Type of the balance (e.g. closingBooked).
    /// </summary>
    [JsonPropertyName("balanceType")]
    public string BalanceType { get; }
    /// <summary>
    /// The effective date of the balance.
    /// </summary>
    [JsonPropertyName("referenceDate")]
    public DateTime ReferenceDate { get; }

    /// <summary>
    /// Creates a new instance of <see cref="Balance"/>.
    /// </summary>
    /// <param name="balanceAmount">The balance amount including details about the currency the amount is denominated in.</param>
    /// <param name="balanceType">Type of the balance (e.g. closingBooked).</param>
    /// <param name="referenceDate">The effective date of the balance.</param>
    [JsonConstructor]
    public Balance(BalanceAmount balanceAmount, string balanceType, DateTime referenceDate)
    {
        BalanceAmount = balanceAmount;
        BalanceType = balanceType;
        ReferenceDate = referenceDate;
    }
}

/// <summary>
/// A balance amount which includes details about the currency the amount is denominated in.
/// </summary>
public class BalanceAmount
{
    /// <summary>
    /// The balance amount.
    /// </summary>
    [JsonPropertyName("amount")]
    public decimal Amount { get; }
    /// <summary>
    /// The currency the amount is denominated in.
    /// </summary>
    [JsonPropertyName("currency")]
    public string Currency { get; }

    /// <summary>
    /// Creates a new instance of <see cref="BalanceAmount"/>.
    /// </summary>
    /// <param name="amount">The balance amount.</param>
    /// <param name="currency">The currency the amount is denominated in.</param>
    [JsonConstructor]
    public BalanceAmount(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }
}
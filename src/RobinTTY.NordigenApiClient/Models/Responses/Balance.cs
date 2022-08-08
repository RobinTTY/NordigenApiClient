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
    public AmountCurrencyPair BalanceAmount { get; }
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
    public Balance(AmountCurrencyPair balanceAmount, string balanceType, DateTime referenceDate)
    {
        BalanceAmount = balanceAmount;
        BalanceType = balanceType;
        ReferenceDate = referenceDate;
    }
}

/// <summary>
/// Only used for deserialization purposes (to deal with returned JSON structure).
/// </summary>
internal class BalanceJsonWrapper
{
    /// <summary>
    /// A list of account balances.
    /// </summary>
    [JsonPropertyName("balances")]
    public List<Balance> Balances { get; }

    /// <summary>
    /// Creates a new instance of <see cref="BalanceJsonWrapper"/>.
    /// </summary>
    /// <param name="balances">A list of account balances.</param>
    public BalanceJsonWrapper(List<Balance> balances)
    {
        Balances = balances;
    }
}

using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// A balance of a <see cref="BankAccount"/>.
/// <para>Reference: <see href="https://nordigen.com/en/docs/account-information/output/balance/"/></para>
/// </summary>
public class Balance
{
    /// <summary>
    /// The balance amount including details about the currency the amount is denominated in.
    /// </summary>
    [JsonPropertyName("balanceAmount")]
    public AmountCurrencyPair BalanceAmount { get; }
    /// <summary>
    /// Type of the balance (e.g. <see cref="BalanceType.ClosingBooked"/>).
    /// </summary>
    [JsonPropertyName("balanceType")]
    public BalanceType BalanceType { get; }
    /// <summary>
    /// The effective date of the balance.
    /// </summary>
    [JsonPropertyName("referenceDate")]
    public DateTime ReferenceDate { get; }
    /// <summary>
    /// A flag indicating if the credit limit of the corresponding account is included in the calculation of the balance, where applicable.
    /// </summary>
    [JsonPropertyName("creditLimitIncluded")]
    public bool? CreditLimitIncluded { get; }
    /// <summary>
    /// This data element might be used to indicate e.g. with the expected or booked balance that no action is known on the account, which is not yet booked.
    /// </summary>
    [JsonPropertyName("lastChangeDateTime")]
    public DateTime? LastChangeDateTime { get; }
    /// <summary>
    /// Entry reference of the last committed transaction to support the TPP in identifying whether all end users transactions are already known.
    /// </summary>
    [JsonPropertyName("lastCommittedTransaction")]
    public string? LastCommittedTransaction { get; }

    /// <summary>
    /// Creates a new instance of <see cref="Balance"/>.
    /// </summary>
    /// <param name="balanceAmount">The balance amount including details about the currency the amount is denominated in.</param>
    /// <param name="balanceType">Type of the balance (e.g. closingBooked).</param>
    /// <param name="referenceDate">The effective date of the balance.</param>
    /// <param name="creditLimitIncluded">A flag indicating if the credit limit of the corresponding account is included in the calculation of the balance, where applicable.</param>
    /// <param name="lastChangeDateTime">This data element might be used to indicate e.g. with the expected or booked balance that no action is known on the account, which is not yet booked.</param>
    /// <param name="lastCommittedTransaction">Entry reference of the last committed transaction to support the TPP in identifying whether all end users transactions are already known.</param>
    [JsonConstructor]
    public Balance(AmountCurrencyPair balanceAmount, BalanceType balanceType, DateTime referenceDate, bool? creditLimitIncluded, DateTime? lastChangeDateTime, string? lastCommittedTransaction)
    {
        BalanceAmount = balanceAmount;
        BalanceType = balanceType;
        ReferenceDate = referenceDate;
        CreditLimitIncluded = creditLimitIncluded;
        LastChangeDateTime = lastChangeDateTime;
        LastCommittedTransaction = lastCommittedTransaction;
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

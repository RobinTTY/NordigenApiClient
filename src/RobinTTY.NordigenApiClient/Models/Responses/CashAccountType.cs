using System.ComponentModel;
using System.Text.Json.Serialization;
using RobinTTY.NordigenApiClient.JsonConverters;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// Specifies the nature, or use, of a cash account as defined by ISO 20022.
/// <para>
/// Reference:
/// <a href="https://www.iso20022.org/catalogue-messages/additional-content-messages/external-code-sets">
/// ISO20022 External
/// Code Sets
/// </a>
/// </para>
/// </summary>
[JsonConverter(typeof(EnumDescriptionConverter<CashAccountType>))]
public enum CashAccountType
{
    /// <summary>
    /// An undefined cash account type. Assigned if the type couldn't be matched to any known types.
    /// </summary>
    Undefined,

    /// <summary>
    /// Account used to post debits and credits when no specific account has been nominated.
    /// </summary>
    [Description("CACC")] Current,

    /// <summary>
    /// Account used for credit card payments.
    /// </summary>
    [Description("CARD")] Card,

    /// <summary>
    /// Account used for the payment of cash.
    /// </summary>
    [Description("CASH")] CashPayment,

    /// <summary>
    /// Account used for charges if different from the account for payment.
    /// </summary>
    [Description("CHAR")] Charges,

    /// <summary>
    /// Account used for payment of income if different from the current cash account.
    /// </summary>
    [Description("CISH")] CashIncome,

    /// <summary>
    /// Account used for commission if different from the account for payment.
    /// </summary>
    [Description("COMM")] Commission,

    /// <summary>
    /// Account used to post settlement debit and credit entries on behalf of a designated Clearing Participant.
    /// </summary>
    [Description("CPAC")] ClearingParticipantSettlement,

    /// <summary>
    /// Account used for savings with special interest and withdrawal terms.
    /// </summary>
    [Description("LLSV")] LimitedLiquiditySavings,

    /// <summary>
    /// Account used for loans.
    /// </summary>
    [Description("LOAN")] Loan,

    /// <summary>
    /// Account used for a marginal lending facility.
    /// </summary>
    [Description("MGLD")] MarginalLending,

    /// <summary>
    /// Account used for money markets if different from the cash account.
    /// </summary>
    [Description("MOMA")] MoneyMarket,

    /// <summary>
    /// Account used for non-resident external.
    /// </summary>
    [Description("NREX")] NonResidentExternal,

    /// <summary>
    /// Account used for overdrafts.
    /// </summary>
    [Description("ODFT")] Overdraft,

    /// <summary>
    /// Account used for overnight deposits.
    /// </summary>
    [Description("ONDP")] OvernightDeposit,

    /// <summary>
    /// Account not otherwise specified.
    /// </summary>
    [Description("OTHR")] Other,

    /// <summary>
    /// Account used to post debit and credit entries, as a result of transactions cleared and settled through a specific
    /// clearing and settlement system.
    /// </summary>
    [Description("SACC")] Settlement,

    /// <summary>
    /// Accounts used for salary payments.
    /// </summary>
    [Description("SLRY")] Salary,

    /// <summary>
    /// Account used for savings.
    /// </summary>
    [Description("SVGS")] Savings,

    /// <summary>
    /// Account used for taxes if different from the account for payment.
    /// </summary>
    [Description("TAXE")] Taxes,

    /// <summary>
    /// A transacting account is the most basic type of bank account that you can get. The main difference between
    /// transaction and check accounts is
    /// that you usually do not get a checkbook with your transacting account and neither are you offered an overdraft
    /// facility.
    /// </summary>
    [Description("TRAN")] Transacting,

    /// <summary>
    /// Account used for trading if different from the current cash account.
    /// </summary>
    [Description("TRAS")] CashTrading,

    /// <summary>
    /// Account created virtually to facilitate collection and reconciliation.
    /// </summary>
    [Description("VACC")] Virtual,

    /// <summary>
    /// Non-Resident Individual/Entity Foreign Current held domestically.
    /// </summary>
    [Description("NFCA")] NonResidentForeignCurrent
}

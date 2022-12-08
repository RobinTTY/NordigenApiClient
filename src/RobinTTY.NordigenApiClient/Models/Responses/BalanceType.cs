namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// Identifies the type of a balance.
/// <para>Reference: <see href="https://nordigen.com/en/docs/account-information/output/balance/#:~:text=of%20the%20balance-,Balance%20Type,-TYPE"/></para>
/// </summary>
public enum BalanceType
{
    /// <summary>
    /// An undefined balance type. Assigned if the type couldn't be matched to any known types.
    /// </summary>
    Undefined,
    /// <summary>
    /// Balance of the account at the end of the pre-agreed account reporting period. It is the sum of the opening booked balance at the beginning of
    /// the period and all entries booked to the account during the pre-agreed account reporting period. For card-accounts, this is composed of invoiced,
    /// but not yet paid entries.
    /// </summary>
    ClosingBooked,
    /// <summary>
    /// Balance composed of booked entries and pending items known at the time of calculation, which projects the end of day balance if everything is
    /// booked on the account and no other entry is posted. For card accounts, this is composed of
    /// <list type="bullet">
    /// <item><description>invoiced, but not yet paid entries,</description></item>
    /// <item><description>not yet invoiced but already booked entries and</description></item>
    /// <item><description>pending items (not yet booked)</description></item>
    /// </list>
    /// </summary>
    Expected,
    /// <summary>
    /// Forward available balance of money that is at the disposal of the account owner on the date specified.
    /// </summary>
    ForwardAvailable,
    /// <summary>
    /// Available balance calculated in the course of the account servicer's business day, at the time specified, and subject to further changes during
    /// the business day. The interim balance is calculated on the basis of booked credit and debit items during the calculation time/period specified.
    /// For card-accounts, this is composed of:
    /// <list type="bullet">
    /// <item><description>invoiced, but not yet paid entries,</description></item>
    /// <item><description>not yet invoiced but already booked entries</description></item>
    /// </list>
    /// </summary>
    InterimAvailable,
    /// <summary>
    /// Balance calculated in the course of the account servicer's business day, at the time specified, and subject to further changes during the
    /// business day. The interim balance is calculated on the basis of booked credit and debit items during the calculation time/period specified.
    /// </summary>
    InterimBooked,
    /// <summary>
    /// Only for card accounts, to be defined yet.
    /// </summary>
    NonInvoiced,
    /// <summary>
    /// Book balance of the account at the beginning of the account reporting period. It always equals the closing book balance from the previous report.
    /// </summary>
    OpeningBooked
}

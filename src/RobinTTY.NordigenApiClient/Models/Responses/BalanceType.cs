﻿using System.ComponentModel;
using System.Text.Json.Serialization;
using RobinTTY.NordigenApiClient.JsonConverters;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// Identifies the type of a balance.
/// <para>
/// Reference:
/// <a href="https://developer.gocardless.com/bank-account-data/balance#balance_type">GoCardless documentation</a>
/// </para>
/// </summary>
[JsonConverter(typeof(EnumDescriptionConverter<BalanceType>))]
public enum BalanceType
{
    /// <summary>
    /// An undefined balance type. Assigned if the type couldn't be matched to any known types.
    /// </summary>
    Undefined,

    /// <summary>
    /// Closing balance of amount of money that is at the disposal of the account owner on the date specified.
    /// </summary>
    [Description("closingAvailable")]
    ClosingAvailable,

    /// <summary>
    /// Balance of the account at the end of the pre-agreed account reporting period. It is the sum of the opening booked
    /// balance at the beginning of
    /// the period and all entries booked to the account during the pre-agreed account reporting period. For card-accounts,
    /// this is composed of invoiced,
    /// but not yet paid entries.
    /// </summary>
    [Description("closingBooked")]
    ClosingBooked,

    /// <summary>
    /// Balance composed of booked entries and pending items known at the time of calculation, which projects the end of
    /// day balance if everything is
    /// booked on the account and no other entry is posted. For card accounts, this is composed of
    /// <list type="bullet">
    ///     <item>
    ///         <description>invoiced, but not yet paid entries,</description>
    ///     </item>
    ///     <item>
    ///         <description>not yet invoiced but already booked entries and</description>
    ///     </item>
    ///     <item>
    ///         <description>pending items (not yet booked)</description>
    ///     </item>
    /// </list>
    /// </summary>
    [Description("expected")]
    Expected,

    /// <summary>
    /// Forward available balance of money that is at the disposal of the account owner on the date specified.
    /// </summary>
    [Description("forwardAvailable")]
    ForwardAvailable,

    /// <summary>
    /// Balance for informational purposes.
    /// </summary>
    [Description("information")]
    Information,

    /// <summary>
    /// Available balance calculated in the course of the account servicer's business day, at the time specified, and
    /// subject to further changes during
    /// the business day. The interim balance is calculated on the basis of booked credit and debit items during the
    /// calculation time/period specified.
    /// For card-accounts, this is composed of:
    /// <list type="bullet">
    ///     <item>
    ///         <description>invoiced, but not yet paid entries,</description>
    ///     </item>
    ///     <item>
    ///         <description>not yet invoiced but already booked entries</description>
    ///     </item>
    /// </list>
    /// </summary>
    [Description("interimAvailable")]
    InterimAvailable,

    /// <summary>
    /// Balance calculated in the course of the account servicer's business day, at the time specified, and subject to
    /// further changes during the
    /// business day. The interim balance is calculated on the basis of booked credit and debit items during the
    /// calculation time/period specified.
    /// </summary>
    [Description("interimBooked")]
    InterimBooked,

    /// <summary>
    /// Only for card accounts, to be defined yet.
    /// </summary>
    [Description("nonInvoiced")]
    NonInvoiced,

    /// <summary>
    /// Book balance of the account at the beginning of the account reporting period. It always equals the closing book
    /// balance from the previous report.
    /// </summary>
    [Description("openingBooked")]
    OpeningBooked,

    /// <summary>
    /// Opening balance of amount of money that is at the disposal of the account owner on the date specified.
    /// </summary>
    [Description("openingAvailable")]
    OpeningAvailable,

    /// <summary>
    /// Balance of the account at the previously closed account reporting period. The opening booked balance for the new
    /// period has to be equal to this
    /// balance. Usage: the previously booked closing balance should equal (inclusive date) the booked closing balance of
    /// the date it references and equal
    /// the actual booked opening balance of the current date.
    /// </summary>
    [Description("previouslyClosedBooked")]
    PreviouslyClosedBooked
}
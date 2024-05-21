using System.ComponentModel;
using System.Text.Json.Serialization;
using RobinTTY.NordigenApiClient.JsonConverters;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// Indicates the status of a <see cref="Requisition" />.
/// A requisition can assume one of nine statuses. The sequence of statuses is given in stages.
/// <para>
/// Reference: <a href="https://developer.gocardless.com/bank-account-data/statuses">GoCardless Documentation</a>
/// </para>
/// </summary>
[JsonConverter(typeof(EnumDescriptionConverter<RequisitionStatus>))]
public enum RequisitionStatus
{
    /// <summary>
    /// An undefined requisition status. Assigned if the status couldn't be matched to any known option.
    /// </summary>
    Undefined,

    /// <summary>
    /// Indicates that the requisition has been successfully created (stage 1).
    /// </summary>
    [Description("CR")]
    Created,

    /// <summary>
    /// Indicates that the account holder is currently in the process of giving consent through Nordigen's consent screen
    /// (stage 2).
    /// </summary>
    [Description("GC")]
    GivingConsent,

    /// <summary>
    /// Indicates that the account holder has been redirected to the financial institution for authentication (stage 3).
    /// </summary>
    [Description("UA")]
    UndergoingAuthentication,

    /// <summary>
    /// Indicates that either the SSN verification has failed or the account holder has entered incorrect credentials
    /// (stage 4).
    /// </summary>
    [Description("RJ")]
    Rejected,

    /// <summary>
    /// Indicates that the account holder is currently in the process of selecting accounts (stage 5).
    /// </summary>
    [Description("SA")]
    SelectingAccounts,

    /// <summary>
    /// Indicates that the end user is currently in the process of granting access to their account information (stage 6).
    /// </summary>
    [Description("GA")]
    GrantingAccess,

    /// <summary>
    /// Indicates that an account has been successfully linked to the requisition (stage 7).
    /// </summary>
    [Description("LN")]
    Linked,

    /// <summary>
    /// Indicates that the requisition is suspended due to numerous consecutive errors that happened while accessing one of
    /// the linked accounts (stage 8).
    /// </summary>
    [Description("SU")]
    Suspended,

    /// <summary>
    /// Indicates that access to the linked accounts has expired as defined in the end user agreement (stage 9).
    /// </summary>
    [Description("EX")]
    Expired
}

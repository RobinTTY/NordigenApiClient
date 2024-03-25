using System.ComponentModel;
using System.Text.Json.Serialization;
using RobinTTY.NordigenApiClient.JsonConverters;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// Identifies the status of the bank account in reference to the Nordigen platform.
/// <para>
/// Reference:
/// <see
///     href="https://developer.gocardless.com/bank-account-data/statuses#:~:text=is%20starting%20status.-,Accounts%20endpoint,-Status%20long" />
/// </para>
/// </summary>
[JsonConverter(typeof(EnumDescriptionConverter<BankAccountStatus>))]
public enum BankAccountStatus
{
    /// <summary>
    /// An undefined bank account status. Assigned if the status couldn't be matched to any known option.
    /// </summary>
    Undefined,

    /// <summary>
    /// Indicates that the user has successfully authenticated and an account has been discovered.
    /// </summary>
    [Description("DISCOVERED")] Discovered,

    /// <summary>
    /// Indicates that an error was encountered in processing the account.
    /// </summary>
    [Description("ERROR")] Error,

    /// <summary>
    /// Indicates that the access to the account has expired as defined in the end user agreement.
    /// </summary>
    [Description("EXPIRED")] Expired,

    /// <summary>
    /// Indicates that the account is being processed by the institution.
    /// </summary>
    [Description("PROCESSING")] Processing,

    /// <summary>
    /// Indicates that the account has been successfully processed.
    /// </summary>
    [Description("READY")] Ready,

    /// <summary>
    /// Indicates that the account has been suspended due to more than 10 consecutive failed attempts to access the account.
    /// </summary>
    [Description("SUSPENDED")] Suspended
}

using System.ComponentModel;
using RobinTTY.NordigenApiClient.JsonConverters;
using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// Identifies the status of the bank account as defined by the ISO 20022 standard.
/// </summary>
[JsonConverter(typeof(EnumDescriptionConverter<IsoBankAccountStatus>))]
public enum IsoBankAccountStatus
{
    /// <summary>
    /// An undefined bank account status. Assigned if the status couldn't be matched to any known option.
    /// </summary>
    Undefined,
    /// <summary>
    /// Account is available.
    /// </summary>
    [Description("enabled")]
    Enabled,
    /// <summary>
    /// Account has been terminated.
    /// </summary>
    [Description("deleted")]
    Deleted,
    /// <summary>
    /// Account has been blocked (e.g. for legal reasons).
    /// </summary>
    [Description("blocked")]
    Blocked
}

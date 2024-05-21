using System.ComponentModel;
using System.Text.Json.Serialization;
using RobinTTY.NordigenApiClient.JsonConverters;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// Access scopes can be used to limit the access to the 3 major data blocks the GoCardless API is offering.
/// This feature is not supported by all banks, check <see cref="Institution.SupportedFeatures" /> to verify if it is.
/// </summary>
[JsonConverter(typeof(EnumDescriptionConverter<AccessScope>))]
public enum AccessScope
{
    /// <summary>
    /// An undefined access scope. Assigned if the scope couldn't be matched to any known types.
    /// </summary>
    Undefined,

    /// <summary>
    /// Access scope required to access the balances of an account.
    /// </summary>
    [Description("balances")]
    Balances,

    /// <summary>
    /// Access scope required to access the transactions of an account.
    /// </summary>
    [Description("transactions")]
    Transactions,

    /// <summary>
    /// Access scope needed to access account details.
    /// </summary>
    [Description("details")]
    Details
}

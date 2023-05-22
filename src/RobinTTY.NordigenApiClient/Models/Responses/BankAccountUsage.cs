using RobinTTY.NordigenApiClient.JsonConverters;
using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// Specifies the nature, or use, of a cash account as defined by ISO 20022.
/// <para>Reference: <see href="https://www.iso20022.org/catalogue-messages/additional-content-messages/external-code-sets"/></para>
/// </summary>
[JsonConverter(typeof(EnumDescriptionConverter<BankAccountUsage>))]
public enum BankAccountUsage
{
    /// <summary>
    /// An undefined usage type. Assigned if the type couldn't be matched to any known types.
    /// </summary>
    Undefined,
    /// <summary>
    /// A private personal bank account.
    /// </summary>
    Private,
    /// <summary>
    /// A professional bank account.
    /// </summary>
    Organization
}

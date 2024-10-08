﻿using System.Text.Json.Serialization;
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
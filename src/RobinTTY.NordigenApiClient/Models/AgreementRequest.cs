using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models;

/// <summary>
/// The parts of an end user agreement that are necessary to create it via the Nordigen API.
/// Determines the scope and length of access to data provided by institutions.
/// </summary>
public class AgreementRequest
{
    /// <summary>
    /// The length of the transaction history in days.
    /// </summary>
    [JsonPropertyName("max_historical_days")]
    public uint MaxHistoricalDays { get; set; }
    /// <summary>
    /// The length the access to the account will be valid for.
    /// </summary>
    [JsonPropertyName("access_valid_for_days")]
    public uint AccessValidForDays { get; set; }
    /// <summary>
    /// The scope of information that can be accessed.
    /// </summary>
    [JsonPropertyName("access_scope")]
    public List<string> AccessScope { get; set; }
    /// <summary>
    /// The institution this agreement refers to.
    /// </summary>
    [JsonPropertyName("institution_id")]
    public string InstitutionId { get; set; }

    /// <summary>
    /// Creates a new instance of <see cref="AgreementRequest"/>.
    /// </summary>
    /// <param name="maxHistoricalDays">The length of the transaction history in days.</param>
    /// <param name="accessValidForDays">The length the access to the account will be valid for.</param>
    /// <param name="accessScope">The scope of information that can be accessed.</param>
    /// <param name="institutionId">The institution this agreement refers to.</param>
    public AgreementRequest(uint maxHistoricalDays, uint accessValidForDays, List<string> accessScope, string institutionId)
    {
        MaxHistoricalDays = maxHistoricalDays;
        AccessValidForDays = accessValidForDays;
        AccessScope = accessScope;
        InstitutionId = institutionId;
    }
}

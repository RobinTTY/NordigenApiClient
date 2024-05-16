using System.Text.Json.Serialization;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Models.Requests;

/// <summary>
/// The required information to create an end user agreement.
/// Determines the scope and length of access to data provided by institutions.
/// </summary>
internal class CreateAgreementRequest
{
    /// <summary>
    /// The institution this agreement will refer to.
    /// </summary>
    [JsonPropertyName("institution_id")]
    public string InstitutionId { get; set; }
    
    /// <summary>
    /// The access scope, which defines which information can be accessed, to request.
    /// </summary>
    [JsonPropertyName("access_scope")]
    public List<AccessScope> AccessScope { get; set; }
    
    /// <summary>
    /// The length of the transaction history in days to request.
    /// </summary>
    [JsonPropertyName("max_historical_days")]
    public uint MaxHistoricalDays { get; set; }

    /// <summary>
    /// The length the access to the account will be valid for to request.
    /// </summary>
    [JsonPropertyName("access_valid_for_days")]
    public uint AccessValidForDays { get; set; }

    /// <summary>
    /// Creates a new instance of <see cref="CreateAgreementRequest" />.
    /// </summary>
    /// <param name="institutionId">The institution this agreement will refer to.</param>
    /// <param name="accessScope">The access scope, which defines which information can be accessed, to request.</param>
    /// <param name="maxHistoricalDays">The length of the transaction history in days to request.</param>
    /// <param name="accessValidForDays">The length the access to the account will be valid for to request.</param>
    [JsonConstructor]
    public CreateAgreementRequest(string institutionId, List<AccessScope> accessScope, uint maxHistoricalDays = 90,
        uint accessValidForDays = 90)
    {
        MaxHistoricalDays = maxHistoricalDays;
        AccessValidForDays = accessValidForDays;
        AccessScope = accessScope;
        InstitutionId = institutionId;
    }
}

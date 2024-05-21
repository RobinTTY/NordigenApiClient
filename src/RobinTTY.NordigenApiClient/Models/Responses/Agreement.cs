using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// An end user agreement which determines the scope and length of access to data provided by institutions.
/// </summary>
public class Agreement
{
    /// <summary>
    /// The id of the agreement assigned by the Nordigen API.
    /// </summary>
    [JsonPropertyName("id")]
    public Guid Id { get; }

    /// <summary>
    /// Time when the agreement was created.
    /// </summary>
    [JsonPropertyName("created")]
    public DateTime Created { get; }

    /// <summary>
    /// Time when the agreement was accepted.
    /// </summary>
    [JsonPropertyName("accepted")]
    public DateTime? Accepted { get; }

    /// <summary>
    /// The institution this agreement refers to.
    /// </summary>
    [JsonPropertyName("institution_id")]
    public string InstitutionId { get; set; }

    /// <summary>
    /// The scope of information that can be accessed.
    /// </summary>
    [JsonPropertyName("access_scope")]
    public List<AccessScope> AccessScope { get; set; }

    /// <summary>
    /// The length of the transaction history in days.
    /// </summary>
    [JsonPropertyName("max_historical_days")]
    public uint MaxHistoricalDays { get; set; }

    /// <summary>
    /// The length the access to the account is valid for.
    /// </summary>
    [JsonPropertyName("access_valid_for_days")]
    public uint AccessValidForDays { get; set; }

    /// <summary>
    /// Creates a new instance of <see cref="Agreement" />.
    /// </summary>
    /// <param name="id">The id of the agreement assigned by the Nordigen API.</param>
    /// <param name="created">Time when the agreement was created.</param>
    /// <param name="accepted">Time when the agreement was accepted.</param>
    /// <param name="institutionId">The institution this agreement refers to.</param>
    /// <param name="maxHistoricalDays">The length of the transaction history in days.</param>
    /// <param name="accessValidForDays">The length the access to the account will be valid for.</param>
    /// <param name="accessScope">The scope of information that can be accessed.</param>
    [JsonConstructor]
    public Agreement(Guid id, DateTime created, DateTime? accepted, string institutionId, uint maxHistoricalDays,
        uint accessValidForDays, List<AccessScope> accessScope)
    {
        Id = id;
        Created = created;
        Accepted = accepted;
        InstitutionId = institutionId;
        AccessScope = accessScope;
        MaxHistoricalDays = maxHistoricalDays;
        AccessValidForDays = accessValidForDays;
    }
}

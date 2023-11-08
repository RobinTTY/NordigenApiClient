using System.Text.Json.Serialization;
using RobinTTY.NordigenApiClient.Models.Requests;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
///     An end user agreement which determines the scope and length of access to data provided by institutions.
/// </summary>
public class Agreement : CreateAgreementRequest
{
    /// <summary>
    ///     Creates a new instance of <see cref="Agreement" />.
    /// </summary>
    /// <param name="id">The id of the agreement assigned by the Nordigen API.</param>
    /// <param name="created">Time when the agreement was created.</param>
    /// <param name="maxHistoricalDays">The length of the transaction history in days.</param>
    /// <param name="accessValidForDays">The length the access to the account will be valid for.</param>
    /// <param name="accessScope">The scope of information that can be accessed.</param>
    /// <param name="accepted">Time when the agreement was accepted.</param>
    /// <param name="institutionId">The institution this agreement refers to.</param>
    [JsonConstructor]
    public Agreement(
        uint maxHistoricalDays,
        uint accessValidForDays,
        List<string> accessScope,
        string institutionId,
        Guid id,
        DateTime created,
        DateTime? accepted
    ) : base(maxHistoricalDays, accessValidForDays, accessScope, institutionId)
    {
        Id = id;
        Created = created;
        Accepted = accepted;
    }

    /// <summary>
    ///     The id of the agreement assigned by the Nordigen API.
    /// </summary>
    [JsonPropertyName("id")]
    public Guid Id { get; }

    /// <summary>
    ///     Time when the agreement was created.
    /// </summary>
    [JsonPropertyName("created")]
    public DateTime Created { get; }

    /// <summary>
    ///     Time when the agreement was accepted.
    /// </summary>
    [JsonPropertyName("accepted")]
    public DateTime? Accepted { get; }
}

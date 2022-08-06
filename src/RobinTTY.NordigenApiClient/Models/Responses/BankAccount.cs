using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// An account at a banking institution.
/// </summary>
public class BankAccount
{
    /// <summary>
    /// The unique id of the account assigned by the Nordigen API.
    /// </summary>
    [JsonPropertyName("id")]
    public Guid Id { get; }
    /// <summary>
    /// The time this account was created.
    /// </summary>
    [JsonPropertyName("created")]
    public DateTime Created { get; }
    /// <summary>
    /// The time this account was last accessed via the API.
    /// </summary>
    [JsonPropertyName("last_accessed")]
    public DateTime LastAccessed { get; }
    /// <summary>
    /// The IBAN of the account.
    /// </summary>
    [JsonPropertyName("iban")]
    public string Iban { get; }
    /// <summary>
    /// The institution id this account belongs to.
    /// </summary>
    [JsonPropertyName("institution_id")]
    public string InstitutionId { get; }
    /// <summary>
    /// The status of the account (e.g. user has successfully authenticated and account is discovered).
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; }
}

using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// An account at a banking institution.
/// <para>Reference: <see href="https://nordigen.com/en/docs/account-information/output/accounts/"/></para>
/// </summary>
public class BankAccount : MinimalBankAccount
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
    /// The institution id this account belongs to.
    /// </summary>
    [JsonPropertyName("institution_id")]
    public string InstitutionId { get; }
    /// <summary>
    /// The status of the account (e.g. user has successfully authenticated and account is discovered).
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; }

    /// <summary>
    /// Creates a new instance of <see cref="BankAccount"/>.
    /// </summary>
    /// <param name="id">The unique id of the account assigned by the Nordigen API.</param>
    /// <param name="created">The time this account was created.</param>
    /// <param name="lastAccessed">The time this account was last accessed via the API.</param>
    /// <param name="iban">The IBAN of the account.</param>
    /// <param name="institutionId">The institution id this account belongs to.</param>
    /// <param name="status">The status of the account (e.g. user has successfully authenticated and account is discovered).</param>
    [JsonConstructor]
    public BankAccount(Guid id, DateTime created, DateTime lastAccessed, string iban, string institutionId, string status) : base(iban)
    {
        Id = id;
        Created = created;
        LastAccessed = lastAccessed;
        InstitutionId = institutionId;
        Status = status;
    }
}

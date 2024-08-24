using System.Text.Json.Serialization;
using RobinTTY.NordigenApiClient.Endpoints;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// Represents a banking institution as returned by the Nordigen API.
/// </summary>
public class Institution
{
    /// <summary>
    /// The unique id of the institution.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; }

    /// <summary>
    /// The name of the institution.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; }

    /// <summary>
    /// The Business Identifier Code (BIC) of the institution.
    /// </summary>
    [JsonPropertyName("bic")]
    public string Bic { get; }

    /// <summary>
    /// The days for which the transaction history is available.
    /// </summary>
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    [JsonPropertyName("transaction_total_days")]
    public uint TransactionTotalDays { get; }

    /// <summary>
    /// The countries the institution operates in.
    /// </summary>
    [JsonPropertyName("countries")]
    public List<string> Countries { get; }

    /// <summary>
    /// A <see cref="Uri" /> for the logo of the institution.
    /// </summary>
    [JsonPropertyName("logo")]
    public Uri Logo { get; }

    /// <summary>
    /// Supported payment products for this institution. Only populated when calling
    /// <see cref="InstitutionsEndpoint.GetInstitution" />.
    /// </summary>
    [JsonPropertyName("supported_payments")]
    public SupportedPayments? SupportedPayments { get; }

    /// <summary>
    /// Supported features for this institution. Only populated when calling
    /// <see cref="InstitutionsEndpoint.GetInstitution" />.
    /// </summary>
    [JsonPropertyName("supported_features")]
    public List<string>? SupportedFeatures { get; }

    /// <summary>
    /// Undocumented field returned by the GoCardless API. Only populated when calling
    /// <see cref="InstitutionsEndpoint.GetInstitution" />.
    /// </summary>
    [JsonPropertyName("identification_codes")]
    public List<string>? IdentificationCodes { get; }

    /// <summary>
    /// Creates a new instance of <see cref="Institution" />.
    /// </summary>
    /// <param name="id">The unique id of the institution.</param>
    /// <param name="name">The name of the institution.</param>
    /// <param name="bic">The Business Identifier Code (BIC) of the institution.</param>
    /// <param name="transactionTotalDays">The days for which the transaction history is available.</param>
    /// <param name="countries">The countries the institution operates in.</param>
    /// <param name="logo">A <see cref="Uri" /> for the logo of the institution.</param>
    /// <param name="supportedPayments">Supported payment products for this institution.</param>
    /// <param name="supportedFeatures">Supported features for this institution.</param>
    /// <param name="identificationCodes">Undocumented field returned by the GoCardless API.</param>
    [JsonConstructor]
    public Institution(string id, string name, string bic, uint transactionTotalDays, List<string> countries,
        Uri logo, SupportedPayments? supportedPayments, List<string>? supportedFeatures,
        List<string>? identificationCodes)
    {
        Id = id;
        Name = name;
        Bic = bic;
        TransactionTotalDays = transactionTotalDays;
        Countries = countries;
        Logo = logo;
        SupportedPayments = supportedPayments;
        SupportedFeatures = supportedFeatures;
        IdentificationCodes = identificationCodes;
    }
}
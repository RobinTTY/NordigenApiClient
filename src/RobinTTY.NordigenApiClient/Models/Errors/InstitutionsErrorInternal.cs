using System.Text.Json.Serialization;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Models.Errors;

/// <summary>
/// Representation of the institutions error as returned by the Nordigen API.
/// Since this representation doesn't add any useful information (only extra encapsulation)
/// it is transformed to align this error with other errors returned by the API.
/// </summary>
internal class InstitutionsErrorInternal : BasicResponse
{
    [JsonPropertyName("country")]
    public BasicResponse? Country { get; }

    /// <summary>
    /// Creates a new instance of <see cref="InstitutionsErrorInternal" />.
    /// </summary>
    public InstitutionsErrorInternal() { }

    /// <summary>
    /// Creates a new instance of <see cref="InstitutionsErrorInternal" />.
    /// </summary>
    /// <param name="summary">The summary text of the response/error.</param>
    /// <param name="detail">The detailed description of the response/error.</param>
    /// <param name="country">The error response returned for some requests.</param>
    [JsonConstructor]
    public InstitutionsErrorInternal(string? summary, string? detail, BasicResponse? country)
    {
        Country = country;
        Summary = country?.Summary ?? summary;
        Detail = country?.Detail ?? detail;
    }
}

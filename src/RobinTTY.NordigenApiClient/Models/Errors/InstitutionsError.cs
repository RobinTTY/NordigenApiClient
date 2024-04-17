using System.Text.Json.Serialization;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Models.Errors;

/// <summary>
/// An error description as returned by the institutions endpoint of the Nordigen API.
/// </summary>
public class InstitutionsError : BasicResponse
{
    /// <summary>
    /// Creates a new instance of <see cref="InstitutionsError" />.
    /// </summary>
    /// <param name="country">The error related to the requested institutions.</param>
    [JsonConstructor]
    public InstitutionsError(BasicResponse country) : base(country.Summary, country.Detail)
    {
    }
}

/// <summary>
/// Representation of the institutions error as returned by the Nordigen API.
/// Since this representation doesn't add any useful information (only extra encapsulation)
/// it is transformed to align this error with other errors returned by the API.
/// </summary>
internal class InstitutionsErrorInternal
{
    [JsonPropertyName("country")] public BasicResponse? Country { get; }

    [JsonPropertyName("summary")] public string? Summary { get; }

    [JsonPropertyName("detail")] public string? Detail { get; }

    [JsonConstructor]
    public InstitutionsErrorInternal(BasicResponse? country, string? summary, string? detail)
    {
        Country = country;
        Summary = summary;
        Detail = detail;
    }
}

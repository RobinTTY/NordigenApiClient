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
    public InstitutionsError(){}
    
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
[method: JsonConstructor]
internal class InstitutionsErrorInternal(BasicResponse? country, string? summary, string? detail)
{
    [JsonPropertyName("country")] public BasicResponse? Country { get; } = country;

    [JsonPropertyName("summary")] public string? Summary { get; } = summary;

    [JsonPropertyName("detail")] public string? Detail { get; } = detail;
}

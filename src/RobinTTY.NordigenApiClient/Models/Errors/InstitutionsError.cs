using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Errors;

/// <summary>
/// An error description as returned by the institutions endpoint of the Nordigen API.
/// </summary>
public class InstitutionsError : BasicError
{
    /// <summary>
    /// A list of errors related to the requested institutions.
    /// </summary>
    [JsonPropertyName("country")]
    public List<string> Country { get; }

    /// <summary>
    /// Creates a new instance of <see cref="InstitutionsError"/>.
    /// </summary>
    /// <param name="summary">The summary of the API error.</param>
    /// <param name="detail">The detailed description of the API error.</param>
    /// <param name="country">A list of errors related to the requested institutions.</param>
    [JsonConstructor]
    public InstitutionsError(string summary, string detail, List<string> country) : base(summary, detail)
    {
        Country = country;
    }
}

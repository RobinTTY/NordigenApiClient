using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Errors;

/// <summary>
/// An error description as returned by the institutions endpoint of the Nordigen API.
/// </summary>
public class InstitutionsError
{
    /// <summary>
    /// The error related to the requested institutions.
    /// </summary>
    [JsonPropertyName("country")]
    public BasicError Country { get; }

    /// <summary>
    /// Creates a new instance of <see cref="InstitutionsError"/>.
    /// </summary>
    /// <param name="country">The error related to the requested institutions.</param>
    [JsonConstructor]
    public InstitutionsError(BasicError country)
    {
        Country = country;
    }
}

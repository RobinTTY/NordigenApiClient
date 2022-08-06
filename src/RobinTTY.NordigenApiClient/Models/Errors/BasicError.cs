using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Errors;

/// <summary>
/// A basic error description returned by the Nordigen API.
/// </summary>
public class BasicError
{
    /// <summary>
    /// The summary of the API error.
    /// </summary>
    [JsonPropertyName("summary")]
    public string Summary { get; }
    /// <summary>
    /// The detailed description of the API error.
    /// </summary>
    [JsonPropertyName("detail")]
    public string Detail { get; }

    /// <summary>
    /// Creates a new instance of <see cref="BasicError"/>.
    /// </summary>
    /// <param name="summary">The summary of the API error.</param>
    /// <param name="detail">The detailed description of the API error.</param>
    [JsonConstructor]
    public BasicError(string summary, string detail)
    {
        Summary = summary;
        Detail = detail;
    }
}

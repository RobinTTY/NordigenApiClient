using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// A basic response returned by the Nordigen API containing a textual description of a result.
/// </summary>
public class BasicResponse
{
    /// <summary>
    /// Creates a new instance of <see cref="BasicResponse" />.
    /// </summary>
    /// <param name="summary">The summary text of the response.</param>
    /// <param name="details">The detailed description of the response.</param>
    [JsonConstructor]
    public BasicResponse(string? summary, string? details)
    {
        Summary = summary;
        Details = details;
    }

    /// <summary>
    /// The summary text of the response
    /// </summary>
    [JsonPropertyName("summary")]
    public string? Summary { get; }

    /// <summary>
    /// The detailed description of the response.
    /// </summary>
    [JsonPropertyName("details")]
    public string? Details { get; }
}

using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// A basic response/error returned by the Nordigen API containing a textual description of the result.
/// </summary>
public class BasicResponse
{
    /// <summary>
    /// The summary text of the response/error.
    /// </summary>
    [JsonPropertyName("summary")]
    public string? Summary { get; }

    /// <summary>
    /// The detailed description of the response/error.
    /// </summary>
    [JsonPropertyName("detail")]
    public string? Detail { get; }

    /// <summary>
    /// Creates a new instance of <see cref="BasicResponse" />.
    /// </summary>
    /// <param name="summary">The summary text of the response/error.</param>
    /// <param name="detail">The detailed description of the response/error.</param>
    [JsonConstructor]
    public BasicResponse(string? summary, string? detail)
    {
        Summary = summary;
        Detail = detail;
    }
}

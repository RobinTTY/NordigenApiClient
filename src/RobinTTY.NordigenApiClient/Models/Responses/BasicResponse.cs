using System.Text.Json.Serialization;
using RobinTTY.NordigenApiClient.JsonConverters;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// A basic response/error returned by the GoCardless API containing a textual description of the result.
/// </summary>
public class BasicResponse
{
    /// <summary>
    /// The summary text of the response/error.
    /// </summary>
    [JsonPropertyName("summary")]
    [JsonConverter(typeof(StringArrayMergeConverter))]
    public string? Summary { get; init; }

    /// <summary>
    /// The detailed description of the response/error.
    /// </summary>
    [JsonPropertyName("detail")]
    [JsonConverter(typeof(StringArrayMergeConverter))]
    public string? Detail { get; init; }

    /// <summary>
    /// Creates a new instance of <see cref="BasicResponse" />.
    /// </summary>
    public BasicResponse() { }

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

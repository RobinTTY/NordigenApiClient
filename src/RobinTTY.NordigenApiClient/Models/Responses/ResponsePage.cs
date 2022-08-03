using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// A paged response from the Nordigen API.
/// </summary>
/// <typeparam name="T">The contained response type.</typeparam>
public class ResponsePage<T>
{
    /// <summary>
    /// The total number of items that can be accessed via the paged responses.
    /// </summary>
    [JsonPropertyName("count")]
    public uint Count { get; set; }
    /// <summary>
    /// The URI of the next response page.
    /// </summary>
    [JsonPropertyName("next")]
    public Uri? Next { get; set; }
    /// <summary>
    /// The URI of the last response page.
    /// </summary>
    [JsonPropertyName("previous")]
    public Uri? Previous { get; set; }
    /// <summary>
    /// The results that were fetched with this page.
    /// </summary>
    [JsonPropertyName("results")]
    public IEnumerable<T> Results { get; set; }

    /// <summary>
    /// Creates a new instance of <see cref="ResponsePage{T}"/>.
    /// </summary>
    /// <param name="count">The total number of items that can be accessed via the paged responses.</param>
    /// <param name="next">The URI of the next response page.</param>
    /// <param name="previous">The URI of the last response page.</param>
    /// <param name="results">The results that were fetched with this page.</param>
    public ResponsePage(uint count, Uri? next, Uri? previous, IEnumerable<T> results)
    {
        Count = count;
        Next = next;
        Previous = previous;
        Results = results;
    }
}

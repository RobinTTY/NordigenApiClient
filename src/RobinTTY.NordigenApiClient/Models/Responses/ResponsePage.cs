using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// A paged response from the GoCardless API.
/// </summary>
/// <typeparam name="T">The contained response type.</typeparam>
public class ResponsePage<T>
{
    /// <summary>
    /// The total number of items that can be accessed via the paged responses (not necessarily through the current page).
    /// </summary>
    [JsonPropertyName("count")]
    public uint Count { get; }

    /// <summary>
    /// The URI of the next response page.
    /// </summary>
    [JsonPropertyName("next")]
    public Uri? Next { get; }

    /// <summary>
    /// The URI of the last response page.
    /// </summary>
    [JsonPropertyName("previous")]
    public Uri? Previous { get; }

    /// <summary>
    /// The results that were fetched with this page.
    /// </summary>
    [JsonPropertyName("results")]
    public List<T> Results { get; }

    /// <summary>
    /// Creates a new instance of <see cref="ResponsePage{T}" />.
    /// </summary>
    /// <param name="count">The total number of items that can be accessed via the paged responses.</param>
    /// <param name="next">The URI of the next response page.</param>
    /// <param name="previous">The URI of the last response page.</param>
    /// <param name="results">The results that were fetched with this page.</param>
    public ResponsePage(uint count, Uri? next, Uri? previous, List<T> results)
    {
        Count = count;
        Next = next;
        Previous = previous;
        Results = results;
    }

    /// <summary>
    /// Gets the next <see cref="ResponsePage{T}" />, linked to the current one.
    /// </summary>
    /// <param name="nordigenClient">The client to use to retrieve the page.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>
    /// Either a <see cref="NordigenApiResponse{TResponse, TError}" /> containing the next
    /// <see cref="ResponsePage{T}" /> or null if there is no next page to retrieve.
    /// </returns>
    public async Task<NordigenApiResponse<ResponsePage<T>, BasicResponse>?> GetNextPage(NordigenClient nordigenClient,
        CancellationToken cancellationToken = default)
    {
        if (Next is null) return null;
        return await nordigenClient.MakeRequest<ResponsePage<T>, BasicResponse>(Next.AbsoluteUri, HttpMethod.Get,
            cancellationToken);
    }

    /// <summary>
    /// Gets the previous <see cref="ResponsePage{T}" />, linked to the current one.
    /// </summary>
    /// <param name="nordigenClient">The client to use to retrieve the page.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>
    /// Either a <see cref="NordigenApiResponse{TResponse, TError}" /> containing the previous
    /// <see cref="ResponsePage{T}" /> or null if there is no previous page to retrieve.
    /// </returns>
    public async Task<NordigenApiResponse<ResponsePage<T>, BasicResponse>?> GetPreviousPage(
        NordigenClient nordigenClient,
        CancellationToken cancellationToken = default)
    {
        if (Previous is null) return null;
        return await nordigenClient.MakeRequest<ResponsePage<T>, BasicResponse>(Previous.AbsoluteUri, HttpMethod.Get,
            cancellationToken);
    }
}
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace RobinTTY.NordigenApiClient.Models;

/// <summary>
/// A response returned by the Nordigen API.
/// </summary>
/// <typeparam name="T">The type of the returned result.</typeparam>
public class NordigenApiResponse<T> where T : class
{
    /// <summary>
    /// The status code returned by the API.
    /// </summary>
    public HttpStatusCode StatusCode { get; }
    /// <summary>
    /// Indicates whether the HTTP response was successful.
    /// </summary>
    public bool IsSuccess { get; }
    /// <summary>
    /// The result returned by the API. Null if the the HTTP response was not successful.
    /// </summary>
    public T? Result { get; }
    /// <summary>
    /// The error returned by the API. Null if the HTTP response was successful.
    /// </summary>
    public NordigenApiError? Error { get; }

    /// <summary>
    /// Creates a new instance of <see cref="NordigenApiResponse{T}"/>.
    /// </summary>
    /// <param name="statusCode">The status code returned by the API.</param>
    /// <param name="isSuccess">Indicates whether the HTTP response was successful.</param>
    /// <param name="result">The result returned by the API. Null if the the HTTP response was not successful.</param>
    /// <param name="apiError">The error returned by the API. Null if the HTTP response was successful.</param>
    private NordigenApiResponse(HttpStatusCode statusCode, bool isSuccess, T? result, NordigenApiError? apiError)
    {
        StatusCode = statusCode;
        IsSuccess = isSuccess;
        Result = result;
        Error = apiError;
    }

    /// <summary>
    /// Parses a <see cref="NordigenApiResponse{T}"/> from a <see cref="HttpResponseMessage"/>.
    /// </summary>
    /// <param name="response">The <see cref="HttpResponseMessage"/> to parse.</param>
    /// <param name="cancellationToken">A cancellation token to be used to notify in case of cancellation.</param>
    /// <returns>The parsed <see cref="NordigenApiResponse{T}"/>.</returns>
    public static async Task<NordigenApiResponse<T>> FromHttpResponse(HttpResponseMessage response, CancellationToken cancellationToken = default, JsonSerializerOptions? options = null)
    {
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<T>(options, cancellationToken);
            return new NordigenApiResponse<T>(response.StatusCode, response.IsSuccessStatusCode, result, null);
        }
        else
        {
            var result = await response.Content.ReadFromJsonAsync<NordigenApiError>(options, cancellationToken);
            return new NordigenApiResponse<T>(response.StatusCode, response.IsSuccessStatusCode, null, result);
        }
    }
}

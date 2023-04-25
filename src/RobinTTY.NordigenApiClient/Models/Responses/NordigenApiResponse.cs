using System.Net;
using System.Net.Http.Json;
using System.Runtime.Serialization;
using System.Text.Json;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// A response returned by the Nordigen API.
/// </summary>
/// <typeparam name="TResult">The type of the returned result.</typeparam>
/// <typeparam name="TError">The type of the returned error.</typeparam>
public class NordigenApiResponse<TResult, TError> where TResult : class where TError : class
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
    public TResult? Result { get; }
    /// <summary>
    /// The error returned by the API. Null if the HTTP response was successful.
    /// </summary>
    public TError? Error { get; }

    /// <summary>
    /// Creates a new instance of <see cref="NordigenApiResponse{TResult, TError}"/>.
    /// </summary>
    /// <param name="statusCode">The status code returned by the API.</param>
    /// <param name="isSuccess">Indicates whether the HTTP response was successful.</param>
    /// <param name="result">The result returned by the API. Null if the the HTTP response was not successful.</param>
    /// <param name="apiError">The error returned by the API. Null if the HTTP response was successful.</param>
    internal NordigenApiResponse(HttpStatusCode statusCode, bool isSuccess, TResult? result, TError? apiError)
    {
        StatusCode = statusCode;
        IsSuccess = isSuccess;
        Result = result;
        Error = apiError;
    }

    /// <summary>
    /// Parses a <see cref="NordigenApiResponse{TResult, TError}"/> from a <see cref="HttpResponseMessage"/>.
    /// </summary>
    /// <param name="response">The <see cref="HttpResponseMessage"/> to parse.</param>
    /// <param name="cancellationToken">A cancellation token to be used to notify in case of cancellation.</param>
    /// <param name="options"><see cref="JsonSerializerOptions"/> to apply to the deserialization process.</param>
    /// <returns>The parsed <see cref="NordigenApiResponse{TResult, TError}"/>.</returns>
    internal static async Task<NordigenApiResponse<TResult, TError>> FromHttpResponse(HttpResponseMessage response, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
    {
#if NET6_0_OR_GREATER
        var responseJson = await response.Content.ReadAsStringAsync(cancellationToken);
#else
        var responseJson = await response.Content.ReadAsStringAsync();
#endif

        try
        {
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<TResult>(options, cancellationToken);
                return new NordigenApiResponse<TResult, TError>(response.StatusCode, response.IsSuccessStatusCode,
                    result, null);
            }
            else
            {
                var result = await response.Content.ReadFromJsonAsync<TError>(options, cancellationToken);
                return new NordigenApiResponse<TResult, TError>(response.StatusCode, response.IsSuccessStatusCode,
                    null, result);
            }
        }
        catch (JsonException ex)
        {
            throw new SerializationException(
                $"Deserialization failed, please report this issue to the library author: https://github.com/RobinTTY/NordigenApiClient/issues\n" +
                $"The following JSON content caused the problem: {responseJson}", ex);
        }
    }
}

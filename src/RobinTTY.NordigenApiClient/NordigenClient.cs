using System.Net;
using System.Text.Json;
using RobinTTY.NordigenApiClient.Contracts;
using RobinTTY.NordigenApiClient.Endpoints;
using RobinTTY.NordigenApiClient.Events;
using RobinTTY.NordigenApiClient.JsonConverters;
using RobinTTY.NordigenApiClient.Models;
using RobinTTY.NordigenApiClient.Models.Jwt;
using RobinTTY.NordigenApiClient.Models.Responses;
using RobinTTY.NordigenApiClient.Utility;

namespace RobinTTY.NordigenApiClient;

/// <inheritdoc />
public class NordigenClient : INordigenClient
{
    private static readonly SemaphoreSlim TokenSemaphore = new(1, 1);
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _serializerOptions;
    internal readonly NordigenClientCredentials Credentials;
    private JsonWebTokenPair? _jsonWebTokenPair;

    /// <inheritdoc />
    public JsonWebTokenPair? JsonWebTokenPair
    {
        get => _jsonWebTokenPair;
        set
        {
            _jsonWebTokenPair = value;
            if (value is not null)
                TokenPairUpdated?.Invoke(this, new TokenPairUpdatedEventArgs(value));
        }
    }

    /// <inheritdoc />
    public ITokenEndpoint TokenEndpoint { get; }

    /// <inheritdoc />
    public IInstitutionsEndpoint InstitutionsEndpoint { get; }

    /// <inheritdoc />
    public IAgreementsEndpoint AgreementsEndpoint { get; }

    /// <inheritdoc />
    public IRequisitionsEndpoint RequisitionsEndpoint { get; }

    /// <inheritdoc />
    public IAccountsEndpoint AccountsEndpoint { get; }

    /// <summary>
    /// Creates a new instance of <see cref="NordigenClient" />.
    /// </summary>
    /// <param name="httpClient">The <see cref="HttpClient" /> to use.</param>
    /// <param name="credentials">The Nordigen credentials for API access.</param>
    /// <param name="jsonWebTokenPair">An optional JSON web token pair consisting of access and refresh token to use.</param>
    public NordigenClient(HttpClient httpClient, NordigenClientCredentials credentials,
        JsonWebTokenPair? jsonWebTokenPair = null)
    {
        _httpClient = httpClient;
        _serializerOptions = new JsonSerializerOptions
        {
            Converters =
            {
                new JsonWebTokenConverter(), new GuidConverter(),
                new CultureSpecificDecimalConverter()
            }
        };
        _httpClient.BaseAddress ??= new Uri(NordigenEndpointUrls.Base);
        _jsonWebTokenPair = jsonWebTokenPair;

        Credentials = credentials;
        TokenEndpoint = new TokenEndpoint(this);
        InstitutionsEndpoint = new InstitutionsEndpoint(this);
        AgreementsEndpoint = new AgreementsEndpoint(this);
        RequisitionsEndpoint = new RequisitionsEndpoint(this);
        AccountsEndpoint = new AccountsEndpoint(this);
    }

    /// <inheritdoc />
    public event EventHandler<TokenPairUpdatedEventArgs>? TokenPairUpdated;

    /// <summary>
    /// Carries out the request to the GoCardless API, gathering a valid JWT if necessary.
    /// </summary>
    /// <param name="uri">The URI of the API endpoint.</param>
    /// <param name="method">The <see cref="HttpMethod" /> to use for this request.</param>
    /// <param name="cancellationToken">Token to signal cancellation of the operation.</param>
    /// <param name="query">Optional query parameters to add to the request.</param>
    /// <param name="body">Optional body to add to the request.</param>
    /// <param name="useAuthentication">Whether to use authentication.</param>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <typeparam name="TError">The type of the error.</typeparam>
    /// <returns>The response to the request.</returns>
    internal async Task<NordigenApiResponse<TResponse, TError>> MakeRequest<TResponse, TError>(
        string uri,
        HttpMethod method,
        CancellationToken cancellationToken,
        IEnumerable<KeyValuePair<string, string>>? query = null,
        HttpContent? body = null,
        bool useAuthentication = true
    ) where TResponse : class where TError : BasicResponse, new()
    {
        var requestUri = query != null ? uri + UriQueryBuilder.GetQueryString(query) : uri;
        HttpClient client;

        // When an endpoint that requires authentication is called the client tries to update the JWT first
        // - The updating is done using a semaphore to avoid multiple threads trying to update the token simultaneously
        // - If the request to get the token succeeds, the subsequent request is executed
        // - If the request to get the token fails, the error response from the token endpoint is returned instead
        if (useAuthentication)
        {
            await TokenSemaphore.WaitAsync(cancellationToken);

            try
            {
                var tokenResponse = await TryGetValidTokenPair(cancellationToken);

                if (tokenResponse.IsSuccess)
                    JsonWebTokenPair = tokenResponse.Result;
                else
                    return new NordigenApiResponse<TResponse, TError>(tokenResponse.StatusCode, tokenResponse.IsSuccess,
                        null, new TError {Summary = tokenResponse.Error.Summary, Detail = tokenResponse.Error.Detail},
                        tokenResponse.RateLimits);
            }
            finally
            {
                TokenSemaphore.Release();
            }

            client = _httpClient.UseNordigenAuthenticationHeader(JsonWebTokenPair);
        }
        else
        {
            client = _httpClient;
        }

        var response = await ExecuteRequest(client, method, requestUri, cancellationToken, body);

        return await NordigenApiResponse<TResponse, TError>.FromHttpResponse(response, _serializerOptions,
            cancellationToken);
    }

    private static async Task<HttpResponseMessage> ExecuteRequest(HttpClient client, HttpMethod method,
        string requestUri, CancellationToken cancellationToken, HttpContent? body = null)
    {
        if (method == HttpMethod.Get)
            return await client.GetAsync(requestUri, cancellationToken);
        if (method == HttpMethod.Post)
            return await client.PostAsync(requestUri, body, cancellationToken);
        if (method == HttpMethod.Delete)
            return await client.DeleteAsync(requestUri, cancellationToken);
        if (method == HttpMethod.Put)
            return await client.PutAsync(requestUri, body, cancellationToken);

        throw new ArgumentException($"HttpMethod {method} is not supported", nameof(method));
    }

    /// <summary>
    /// Tries to retrieve a valid <see cref="Models.Jwt.JsonWebTokenPair" />.
    /// </summary>
    /// <param name="cancellationToken">An optional token to signal cancellation of the operation.</param>
    /// <returns>
    /// A <see cref="NordigenApiResponse{TResult,TError}" /> containing the <see cref="JsonWebTokenPair" /> or
    /// the error of the operation.
    /// </returns>
    private async Task<NordigenApiResponse<JsonWebTokenPair, BasicResponse>> TryGetValidTokenPair(
        CancellationToken cancellationToken = default)
    {
        // Request a new token if it is null or if the refresh token has expired
        if (JsonWebTokenPair == null || JsonWebTokenPair.RefreshToken.IsExpired(TimeSpan.FromMinutes(1)))
            return await TokenEndpoint.GetTokenPair(cancellationToken);

        // Refresh the current access token if it's expired (or valid for less than a minute)
        if (JsonWebTokenPair.AccessToken.IsExpired(TimeSpan.FromMinutes(1)))
        {
            var response = await TokenEndpoint.RefreshAccessToken(JsonWebTokenPair.RefreshToken, cancellationToken);
            // Create a new token pair consisting of the new access token and existing refresh token
            var token = response.IsSuccess
                ? new JsonWebTokenPair(response.Result.AccessToken, JsonWebTokenPair.RefreshToken,
                    response.Result!.AccessExpires, JsonWebTokenPair.RefreshExpires)
                : null;

            return new NordigenApiResponse<JsonWebTokenPair, BasicResponse>(response.StatusCode, response.IsSuccess,
                token, response.Error, response.RateLimits);
        }

        // Token pair is still valid and can be returned - wrap in NordigenApiResponse
        return new NordigenApiResponse<JsonWebTokenPair, BasicResponse>(HttpStatusCode.OK, true, JsonWebTokenPair,
            null, new ApiRateLimits(-1, -1, -1, -1, -1, -1));
    }
}
using System.Text.Json;
using RobinTTY.NordigenApiClient.Endpoints;
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

    /// <inheritdoc />
    public JsonWebTokenPair? JsonWebTokenPair { get; set; }

    /// <inheritdoc />
    public TokenEndpoint TokenEndpoint { get; }

    /// <inheritdoc />
    public InstitutionsEndpoint InstitutionsEndpoint { get; }

    /// <inheritdoc />
    public AgreementsEndpoint AgreementsEndpoint { get; }

    /// <inheritdoc />
    public RequisitionsEndpoint RequisitionsEndpoint { get; }

    /// <inheritdoc />
    public AccountsEndpoint AccountsEndpoint { get; }
    
    /// <inheritdoc />
    public event EventHandler<TokenPairUpdatedEventArgs>? TokenPairUpdated;

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
                new CultureSpecificDecimalConverter(), new InstitutionsErrorConverter()
            }
        };

        Credentials = credentials;
        JsonWebTokenPair = jsonWebTokenPair;
        TokenEndpoint = new TokenEndpoint(this);
        InstitutionsEndpoint = new InstitutionsEndpoint(this);
        AgreementsEndpoint = new AgreementsEndpoint(this);
        RequisitionsEndpoint = new RequisitionsEndpoint(this);
        AccountsEndpoint = new AccountsEndpoint(this);
    }

    internal async Task<NordigenApiResponse<TResponse, TError>> MakeRequest<TResponse, TError>(
        string uri,
        HttpMethod method,
        CancellationToken cancellationToken,
        IEnumerable<KeyValuePair<string, string>>? query = null,
        HttpContent? body = null,
        bool useAuthentication = true
    ) where TResponse : class where TError : class
    {
        var requestUri = query != null ? UriQueryBuilder.BuildUriWithQueryString(uri, query) : uri;
        HttpClient client;
        if (useAuthentication)
        {
            await TokenSemaphore.WaitAsync(cancellationToken);
            try
            {
                JsonWebTokenPair = await TryGetValidTokenPair(cancellationToken);
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

        HttpResponseMessage? response;
        if (method == HttpMethod.Get)
            response = await client.GetAsync(requestUri, cancellationToken);
        else if (method == HttpMethod.Post)
            response = await client.PostAsync(requestUri, body, cancellationToken);
        else if (method == HttpMethod.Delete)
            response = await client.DeleteAsync(requestUri, cancellationToken);
        else if (method == HttpMethod.Put)
            response = await client.PutAsync(requestUri, body, cancellationToken);
        else
            throw new NotImplementedException();

        return await NordigenApiResponse<TResponse, TError>.FromHttpResponse(response, _serializerOptions,
            cancellationToken);
    }

    /// <summary>
    /// Tries to retrieve a valid <see cref="Models.Jwt.JsonWebTokenPair" />.
    /// </summary>
    /// <param name="cancellationToken">An optional token to signal cancellation of the operation.</param>
    /// <returns>
    /// A valid <see cref="Models.Jwt.JsonWebTokenPair" /> if the operation was successful.
    /// Otherwise returns null.
    /// </returns>
    private async Task<JsonWebTokenPair?> TryGetValidTokenPair(CancellationToken cancellationToken = default)
    {
        // Request a new token if it is null or if the refresh token has expired
        if (JsonWebTokenPair == null || JsonWebTokenPair.RefreshToken.IsExpired(TimeSpan.FromMinutes(1)))
        {
            var response = await TokenEndpoint.GetTokenPair(cancellationToken);
            TokenPairUpdated?.Invoke(this, new TokenPairUpdatedEventArgs(response.Result));
            return response.Result;
        }

        // Refresh the current access token if it's expired (or valid for less than a minute)
        if (JsonWebTokenPair.AccessToken.IsExpired(TimeSpan.FromMinutes(1)))
        {
            var response = await TokenEndpoint.RefreshAccessToken(JsonWebTokenPair.RefreshToken, cancellationToken);
            // Create a new token pair consisting of the new access token and existing refresh token
            var token = response.IsSuccess
                ? new JsonWebTokenPair(response.Result!.AccessToken, JsonWebTokenPair.RefreshToken,
                    response.Result!.AccessExpires, JsonWebTokenPair.RefreshExpires)
                : null;
            TokenPairUpdated?.Invoke(this, new TokenPairUpdatedEventArgs(token));
            return token;
        }

        // Token pair is still valid and can be returned
        return JsonWebTokenPair;
    }
}

/// <summary>
/// Provides data for the <see cref="NordigenClient.TokenPairUpdated" /> event.
/// </summary>
public class TokenPairUpdatedEventArgs : EventArgs
{
    /// <summary>
    /// The updated <see cref="Models.Jwt.JsonWebTokenPair" />.
    /// </summary>
    public JsonWebTokenPair? JsonWebTokenPair { get; set; }

    /// <summary>
    /// Creates a new instance of <see cref="TokenPairUpdatedEventArgs" />.
    /// </summary>
    /// <param name="jsonWebTokenPair">The updated <see cref="Models.Jwt.JsonWebTokenPair" />.</param>
    public TokenPairUpdatedEventArgs(JsonWebTokenPair? jsonWebTokenPair)
    {
        JsonWebTokenPair = jsonWebTokenPair;
    }
}

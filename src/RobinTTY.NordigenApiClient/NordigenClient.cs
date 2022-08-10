using System.Text.Json;
using RobinTTY.NordigenApiClient.Endpoints;
using RobinTTY.NordigenApiClient.JsonConverters;
using RobinTTY.NordigenApiClient.Models;
using RobinTTY.NordigenApiClient.Models.Jwt;
using RobinTTY.NordigenApiClient.Models.Responses;
using RobinTTY.NordigenApiClient.Utility;

namespace RobinTTY.NordigenApiClient;

/// <summary>
/// Client used to access the Nordigen API endpoints.
/// </summary>
public class NordigenClient
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _serializerOptions;
    internal readonly NordigenClientCredentials Credentials;

    /// <summary>
    /// A pair consisting of access/refresh token used to authenticate with the Nordigen API.
    /// </summary>
    public JsonWebTokenPair? JwtTokenPair { get; set; }
    /// <summary>
    /// Provides support for the API operations of the tokens endpoint.
    /// <para>Reference: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/token"/></para>
    /// </summary>
    public TokenEndpoint TokenEndpoint { get; }
    /// <summary>
    /// Provides support for the API operations of the institutions endpoint.
    /// <para>Reference: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/institutions"/></para>
    /// </summary>
    public InstitutionsEndpoint InstitutionsEndpoint { get; }
    /// <summary>
    /// Provides support for the API operations of the agreements endpoint.
    /// <para>Reference: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/agreements"/></para>
    /// </summary>
    public AgreementsEndpoint AgreementsEndpoint { get; }
    /// <summary>
    /// Provides support for the API operations of the requisitions endpoint.
    /// <para>Reference: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/requisitions"/></para>
    /// </summary>
    public RequisitionsEndpoint RequisitionsEndpoint { get; }
    /// <summary>
    /// Provides support for the API operations of the accounts endpoint.
    /// <para>Reference: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/accounts"/></para>
    /// </summary>
    public AccountsEndpoint AccountsEndpoint { get; }

    /// <summary>
    /// Creates a new instance of <see cref="NordigenClient"/>.
    /// </summary>
    /// <param name="httpClient">The <see cref="HttpClient"/> to use.</param>
    /// <param name="credentials">The Nordigen credentials for API access.</param>
    /// <param name="jwtTokenPair">An optional JSON web token pair consisting of access and refresh token to use.</param>
    public NordigenClient(HttpClient httpClient, NordigenClientCredentials credentials, JsonWebTokenPair? jwtTokenPair = null)
    {
        _httpClient = httpClient;
        _serializerOptions = new JsonSerializerOptions
        {
            Converters = { new JsonWebTokenConverter(), new GuidConverter() }
        };

        Credentials = credentials;
        JwtTokenPair = jwtTokenPair;
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
        var authToken = useAuthentication ? await TryGetValidTokenPair(cancellationToken) : null;
        var client = useAuthentication ? _httpClient.UseNordigenAuthenticationHeader(authToken) : _httpClient;

        HttpResponseMessage ? response;
        if (method == HttpMethod.Get)
            response = await client.GetAsync(requestUri, cancellationToken);
        else if (method == HttpMethod.Post)
            response = await client.PostAsync(requestUri, body, cancellationToken);
        else if (method == HttpMethod.Delete)
            response = await client.DeleteAsync(requestUri, cancellationToken);
        else if(method == HttpMethod.Put)
            response = await client.PutAsync(requestUri, body, cancellationToken);
        else
            throw new NotImplementedException();

        return await NordigenApiResponse<TResponse, TError>.FromHttpResponse(response, cancellationToken, _serializerOptions);
    }

    /// <summary>
    /// Tries to retrieve a valid <see cref="JsonWebTokenPair"/>.
    /// </summary>
    /// <param name="cancellationToken">An optional token to signal cancellation of the operation.</param>
    /// <returns>A valid <see cref="JsonWebTokenPair"/> if the operation was successful.
    /// Otherwise returns null.</returns>
    private async Task<JsonWebTokenPair?> TryGetValidTokenPair(CancellationToken cancellationToken = default)
    {
        // Request a new token if it is null or if the refresh token has expired
        if (JwtTokenPair == null || JwtTokenPair.RefreshToken.IsExpired(TimeSpan.FromMinutes(1)))
        {
            var response = await TokenEndpoint.GetTokenPair(cancellationToken);
            return response.IsSuccess ? response.Result : null;
        }

        // Refresh the current access token if it's expired (or valid for less than a minute)
        if (JwtTokenPair.AccessToken.IsExpired(TimeSpan.FromMinutes(1)))
        {
            var response = await TokenEndpoint.RefreshAccessToken(JwtTokenPair.RefreshToken, cancellationToken);
            if (!response.IsSuccess) return null;

            // Update the token pair with the response
            JwtTokenPair.AccessToken = response.Result!.AccessToken;
            JwtTokenPair.AccessExpires = response.Result!.AccessExpires;
            return JwtTokenPair;
        }

        // Token pair is still valid and can be returned
        return JwtTokenPair;
    }
}

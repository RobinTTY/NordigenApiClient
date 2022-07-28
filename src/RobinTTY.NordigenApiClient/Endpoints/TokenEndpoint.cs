using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.IdentityModel.JsonWebTokens;
using RobinTTY.NordigenApiClient.JsonConverters;
using RobinTTY.NordigenApiClient.Models;
using RobinTTY.NordigenApiClient.Models.Jwt;

namespace RobinTTY.NordigenApiClient.Endpoints;

public class TokenEndpoint : ITokenEndpoint
{
    private readonly HttpClient _httpClient;
    private readonly NordigenClientCredentials _credentials;
    private readonly JsonSerializerOptions _serializerOptions;

    public TokenEndpoint(NordigenClient client)
    {
        _httpClient = client.HttpClient;
        _credentials = client.Credentials;
        _serializerOptions = new JsonSerializerOptions
        {
            Converters = { new JsonWebTokenConverter() }
        };
    }

    /// <summary>
    /// Obtains a new JWT token pair from the Nordigen API.
    /// Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/token/JWT%20Obtain"></see>
    /// </summary>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>The obtained <see cref="JsonWebTokenPair"/>.</returns>
    public async Task<NordigenApiResponse<JsonWebTokenPair>> GetToken(CancellationToken cancellationToken = default)
    {
        var requestBody = JsonContent.Create(_credentials);
        var response = await _httpClient.PostAsync($"{NordigenEndpointUrls.TokensEndpoint}/new/", requestBody, cancellationToken);
        return await NordigenApiResponse<JsonWebTokenPair>.FromHttpResponse(response, cancellationToken, _serializerOptions);
    }


    /// <summary>
    /// Refreshes the JWT access token.
    /// Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/token/JWT%20Refresh"></see>
    /// </summary>
    /// <param name="refreshToken">The refresh token previously obtained through the <see cref="GetToken"/> method.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>The refreshed <see cref="JsonWebToken"/>.</returns>
    public async Task<NordigenApiResponse<JsonWebAccessToken>> RefreshToken(JsonWebToken refreshToken, CancellationToken cancellationToken = default)
    {
        var requestBody = JsonContent.Create(new { refresh = refreshToken.EncodedToken });
        var response = await _httpClient.PostAsync($"{NordigenEndpointUrls.TokensEndpoint}/refresh/", requestBody, cancellationToken);
        return await NordigenApiResponse<JsonWebAccessToken>.FromHttpResponse(response, cancellationToken, _serializerOptions);
    }
}
using System.Net.Http.Json;
using Microsoft.IdentityModel.JsonWebTokens;
using RobinTTY.NordigenApiClient.Models;
using RobinTTY.NordigenApiClient.Models.Jwt;

namespace RobinTTY.NordigenApiClient.Endpoints;

public class TokenEndpoint : ITokenEndpoint
{
    private readonly NordigenClient _nordigenClient;

    public TokenEndpoint(NordigenClient client)
    {
        _nordigenClient = client;
    }

    /// <summary>
    /// Obtains a new JWT token pair from the Nordigen API.
    /// Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/token/JWT%20Obtain"></see>
    /// </summary>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{T}"/> containing the obtained <see cref="JsonWebTokenPair"/> if the request was successful.</returns>
    public async Task<NordigenApiResponse<JsonWebTokenPair>> GetToken(CancellationToken cancellationToken = default)
    {
        var requestBody = JsonContent.Create(_nordigenClient.Credentials);
        return await _nordigenClient.MakeRequest<JsonWebTokenPair>($"{NordigenEndpointUrls.TokensEndpoint}new/", HttpMethod.Post, cancellationToken, body: requestBody, useAuthentication: false);
    }

    /// <summary>
    /// Refreshes the JWT access token.
    /// Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/token/JWT%20Refresh"></see>
    /// </summary>
    /// <param name="refreshToken">The refresh token previously obtained through the <see cref="GetToken"/> method.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{T}"/> containing the refreshed <see cref="JsonWebAccessToken"/> if the request was successful.</returns>
    public async Task<NordigenApiResponse<JsonWebAccessToken>> RefreshToken(JsonWebToken refreshToken, CancellationToken cancellationToken = default)
    {
        var requestBody = JsonContent.Create(new { refresh = refreshToken.EncodedToken });
        return await _nordigenClient.MakeRequest<JsonWebAccessToken>($"{NordigenEndpointUrls.TokensEndpoint}refresh/", HttpMethod.Post, cancellationToken, body: requestBody, useAuthentication: false);
    }
}

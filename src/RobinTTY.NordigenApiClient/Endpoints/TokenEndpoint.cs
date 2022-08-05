using System.Net.Http.Json;
using Microsoft.IdentityModel.JsonWebTokens;
using RobinTTY.NordigenApiClient.Models.Errors;
using RobinTTY.NordigenApiClient.Models.Jwt;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Endpoints;

public class TokenEndpoint
{
    private readonly NordigenClient _nordigenClient;

    /// <summary>
    /// Creates a new instance of <see cref="TokenEndpoint"/>.
    /// </summary>
    /// <param name="client">The <see cref="NordigenClient"/> to use for token handling and request processing.</param>
    internal TokenEndpoint(NordigenClient client)
    {
        _nordigenClient = client;
    }

    /// <summary>
    /// Obtains a new JWT token pair from the Nordigen API.
    /// <para>Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/token/JWT%20Obtain"></see></para>
    /// </summary>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}"/> containing the obtained <see cref="JsonWebTokenPair"/> if the request was successful.</returns>
    public async Task<NordigenApiResponse<JsonWebTokenPair, BasicError>> GetToken(CancellationToken cancellationToken = default)
    {
        var requestBody = JsonContent.Create(_nordigenClient.Credentials);
        return await _nordigenClient.MakeRequest<JsonWebTokenPair, BasicError>($"{NordigenEndpointUrls.TokensEndpoint}new/", HttpMethod.Post, cancellationToken, body: requestBody, useAuthentication: false);
    }

    /// <summary>
    /// Refreshes the JWT access token.
    /// <para>Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/token/JWT%20Refresh"></see></para>
    /// </summary>
    /// <param name="refreshToken">The refresh token previously obtained through the <see cref="GetToken"/> method.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}"/> containing the refreshed <see cref="JsonWebAccessToken"/> if the request was successful.</returns>
    public async Task<NordigenApiResponse<JsonWebAccessToken, BasicError>> RefreshToken(JsonWebToken refreshToken, CancellationToken cancellationToken = default)
    {
        var requestBody = JsonContent.Create(new { refresh = refreshToken.EncodedToken });
        return await _nordigenClient.MakeRequest<JsonWebAccessToken, BasicError>($"{NordigenEndpointUrls.TokensEndpoint}refresh/", HttpMethod.Post, cancellationToken, body: requestBody, useAuthentication: false);
    }
}

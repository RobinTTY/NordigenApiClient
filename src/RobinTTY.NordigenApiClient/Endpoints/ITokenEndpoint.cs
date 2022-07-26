using Microsoft.IdentityModel.JsonWebTokens;
using RobinTTY.NordigenApiClient.Models;
using RobinTTY.NordigenApiClient.Models.Jwt;

namespace RobinTTY.NordigenApiClient.Endpoints;

public interface ITokenEndpoint
{
    /// <summary>
    /// Obtains a new JWT token pair from the Nordigen API.
    /// Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/token/JWT%20Obtain"></see>
    /// </summary>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>The obtained <see cref="JsonWebTokenPair"/>.</returns>
    Task<NordigenApiResponse<JsonWebTokenPair>> GetToken(CancellationToken cancellationToken = default);

    /// <summary>
    /// Refreshes the JWT access token.
    /// Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/token/JWT%20Refresh"></see>
    /// </summary>
    /// <param name="refreshToken">The refresh token previously obtained through the <see cref="TokenEndpoint.GetToken"/> method.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>The refreshed <see cref="JsonWebAccessToken"/>.</returns>
    Task<NordigenApiResponse<JsonWebAccessToken>> RefreshToken(JsonWebToken refreshToken, CancellationToken cancellationToken = default);
}
using Microsoft.IdentityModel.JsonWebTokens;
using RobinTTY.NordigenApiClient.Endpoints;
using RobinTTY.NordigenApiClient.Models.Errors;
using RobinTTY.NordigenApiClient.Models.Jwt;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Contracts;

/// <summary>
/// Provides support for the API operations of the tokens endpoint.
/// <para>
/// Reference: <a href="https://developer.gocardless.com/bank-account-data/endpoints">GoCardless Documentation</a>
/// </para>
/// </summary>
public interface ITokenEndpoint
{
    /// <summary>
    /// Obtains a new JWT token pair from the Nordigen API.
    /// </summary>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>
    /// A <see cref="NordigenApiResponse{TResponse, TError}" /> containing the obtained
    /// <see cref="JsonWebTokenPair" /> if the request was successful.
    /// </returns>
    Task<NordigenApiResponse<JsonWebTokenPair, BasicError>> GetTokenPair(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Refreshes the JWT access token.
    /// </summary>
    /// <param name="refreshToken">The refresh token previously obtained through the <see cref="TokenEndpoint.GetTokenPair" /> method.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>
    /// A <see cref="NordigenApiResponse{TResponse, TError}" /> containing the refreshed
    /// <see cref="JsonWebAccessToken" /> if the request was successful.
    /// </returns>
    Task<NordigenApiResponse<JsonWebAccessToken, BasicError>> RefreshAccessToken(JsonWebToken refreshToken,
        CancellationToken cancellationToken = default);
}
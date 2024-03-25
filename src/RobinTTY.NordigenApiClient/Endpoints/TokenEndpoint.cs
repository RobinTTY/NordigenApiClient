using System.Net.Http.Json;
using Microsoft.IdentityModel.JsonWebTokens;
using RobinTTY.NordigenApiClient.Contracts;
using RobinTTY.NordigenApiClient.Models.Errors;
using RobinTTY.NordigenApiClient.Models.Jwt;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Endpoints;

/// <inheritdoc />
public class TokenEndpoint : ITokenEndpoint
{
    private readonly NordigenClient _nordigenClient;

    /// <summary>
    /// Creates a new instance of <see cref="TokenEndpoint" />.
    /// </summary>
    /// <param name="client">The <see cref="NordigenClient" /> to use for token handling and request processing.</param>
    internal TokenEndpoint(NordigenClient client) => _nordigenClient = client;

    /// <inheritdoc />
    public async Task<NordigenApiResponse<JsonWebTokenPair, BasicError>> GetTokenPair(
        CancellationToken cancellationToken = default)
    {
        var requestBody = JsonContent.Create(_nordigenClient.Credentials);
        return await _nordigenClient.MakeRequest<JsonWebTokenPair, BasicError>(
            $"{NordigenEndpointUrls.TokensEndpoint(_nordigenClient.BaseUrl)}new/", HttpMethod.Post, cancellationToken, body: requestBody,
            useAuthentication: false);
    }

    /// <inheritdoc />
    public async Task<NordigenApiResponse<JsonWebAccessToken, BasicError>> RefreshAccessToken(JsonWebToken refreshToken,
        CancellationToken cancellationToken = default)
    {
        var requestBody = JsonContent.Create(new {refresh = refreshToken.EncodedToken});
        return await _nordigenClient.MakeRequest<JsonWebAccessToken, BasicError>(
            $"{NordigenEndpointUrls.TokensEndpoint(_nordigenClient.BaseUrl)}refresh/", HttpMethod.Post, cancellationToken, body: requestBody,
            useAuthentication: false);
    }
}

using System.IdentityModel.Tokens.Jwt;
using RobinTTY.NordigenApiClient.Models;
using RobinTTY.NordigenApiClient.Models.Jwt;

namespace RobinTTY.NordigenApiClient.Endpoints;

public interface ITokenEndpoint
{
    Task<NordigenApiResponse<JwtTokenPair>> GetToken(CancellationToken cancellationToken = default);

    Task<NordigenApiResponse<JwtAccessToken>> RefreshToken(JwtSecurityToken refreshToken, CancellationToken cancellationToken = default);
}
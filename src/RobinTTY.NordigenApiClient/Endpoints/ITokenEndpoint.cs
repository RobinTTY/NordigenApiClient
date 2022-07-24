using RobinTTY.NordigenApiClient.Models;

namespace RobinTTY.NordigenApiClient.Endpoints;

public interface ITokenEndpoint
{
    Task<NordigenApiResponse<JwtTokenPair>> GetToken(CancellationToken cancellationToken);
}
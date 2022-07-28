using RobinTTY.NordigenApiClient.Models;

namespace RobinTTY.NordigenApiClient.Endpoints;

public interface IInstitutionsEndpoint
{
    Task<NordigenApiResponse<List<Institution>>> GetInstitutions(string country, CancellationToken cancellationToken = default);
}
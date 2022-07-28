using RobinTTY.NordigenApiClient.Models;
using RobinTTY.NordigenApiClient.Utility;

namespace RobinTTY.NordigenApiClient.Endpoints;
public class InstitutionsEndpoint : IInstitutionsEndpoint
{
    private readonly NordigenClient _nordigenClient;
    private readonly HttpClient _httpClient;

    public InstitutionsEndpoint(NordigenClient client)
    {
        _nordigenClient = client;
        _httpClient = client.HttpClient;
    }

    public async Task<NordigenApiResponse<List<Institution>>> GetInstitutions(string country, CancellationToken cancellationToken = default)
    {
        
        var query = new KeyValuePair<string, string>[] {new("country", country)};
        var requestUri = UriQueryBuilder.BuildUriWithQueryString(NordigenEndpointUrls.InstitutionsEndpoint, query);
        var authToken = await _nordigenClient.TryGetValidTokenPair(cancellationToken);
        var response = await _httpClient.UseNordigenAuthenticationHeader(authToken).GetAsync(requestUri, cancellationToken);
        return await NordigenApiResponse<List<Institution>>.FromHttpResponse(response, cancellationToken);
    }
}

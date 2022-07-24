using System.Net.Http.Json;
using RobinTTY.NordigenApiClient.Models;

namespace RobinTTY.NordigenApiClient.Endpoints;

public class TokenEndpoint : ITokenEndpoint
{
    private readonly HttpClient _httpClient;
    private readonly NordigenClientCredentials _credentials;

    public TokenEndpoint(HttpClient client, NordigenClientCredentials credentials)
    {
        _httpClient = client;
        _credentials = credentials;
    }

    public async Task<NordigenApiResponse<JwtTokenPair>> GetToken(CancellationToken cancellationToken = default)
    {
        var requestBody = JsonContent.Create(_credentials);
        var response = await _httpClient.PostAsync($"{NordigenEndpointUrls.TokensEndpoint}new/", requestBody, cancellationToken);
        return await NordigenApiResponse<JwtTokenPair>.FromHttpResponse(response, cancellationToken);
    }
}
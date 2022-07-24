using RobinTTY.NordigenApiClient.Endpoints;
using RobinTTY.NordigenApiClient.Models;

namespace RobinTTY.NordigenApiClient;

public class NordigenClient
{
    private HttpClient _httpClient;
    private NordigenClientCredentials _credentials;

    public ITokenEndpoint TokenEndpoint { get; }

    public NordigenClient(HttpClient httpClient, NordigenClientCredentials credentials)
    {
        _httpClient = httpClient;
        _credentials = credentials;

        TokenEndpoint = new TokenEndpoint(_httpClient, _credentials);
    }
}
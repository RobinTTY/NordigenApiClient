using RobinTTY.NordigenApiClient.Models;

namespace RobinTTY.NordigenApiClient.Tests;

public class TokenEndpointTests
{
    private NordigenClient _apiClient;

    [SetUp]
    public void Setup()
    {
        var httpClient = new HttpClient();
        var secrets = File.ReadAllLines("secrets.txt");
        var apiOptions = new NordigenClientCredentials(secrets[0], secrets[1]);
        _apiClient = new NordigenClient(httpClient, apiOptions);
    }

    [Test]
    public async Task Test1()
    {
        var response = await _apiClient.TokenEndpoint.GetToken(new CancellationToken());

        Assert.Pass();
    }
}
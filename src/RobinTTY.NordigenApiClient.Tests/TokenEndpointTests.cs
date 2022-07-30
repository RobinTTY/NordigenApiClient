using RobinTTY.NordigenApiClient.Models;

namespace RobinTTY.NordigenApiClient.Tests;

public class TokenEndpointTests
{
    private NordigenClient _apiClient = null!;

    [OneTimeSetUp]
    public void Setup()
    {
        var httpClient = new HttpClient();
        var secrets = File.ReadAllLines("secrets.txt");
        var apiOptions = new NordigenClientCredentials(secrets[0], secrets[1]);
        _apiClient = new NordigenClient(httpClient, apiOptions);
    }

    /// <summary>
    /// Tests the retrieving and refreshing of the JWT access tokens.
    /// Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/token"></see>
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task GetJwtTokenPairAndRefresh()
    {
        var response = await _apiClient.TokenEndpoint.GetToken();
        TestExtensions.AssertNordigenApiResponseIsSuccessful(response);
        var response2 = await _apiClient.TokenEndpoint.RefreshToken(response.Result!.RefreshToken);
        TestExtensions.AssertNordigenApiResponseIsSuccessful(response2);
    }
}
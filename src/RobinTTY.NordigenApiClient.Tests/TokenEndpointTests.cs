using System.Net;
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

    /// <summary>
    /// Tests the retrieving and refreshing of the JWT access tokens.
    /// Endpoint: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/token"></see>
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task GetJwtTokenPairAndRefresh()
    {
        var response = await _apiClient.TokenEndpoint.GetToken();
        AssertNordigenApiResponseIsSuccessful(response);
        var response2 = await _apiClient.TokenEndpoint.RefreshToken(response.Result!.RefreshToken);
        AssertNordigenApiResponseIsSuccessful(response2);
    }

    private void AssertNordigenApiResponseIsSuccessful<T>(NordigenApiResponse<T> response) where T : class
    {
        Assert.That(response.IsSuccess, Is.True);
        Assert.That(response.Result, Is.Not.Null);
        Assert.That(response.Error, Is.Null);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
}
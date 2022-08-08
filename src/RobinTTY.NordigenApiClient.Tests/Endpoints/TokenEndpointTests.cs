using System.Net;
using RobinTTY.NordigenApiClient.Models;

namespace RobinTTY.NordigenApiClient.Tests.Endpoints;

internal class TokenEndpointTests
{
    private NordigenClient _apiClient = null!;

    [OneTimeSetUp]
    public void Setup()
    {
        _apiClient = TestExtensions.GetConfiguredClient(false);
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
        TestExtensions.AssertNordigenApiResponseIsSuccessful(response, HttpStatusCode.OK);
        var response2 = await _apiClient.TokenEndpoint.RefreshToken(response.Result!.RefreshToken);
        TestExtensions.AssertNordigenApiResponseIsSuccessful(response2, HttpStatusCode.OK);
    }

    /// <summary>
    /// Tests retrieving a token with invalid credentials.
    /// Route: https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/token/JWT%20Obtain
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task GetTokenWithInvalidCredentials()
    {
        var httpClient = new HttpClient();
        var credentials = new NordigenClientCredentials("invalid", "invalid");
        var apiClient = new NordigenClient(httpClient, credentials);
        var response = await apiClient.TokenEndpoint.GetToken();

        Assert.That(response.IsSuccess, Is.False);
        Assert.That(response.Result, Is.Null);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        Assert.That(response.Error, Is.Not.Null);
    }
}
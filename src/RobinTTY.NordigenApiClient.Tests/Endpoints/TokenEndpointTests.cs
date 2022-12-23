using System.Net;
using RobinTTY.NordigenApiClient.Models;
using RobinTTY.NordigenApiClient.Models.Jwt;

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
    public async Task GetJsonWebTokenPairAndRefresh()
    {
        var response = await _apiClient.TokenEndpoint.GetTokenPair();
        TestExtensions.AssertNordigenApiResponseIsSuccessful(response, HttpStatusCode.OK);
        var response2 = await _apiClient.TokenEndpoint.RefreshAccessToken(response.Result!.RefreshToken);
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
        var response = await apiClient.TokenEndpoint.GetTokenPair();

        Assert.That(response.IsSuccess, Is.False);
        Assert.That(response.Result, Is.Null);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        Assert.That(response.Error, Is.Not.Null);
    }

    /// <summary>
    /// Tests using the API with an expired access token.
    /// Requires secrets.txt to contain expired access token / valid refresh token pair.
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task ReuseExpiredToken()
    {
        var secrets = await File.ReadAllLinesAsync("secrets.txt");
        var httpClient = new HttpClient();
        var credentials = new NordigenClientCredentials(secrets[0], secrets[1]);
        var tokenPair = new JsonWebTokenPair(secrets[6], secrets[7]);
        var apiClient = new NordigenClient(httpClient, credentials, tokenPair);

        var result = await apiClient.RequisitionsEndpoint.GetRequisitions(10, 0);
        TestExtensions.AssertNordigenApiResponseIsSuccessful(result, HttpStatusCode.OK);
    }
}
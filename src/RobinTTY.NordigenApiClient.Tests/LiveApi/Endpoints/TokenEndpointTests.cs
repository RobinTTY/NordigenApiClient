using System.Net;
using RobinTTY.NordigenApiClient.Models;
using RobinTTY.NordigenApiClient.Models.Jwt;
using RobinTTY.NordigenApiClient.Tests.Shared;

namespace RobinTTY.NordigenApiClient.Tests.LiveApi.Endpoints;

public class TokenEndpointTests
{
    private NordigenClient _apiClient = null!;

    [OneTimeSetUp]
    public void Setup()
    {
        _apiClient = TestHelpers.GetConfiguredClient();
    }

    /// <summary>
    /// Tests the retrieving and refreshing of the JWT access tokens.
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task GetJsonWebTokenPairAndRefresh()
    {
        var response = await _apiClient.TokenEndpoint.GetTokenPair();
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(response, HttpStatusCode.OK);
        var response2 = await _apiClient.TokenEndpoint.RefreshAccessToken(response.Result!.RefreshToken);
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(response2, HttpStatusCode.OK);
    }

    /// <summary>
    /// Tests retrieving a token with invalid credentials.
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task GetTokenWithInvalidCredentials()
    {
        var httpClient = new HttpClient();
        var credentials = new NordigenClientCredentials("invalid", "invalid");
        var apiClient = new NordigenClient(httpClient, credentials);
        var response = await apiClient.TokenEndpoint.GetTokenPair();

        Assert.Multiple(() =>
        {
            Assert.That(response.IsSuccess, Is.False);
            Assert.That(response.Result, Is.Null);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            Assert.That(response.Error, Is.Not.Null);
        });
    }

    /// <summary>
    /// Tests using the API with an expired access token.
    /// Requires secrets.txt to contain expired access token / valid refresh token pair.
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task ReuseExpiredToken()
    {
        var httpClient = new HttpClient();
        var credentials = new NordigenClientCredentials(TestHelpers.Secrets[0], TestHelpers.Secrets[1]);
        var tokenPair = new JsonWebTokenPair(TestHelpers.Secrets[6], TestHelpers.Secrets[7]);
        var apiClient = new NordigenClient(httpClient, credentials, tokenPair);

        var result = await apiClient.RequisitionsEndpoint.GetRequisitions(10, 0);
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(result, HttpStatusCode.OK);
    }
}

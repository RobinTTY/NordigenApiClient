using System.Net;
using RobinTTY.NordigenApiClient.Models;
using RobinTTY.NordigenApiClient.Models.Jwt;
using RobinTTY.NordigenApiClient.Tests.Shared;

namespace RobinTTY.NordigenApiClient.Tests.LiveApi.Endpoints;

internal class TokenEndpointTests
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
#if NET6_0_OR_GREATER
        var secrets = await File.ReadAllLinesAsync("secrets.txt");
#else
        var secrets = File.ReadAllLines("secrets.txt");
#endif
        var httpClient = new HttpClient();
        var credentials = new NordigenClientCredentials(secrets[0], secrets[1]);
        var tokenPair = new JsonWebTokenPair(secrets[6], secrets[7]);
        var apiClient = new NordigenClient(httpClient, credentials, tokenPair);

        var result = await apiClient.RequisitionsEndpoint.GetRequisitions(10, 0);
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(result, HttpStatusCode.OK);
    }

    /// <summary>
    /// Tests the failure of authentication when trying to get a new token pair.
    /// </summary>
    [Test]
    public async Task GetTokenPairWithInvalidCredentials()
    {
        using var httpClient = new HttpClient();
        var invalidCredentials = new NordigenClientCredentials("01234567-89ab-cdef-0123-456789abcdef",
            "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef");
        var apiClient = new NordigenClient(httpClient, invalidCredentials);

        // Returns BasicError
        var agreementsResponse = await apiClient.AgreementsEndpoint.GetAgreements(10, 0);
        Assert.Multiple(() =>
        {
            Assert.That(agreementsResponse.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            AssertionHelpers.AssertNordigenApiResponseIsUnsuccessful(agreementsResponse, HttpStatusCode.Unauthorized);
            AssertionHelpers.AssertBasicResponseMatchesExpectations(agreementsResponse.Error, "Authentication failed",
                "No active account found with the given credentials");
        });
    }
}

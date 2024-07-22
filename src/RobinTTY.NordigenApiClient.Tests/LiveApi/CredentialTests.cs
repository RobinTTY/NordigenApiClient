using RobinTTY.NordigenApiClient.Models;
using RobinTTY.NordigenApiClient.Models.Jwt;
using RobinTTY.NordigenApiClient.Tests.Shared;

namespace RobinTTY.NordigenApiClient.Tests.LiveApi;

public class CredentialTests
{
    private NordigenClient _apiClient = null!;

    [OneTimeSetUp]
    public void Setup()
    {
        _apiClient = TestHelpers.GetConfiguredClient();
    }

    #region RequestsWithSuccessfulResponse

    /// <summary>
    /// Tests that <see cref="NordigenClient.JsonWebTokenPair" /> is populated after the first authenticated request is made.
    /// </summary>
    [Test]
    public async Task CheckValidTokensAfterRequest()
    {
        Assert.That(_apiClient.JsonWebTokenPair, Is.Null);

        await _apiClient.RequisitionsEndpoint.GetRequisitions(5, 0, CancellationToken.None);

        Assert.Multiple(() =>
        {
            Assert.That(_apiClient.JsonWebTokenPair, Is.Not.Null);
            Assert.That(_apiClient.JsonWebTokenPair!.AccessToken.EncodedToken, Has.Length.GreaterThan(0));
            Assert.That(_apiClient.JsonWebTokenPair!.RefreshToken.EncodedToken, Has.Length.GreaterThan(0));
        });
    }

    #endregion

    #region RequestsWithErrors

    /// <summary>
    /// Tests the failure of authentication due to invalid credentials when trying to execute a request.
    /// </summary>
    [Test]
    public async Task ExecuteRequestWithInvalidCredentials()
    {
        using var httpClient = new HttpClient();
        var invalidCredentials = new NordigenClientCredentials("01234567-89ab-cdef-0123-456789abcdef",
            "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef");
        var apiClient = new NordigenClient(httpClient, invalidCredentials);

        var agreementsResponse = await apiClient.TokenEndpoint.GetTokenPair();

        Assert.Multiple(() =>
        {
            AssertionHelpers.AssertNordigenApiResponseIsUnsuccessful(agreementsResponse, HttpStatusCode.Unauthorized);
            AssertionHelpers.AssertBasicResponseMatchesExpectations(agreementsResponse.Error, "Authentication failed",
                "No active account found with the given credentials");
        });
    }

    /// <summary>
    /// Tests the failure of authentication due to an invalid token when trying to execute a request.
    /// </summary>
    [Test]
    public async Task ExecuteRequestWithUnauthorizedToken()
    {
        using var httpClient = new HttpClient();
        var invalidCredentials = new NordigenClientCredentials("01234567-89ab-cdef-0123-456789abcdef",
            "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef");
        var token = new JsonWebTokenPair(TestHelpers.Secrets.UnauthorizedJwtToken,
            TestHelpers.Secrets.UnauthorizedJwtToken);
        var apiClient = new NordigenClient(httpClient, invalidCredentials, token);

        var response = await apiClient.InstitutionsEndpoint.GetInstitutions();

        Assert.Multiple(() =>
        {
            AssertionHelpers.AssertNordigenApiResponseIsUnsuccessful(response, HttpStatusCode.Unauthorized);
            AssertionHelpers.AssertBasicResponseMatchesExpectations(response.Error, "Invalid token",
                "Token is invalid or expired");
        });
    }

    /// <summary>
    /// Tries to execute a request using credentials that haven't whitelisted the used IP. This should cause an error.
    /// </summary>
    [Test]
    public async Task ExecuteRequestWithUnauthorizedIp()
    {
        using var httpClient = new HttpClient();
        var credentials = new NordigenClientCredentials(TestHelpers.Secrets.ValidSecretIdWithWhitelist,
            TestHelpers.Secrets.ValidSecretKeyWithWhitelist);
        var apiClient = new NordigenClient(httpClient, credentials);

        var externalIp = await httpClient.GetStringAsync("https://ipinfo.io/ip");
        var response = await apiClient.RequisitionsEndpoint.GetRequisitions(5, 0, CancellationToken.None);

        Assert.Multiple(() =>
        {
            AssertionHelpers.AssertNordigenApiResponseIsUnsuccessful(response, HttpStatusCode.Forbidden);
            AssertionHelpers.AssertBasicResponseMatchesExpectations(response.Error, "IP address access denied",
                $"Your IP {externalIp} isn't whitelisted to perform this action");
        });
    }

    #endregion
}

using RobinTTY.NordigenApiClient.Models;
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
    
    /// <summary>
    /// Tests the failure of authentication when trying to execute a request using the live API.
    /// </summary>
    [Test]
    public async Task ExecuteRequestWithInvalidCredentials()
    {
        using var httpClient = new HttpClient();
        var invalidCredentials = new NordigenClientCredentials("01234567-89ab-cdef-0123-456789abcdef",
            "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef");
        var apiClient = new NordigenClient(httpClient, invalidCredentials);

        // Returns BasicError
        var agreementsResponse = await apiClient.TokenEndpoint.GetTokenPair();
        Assert.Multiple(() =>
        {
            AssertionHelpers.AssertNordigenApiResponseIsUnsuccessful(agreementsResponse, HttpStatusCode.Unauthorized);
            AssertionHelpers.AssertBasicResponseMatchesExpectations(agreementsResponse.Error, "Authentication failed",
                "No active account found with the given credentials");
        });
    }
    
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
}

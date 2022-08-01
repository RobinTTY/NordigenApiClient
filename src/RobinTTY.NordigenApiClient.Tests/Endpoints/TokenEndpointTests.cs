namespace RobinTTY.NordigenApiClient.Tests.Endpoints;

public class TokenEndpointTests
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
        TestExtensions.AssertNordigenApiResponseIsSuccessful(response);
        var response2 = await _apiClient.TokenEndpoint.RefreshToken(response.Result!.RefreshToken);
        TestExtensions.AssertNordigenApiResponseIsSuccessful(response2);
    }
}
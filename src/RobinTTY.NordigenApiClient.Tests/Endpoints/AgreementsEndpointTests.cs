using RobinTTY.NordigenApiClient.Models;

namespace RobinTTY.NordigenApiClient.Tests.Endpoints;

public class AgreementsEndpointTests
{
    private NordigenClient _apiClient = null!;

    [OneTimeSetUp]
    public void Setup()
    {
        _apiClient = TestExtensions.GetConfiguredClient();
    }

    /// <summary>
    /// Tests the retrieving of all agreements.
    /// Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/agreements/retrieve%20all%20EUAs%20for%20an%20end%20user%20v2"></see>
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task GetAgreements()
    {
        var response = await _apiClient.AgreementsEndpoint.GetAgreements(100, 0);
        TestExtensions.AssertNordigenApiResponseIsSuccessful(response);
    }

    [Test]
    public async Task CreateAgreement()
    {
        var agreement = new AgreementRequest(180, 30, new List<string> { "balances", "details", "transactions" }, "SANDBOXFINANCE_SFIN0000");
        var response = await _apiClient.AgreementsEndpoint.CreateAgreement(agreement);
    }
}

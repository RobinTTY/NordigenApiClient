using System.Net;

namespace RobinTTY.NordigenApiClient.Tests.Endpoints;

internal class InstitutionsEndpointTests
{
    private NordigenClient _apiClient = null!;

    [OneTimeSetUp]
    public void Setup()
    {
        _apiClient = TestExtensions.GetConfiguredClient();
    }

    /// <summary>
    /// Tests the retrieving of institution for all countries and a specific country (Great Britain).
    /// Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/institutions/retrieve%20all%20supported%20Institutions%20in%20a%20given%20country"></see>
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task GetInstitutions()
    {
        var response = await _apiClient.InstitutionsEndpoint.GetInstitutions();
        TestExtensions.AssertNordigenApiResponseIsSuccessful(response, HttpStatusCode.OK);
        var response2 = await _apiClient.InstitutionsEndpoint.GetInstitutions("GB");
        TestExtensions.AssertNordigenApiResponseIsSuccessful(response2, HttpStatusCode.OK);

        var result = response.Result!.ToList();
        var result2 = response2.Result!.ToList();

        Assert.Multiple(() =>
        {
            Assert.That(result.Count, Is.GreaterThan(0));
            Assert.That(result2.Count, Is.GreaterThan(0));
            Assert.That(result.Count, Is.GreaterThan(result2.Count));
        });
    }

    /// <summary>
    /// Tests the retrieving of a specific institution.
    /// Route: https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/institutions/retrieve%20institution
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task GetInstitution()
    {
        var response = await _apiClient.InstitutionsEndpoint.GetInstitution("SANDBOXFINANCE_SFIN0000");
        TestExtensions.AssertNordigenApiResponseIsSuccessful(response, HttpStatusCode.OK);

        var result = response.Result!;
        Assert.Multiple(() =>
        {
            Assert.That(result.Bic, Is.EqualTo("SFIN0000"));
            Assert.That(result.Id, Is.EqualTo("SANDBOXFINANCE_SFIN0000"));
            Assert.That(result.Name, Is.EqualTo("Sandbox Finance"));
        });
    }
}

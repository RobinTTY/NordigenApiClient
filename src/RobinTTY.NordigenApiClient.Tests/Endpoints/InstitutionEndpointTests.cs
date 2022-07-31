using RobinTTY.NordigenApiClient.Models;
using RobinTTY.NordigenApiClient.Models.Jwt;

namespace RobinTTY.NordigenApiClient.Tests.Endpoints;

internal class InstitutionEndpointTests
{
    private NordigenClient _apiClient = null!;

    [OneTimeSetUp]
    public void Setup()
    {
        var httpClient = new HttpClient();
        var secrets = File.ReadAllLines("secrets.txt");
        var credentials = new NordigenClientCredentials(secrets[0], secrets[1]);
        var tokenPair = new JsonWebTokenPair(secrets[2], secrets[3]);
        _apiClient = new NordigenClient(httpClient, credentials, tokenPair);
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
        TestExtensions.AssertNordigenApiResponseIsSuccessful(response);
        var response2 = await _apiClient.InstitutionsEndpoint.GetInstitutions("GB");
        TestExtensions.AssertNordigenApiResponseIsSuccessful(response2);

        var result = response.Result!.ToList();
        var result2 = response2.Result!.ToList();

        Assert.That(result.Count, Is.GreaterThan(0));
        Assert.That(result2.Count, Is.GreaterThan(0));
        Assert.That(result.Count, Is.GreaterThan(result2.Count));
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
        TestExtensions.AssertNordigenApiResponseIsSuccessful(response);

        var result = response.Result!;
        Assert.That(result.Bic, Is.EqualTo("SFIN0000"));
        Assert.That(result.Id, Is.EqualTo("SANDBOXFINANCE_SFIN0000"));
        Assert.That(result.Name, Is.EqualTo("Sandbox Finance"));
    }
}

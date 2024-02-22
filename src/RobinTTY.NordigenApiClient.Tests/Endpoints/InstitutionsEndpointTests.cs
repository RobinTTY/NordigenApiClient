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
    /// Tests the retrieving of institutions for all countries and a specific country (Great Britain).
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
            Assert.That(result, Has.Count.GreaterThan(0));
            Assert.That(result2, Has.Count.GreaterThan(0));
            Assert.That(result, Has.Count.GreaterThan(result2.Count));
        });
    }

    /// <summary>
    /// Tests the retrieving of institutions with various query parameters set.
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task GetInstitutionsWithFlags()
    {
        var allFlagsSetTrue = await _apiClient.InstitutionsEndpoint.GetInstitutions("GB", true, true, true, true, true,
            true, true, true, true, true, true);
        TestExtensions.AssertNordigenApiResponseIsSuccessful(allFlagsSetTrue, HttpStatusCode.OK);
        var allFlagsSetFalse = await _apiClient.InstitutionsEndpoint.GetInstitutions("GB", false, false, false, false,
            false, false, false, false, false, false, false);
        TestExtensions.AssertNordigenApiResponseIsSuccessful(allFlagsSetFalse, HttpStatusCode.OK);
        var institutionsWithAccountSelection =
            await _apiClient.InstitutionsEndpoint.GetInstitutions(accountSelectionSupported: true);
        TestExtensions.AssertNordigenApiResponseIsSuccessful(institutionsWithAccountSelection, HttpStatusCode.OK);
        var institutionsWithoutAccountSelection =
            await _apiClient.InstitutionsEndpoint.GetInstitutions(accountSelectionSupported: false);
        TestExtensions.AssertNordigenApiResponseIsSuccessful(institutionsWithoutAccountSelection, HttpStatusCode.OK);
        var allInstitutions = await _apiClient.InstitutionsEndpoint.GetInstitutions();
        TestExtensions.AssertNordigenApiResponseIsSuccessful(allInstitutions, HttpStatusCode.OK);

        var allFlagsTrueResult = allFlagsSetTrue.Result!.ToList();
        var withAccountSelectionResult = institutionsWithAccountSelection.Result!.ToList();
        var withoutAccountSelectionResult = institutionsWithoutAccountSelection.Result!.ToList();
        var allInstitutionResult = allInstitutions.Result!.ToList();

        Assert.Multiple(() =>
        {
            Assert.That(allFlagsTrueResult, Has.Count.EqualTo(0));
            Assert.That(withoutAccountSelectionResult, Has.Count.GreaterThan(0));
            Assert.That(withAccountSelectionResult, Has.Count.GreaterThan(withoutAccountSelectionResult.Count));
            Assert.That(allInstitutionResult, Has.Count.GreaterThan(withAccountSelectionResult.Count));
            Assert.That(withAccountSelectionResult.Count + withoutAccountSelectionResult.Count,
                Is.EqualTo(allInstitutionResult.Count));
        });
    }

    /// <summary>
    /// Tests the retrieving of institutions for a country which is not covered by the API.
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task GetInstitutionsForNotCoveredCountry()
    {
        var response = await _apiClient.InstitutionsEndpoint.GetInstitutions("US");
        TestExtensions.AssertNordigenApiResponseIsUnsuccessful(response, HttpStatusCode.BadRequest);

        Assert.Multiple(() =>
        {
            Assert.That(response.Error!.Detail, Is.EqualTo("US is not a valid choice."));
            Assert.That(response.Error!.Summary, Is.EqualTo("Invalid country choice."));
        });
    }

    /// <summary>
    /// Tests the retrieving of a specific institution.
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
            Assert.That(result.TransactionTotalDays, Is.EqualTo(90));
        });
    }
}

using RobinTTY.NordigenApiClient.Models.Requests;
using RobinTTY.NordigenApiClient.Models.Responses;
using RobinTTY.NordigenApiClient.Tests.Shared;

namespace RobinTTY.NordigenApiClient.Tests.Mocks.Endpoints;

public class InstitutionsEndpointTests
{
    #region RequestsWithSuccessfulResponse

    /// <summary>
    /// Tests the retrieving of institutions without any country filter applied.
    /// </summary>
    [Test]
    public async Task GetInstitutions()
    {
        var apiClient = TestHelpers.GetMockClient(TestHelpers.MockData.InstitutionsEndpointMockData.GetInstitutions,
            HttpStatusCode.OK);

        var institutions = await apiClient.InstitutionsEndpoint.GetInstitutions();

        Assert.Multiple(() =>
        {
            AssertionHelpers.AssertNordigenApiResponseIsSuccessful(institutions, HttpStatusCode.OK);
            Assert.That(institutions.Result!, Has.Count.EqualTo(2));
        });
    }
    
    /// <summary>
    /// Tests the retrieving of institutions for a specific country.
    /// </summary>
    [Test]
    public async Task GetInstitutionsInBulgaria()
    {
        var apiClient = TestHelpers.GetMockClient(TestHelpers.MockData.InstitutionsEndpointMockData.GetInstitutions,
            HttpStatusCode.OK);

        var institutions = await apiClient.InstitutionsEndpoint.GetInstitutions(SupportedCountry.Bulgaria);

        Assert.Multiple(() =>
        {
            AssertionHelpers.AssertNordigenApiResponseIsSuccessful(institutions, HttpStatusCode.OK);
            Assert.That(institutions.Result!, Has.Count.EqualTo(2));
        });
    }

    /// <summary>
    /// Tests the retrieving of a specific institution.
    /// </summary>
    [Test]
    public async Task GetInstitution()
    {
        var apiClient = TestHelpers.GetMockClient(TestHelpers.MockData.InstitutionsEndpointMockData.GetInstitution,
            HttpStatusCode.OK);

        var institution = await apiClient.InstitutionsEndpoint.GetInstitution("N26_NTSBDEB1");

        var expectedSupportedFeatures = new[]
        {
            "account_selection",
            "business_accounts",
            "card_accounts",
            "payments",
            "private_accounts"
        };

        Assert.Multiple(() =>
        {
            AssertionHelpers.AssertNordigenApiResponseIsSuccessful(institution, HttpStatusCode.OK);
            Assert.That(institution.Result!.Bic, Is.EqualTo("NTSBDEB1"));
            Assert.That(institution.Result!.Id, Is.EqualTo("N26_NTSBDEB1"));
            Assert.That(institution.Result!.Name, Is.EqualTo("N26 Bank"));
            Assert.That(institution.Result!.TransactionTotalDays, Is.EqualTo(90));

            Assert.That(institution.Result!.SupportedPayments?.SinglePayment,
                Contains.Item(PaymentProduct.SepaCreditTransfers));
            Assert.That(institution.Result!.SupportedPayments?.SinglePayment,
                Contains.Item(PaymentProduct.InstantSepaCreditTransfer));
            Assert.That(institution.Result!.SupportedFeatures, Is.EqualTo(expectedSupportedFeatures));
            Assert.That(institution.Result!.IdentificationCodes, Is.Empty);
        });
    }

    #endregion

    #region RequestsWithErrors

    /// <summary>
    /// Tests the retrieving of institutions for a country which is not covered by the API.
    /// </summary>
    [Test]
    public async Task GetInstitutionsForNotCoveredCountry()
    {
        var apiClient = TestHelpers.GetMockClient(
            TestHelpers.MockData.InstitutionsEndpointMockData.GetInstitutionsForNotCoveredCountry,
            HttpStatusCode.BadRequest);

        var response = await apiClient.InstitutionsEndpoint.GetInstitutions("US");

        Assert.Multiple(() =>
        {
            AssertionHelpers.AssertNordigenApiResponseIsUnsuccessful(response, HttpStatusCode.BadRequest);
            Assert.That(response.Error!.Detail, Is.EqualTo("US is not a valid choice."));
            Assert.That(response.Error!.Summary, Is.EqualTo("Invalid country choice."));
        });
    }

    /// <summary>
    /// Tests the retrieving of an institution with an invalid id.
    /// </summary>
    [Test]
    public async Task GetNonExistingInstitution()
    {
        var apiClient = TestHelpers.GetMockClient(
            TestHelpers.MockData.InstitutionsEndpointMockData.GetNonExistingInstitution,
            HttpStatusCode.NotFound);

        var response = await apiClient.InstitutionsEndpoint.GetInstitution("invalid_id");

        Assert.Multiple(() =>
        {
            AssertionHelpers.AssertNordigenApiResponseIsUnsuccessful(response, HttpStatusCode.NotFound);
            Assert.That(response.Error!.Detail, Is.EqualTo("Not found."));
            Assert.That(response.Error!.Summary, Is.EqualTo("Not found."));
        });
    }

    #endregion
}

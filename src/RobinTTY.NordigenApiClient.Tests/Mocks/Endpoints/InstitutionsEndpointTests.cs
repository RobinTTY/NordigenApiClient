using System.Net;
using RobinTTY.NordigenApiClient.Models.Responses;
using RobinTTY.NordigenApiClient.Tests.Shared;

namespace RobinTTY.NordigenApiClient.Tests.Mocks.Endpoints;

public class InstitutionsEndpointTests
{
    /// <summary>
    /// Tests the retrieving of institutions for all countries and a specific country (Great Britain).
    /// </summary>
    [Test]
    public async Task GetInstitutions()
    {
        var apiClient = TestHelpers.GetMockClient(TestHelpers.MockData.InstitutionsEndpointMockData.GetInstitutions, HttpStatusCode.OK);
        
        var institutions = await apiClient.InstitutionsEndpoint.GetInstitutions();
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(institutions, HttpStatusCode.OK);

        var result = institutions.Result!.ToList();

        Assert.Multiple(() => { Assert.That(result, Has.Count.EqualTo(2)); });
    }

    /// <summary>
    /// Tests the retrieving of a specific institution.
    /// </summary>
    [Test]
    public async Task GetInstitution()
    {
        var apiClient = TestHelpers.GetMockClient(TestHelpers.MockData.InstitutionsEndpointMockData.GetInstitution, HttpStatusCode.OK);
        
        var institution = await apiClient.InstitutionsEndpoint.GetInstitution("N26_NTSBDEB1");
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(institution, HttpStatusCode.OK);

        var result = institution.Result!;
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
            Assert.That(result.Bic, Is.EqualTo("NTSBDEB1"));
            Assert.That(result.Id, Is.EqualTo("N26_NTSBDEB1"));
            Assert.That(result.Name, Is.EqualTo("N26 Bank"));
            Assert.That(result.TransactionTotalDays, Is.EqualTo(90));

            Assert.That(result.SupportedPayments?.SinglePayment, Contains.Item(PaymentProduct.SepaCreditTransfers));
            Assert.That(result.SupportedPayments?.SinglePayment,
                Contains.Item(PaymentProduct.InstantSepaCreditTransfer));
            Assert.That(result.SupportedFeatures, Is.EqualTo(expectedSupportedFeatures));
            Assert.That(result.IdentificationCodes, Is.Empty);
        });
    }
}

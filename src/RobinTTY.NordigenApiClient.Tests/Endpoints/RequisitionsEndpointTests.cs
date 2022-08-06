using System.Net;
using RobinTTY.NordigenApiClient.Models.Errors;
using RobinTTY.NordigenApiClient.Models.Requests;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Tests.Endpoints;

public class RequisitionsEndpointTests
{
    private NordigenClient _apiClient = null!;

    [OneTimeSetUp]
    public void Setup()
    {
        _apiClient = TestExtensions.GetConfiguredClient();
    }

    /// <summary>
    /// Tests the paging mechanism of retrieving requisitions.
    /// Creates 3 requisitions, retrieves them using 3 <see cref="ResponsePage{T}"/>s and deletes the requisitions after.
    /// Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/requisitions/retrieve%20all%20requisitions"></see>
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task GetRequisitionsPaged()
    {
        const string institutionId = "SANDBOXFINANCE_SFIN0000";

        // Create required agreement first
        var agreementRequest = new CreateAgreementRequest(90, 90, new List<string> { "balances", "details", "transactions" }, institutionId);
        var agreementResponse = await _apiClient.AgreementsEndpoint.CreateAgreement(agreementRequest);
        TestExtensions.AssertNordigenApiResponseIsSuccessful(agreementResponse, HttpStatusCode.Created);
        var agreementId = agreementResponse.Result!.Id;

        // Create 3 example requisitions
        var redirect = new Uri("https://github.com/RobinTTY/NordigenApiClient");
        var ids = new List<string>();
        for (var i = 0; i < 3; i++)
        {
            var requisitionRequest = new CreateRequisitionRequest(redirect, institutionId, agreementId, $"internal_reference_{i}", "EN", null, false, false);
            var createResponse = await _apiClient.RequisitionsEndpoint.CreateRequisition(requisitionRequest);
            TestExtensions.AssertNordigenApiResponseIsSuccessful(createResponse, HttpStatusCode.Created);
            ids.Add(createResponse.Result!.Id.ToString());
        }

        // Get a response page for each requisition
        var page1Response = await _apiClient.RequisitionsEndpoint.GetRequisitions(1, 0);
        AssertThatRequisitionsPageContainsRequisition(page1Response, ids);

        var page2Response = await page1Response.Result!.GetNextPage(_apiClient);
        Assert.That(page2Response, Is.Not.Null);
        AssertThatRequisitionsPageContainsRequisition(page2Response!, ids);

        var page3Response = await page2Response!.Result!.GetNextPage(_apiClient);
        Assert.That(page3Response, Is.Not.Null);
        AssertThatRequisitionsPageContainsRequisition(page3Response!, ids);

        // On the last page there should be no Url to a next page, but one for the previous one
        Assert.That(page3Response!.Result!.Next, Is.Null);
        Assert.That(page3Response.Result!.Previous, Is.Not.Null);

        // Go to previous page
        var previousPageResponse = await page3Response.Result!.GetPreviousPage(_apiClient);
        Assert.That(previousPageResponse, Is.Not.Null);

        AssertThatRequisitionsPageContainsRequisition(previousPageResponse!, ids);

        // The previous page requisition id should equal page 2 requisition id
        var prevRequisitionId = previousPageResponse!.Result!.Results.First().Id;
        var page2RequisitionId = page2Response.Result!.Results.First().Id;
        Assert.That(prevRequisitionId, Is.EqualTo(page2RequisitionId));

        // Delete created resources
        var agreementDeletion = await _apiClient.AgreementsEndpoint.DeleteAgreement(agreementId);
        TestExtensions.AssertNordigenApiResponseIsSuccessful(agreementDeletion, HttpStatusCode.OK);

        foreach (var id in ids)
        {
            var result = await _apiClient.RequisitionsEndpoint.DeleteRequisition(id);
            TestExtensions.AssertNordigenApiResponseIsSuccessful(result, HttpStatusCode.OK);
        }
    }

    private void AssertThatRequisitionsPageContainsRequisition(NordigenApiResponse<ResponsePage<Requisition>, BasicError> pagedResponse, List<string> ids)
    {
        TestExtensions.AssertNordigenApiResponseIsSuccessful(pagedResponse, HttpStatusCode.OK);
        var page2Result = pagedResponse.Result!;
        var page2Requisitions = page2Result.Results.ToList();
        Assert.Multiple(() =>
        {
            Assert.That(page2Requisitions, Has.Count.EqualTo(1));
            Assert.That(ids, Does.Contain(page2Requisitions.First().Id.ToString()));
        });
    }
}

using System.Net;
using RobinTTY.NordigenApiClient.Models.Errors;
using RobinTTY.NordigenApiClient.Models.Requests;
using RobinTTY.NordigenApiClient.Models.Responses;
using RobinTTY.NordigenApiClient.Tests.Shared;

namespace RobinTTY.NordigenApiClient.Tests.LiveApi.Endpoints;

internal class RequisitionsEndpointTests
{
    private NordigenClient _apiClient = null!;

    [OneTimeSetUp]
    public void Setup()
    {
        _apiClient = TestHelpers.GetConfiguredClient();
    }

    /// <summary>
    /// Tests the retrieval of all existing requisitions.
    /// </summary>
    [Test]
    public async Task GetRequisitions()
    {
        var response = await _apiClient.RequisitionsEndpoint.GetRequisitions(100, 0);
        TestHelpers.AssertNordigenApiResponseIsSuccessful(response, HttpStatusCode.OK);

        var requisitions = response.Result?.Results.ToList();
        Assert.That(requisitions, Is.Not.Null);
        Assert.That(requisitions, Has.Count.GreaterThan(0));
        Assert.Multiple(() =>
        {
            Assert.That(requisitions!.All(req => req.Status != RequisitionStatus.Undefined));
            Assert.That(requisitions, Has.All.Matches<Requisition>(req => req.Id != Guid.Empty));
        });
    }

    /// <summary>
    /// Tests all methods of the requisitions endpoint.
    /// Creates 3 requisitions, retrieves them using 3 <see cref="ResponsePage{T}" />s and deletes the requisitions after.
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task GetRequisitionsPaged()
    {
        const string institutionId = "SANDBOXFINANCE_SFIN0000";

        // Create required agreement first
        var agreementRequest = new CreateAgreementRequest(90, 90,
            new List<string> {"balances", "details", "transactions"}, institutionId);
        var agreementResponse = await _apiClient.AgreementsEndpoint.CreateAgreement(agreementRequest);
        TestHelpers.AssertNordigenApiResponseIsSuccessful(agreementResponse, HttpStatusCode.Created);
        var agreementId = agreementResponse.Result!.Id;

        // Get existing requisitions
        var existingRequisitions = await _apiClient.RequisitionsEndpoint.GetRequisitions(100, 0);
        TestHelpers.AssertNordigenApiResponseIsSuccessful(existingRequisitions, HttpStatusCode.OK);

        // Create 3 example requisitions
        var redirect = new Uri("https://github.com/RobinTTY/NordigenApiClient");
        var ids = new List<string>();

        var existingIds = existingRequisitions.Result!.Results.Select(agreement => agreement.Id.ToString()).ToList();
        ids.AddRange(existingIds);
        for (var i = 3; i < 6; i++)
        {
            var requisitionRequest =
                new CreateRequisitionRequest(redirect, institutionId, $"reference_{i}", "EN", agreementId);
            var createResponse = await _apiClient.RequisitionsEndpoint.CreateRequisition(requisitionRequest);
            TestHelpers.AssertNordigenApiResponseIsSuccessful(createResponse, HttpStatusCode.Created);
            ids.Add(createResponse.Result!.Id.ToString());
        }

        // Get a response page for each requisition
        var page1Response = await _apiClient.RequisitionsEndpoint.GetRequisitions(1, 0);
        AssertThatRequisitionsPageContainsRequisition(page1Response, ids);
        Assert.That(page1Response.Result!.Results.Single().AuthenticationLink.ToString(), Is.Not.Empty);

        var page2Response = await page1Response.Result!.GetNextPage(_apiClient);
        Assert.That(page2Response, Is.Not.Null);
        AssertThatRequisitionsPageContainsRequisition(page2Response!, ids);

        var page3Response = await page2Response!.Result!.GetNextPage(_apiClient);
        Assert.That(page3Response, Is.Not.Null);
        AssertThatRequisitionsPageContainsRequisition(page3Response!, ids);

        // On the last page there should be a Url to the previous one
        Assert.That(page3Response!.Result!.Previous, Is.Not.Null);

        // Go to previous page
        var previousPageResponse = await page3Response.Result!.GetPreviousPage(_apiClient);
        Assert.That(previousPageResponse, Is.Not.Null);

        AssertThatRequisitionsPageContainsRequisition(previousPageResponse!, ids);

        // The previous page requisition id should equal page 2 requisition id
        var prevRequisitionId = previousPageResponse!.Result!.Results.First().Id;
        var page2RequisitionId = page2Response.Result!.Results.First().Id;
        Assert.That(prevRequisitionId, Is.EqualTo(page2RequisitionId));

        // Retrieve a single requisition via guid/string id
        var requisitionResponseGuid = await _apiClient.RequisitionsEndpoint.GetRequisition(page2RequisitionId);
        TestHelpers.AssertNordigenApiResponseIsSuccessful(requisitionResponseGuid, HttpStatusCode.OK);
        var requisitionResponseString =
            await _apiClient.RequisitionsEndpoint.GetRequisition(page2RequisitionId.ToString());
        TestHelpers.AssertNordigenApiResponseIsSuccessful(requisitionResponseString, HttpStatusCode.OK);
        Assert.That(requisitionResponseString.Result!.Id, Is.EqualTo(requisitionResponseGuid.Result!.Id));

        // Delete created resources
        var agreementDeletion = await _apiClient.AgreementsEndpoint.DeleteAgreement(agreementId);
        TestHelpers.AssertNordigenApiResponseIsSuccessful(agreementDeletion, HttpStatusCode.OK);
        existingIds.ForEach(id => ids.Remove(id));
        foreach (var id in ids)
        {
            var result = await _apiClient.RequisitionsEndpoint.DeleteRequisition(id);
            TestHelpers.AssertNordigenApiResponseIsSuccessful(result, HttpStatusCode.OK);
        }
    }

    /// <summary>
    /// Tests the retrieval of a requisition with an invalid guid.
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task GetRequisitionWithInvalidGuid()
    {
        const string guid = "f84d7b8-dee4-4cd9-bc6d-842ef78f6028";
        var response = await _apiClient.RequisitionsEndpoint.GetRequisition(guid);
        TestHelpers.AssertNordigenApiResponseIsUnsuccessful(response, HttpStatusCode.NotFound);
        Assert.That(response.Error!.Detail, Is.EqualTo("Not found."));
    }

    /// <summary>
    /// Tests the creation of an end user agreement with invalid id.
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task CreateRequisitionWithInvalidId()
    {
        var redirect = new Uri("ftp://ftp.test.com");
        var agreementId = Guid.Empty;
        var requisitionRequest =
            new CreateRequisitionRequest(redirect, "123", "internal_reference", "EN", agreementId, null, true, true);
        var response = await _apiClient.RequisitionsEndpoint.CreateRequisition(requisitionRequest);

        TestHelpers.AssertNordigenApiResponseIsUnsuccessful(response, HttpStatusCode.BadRequest);
        Assert.Multiple(() =>
        {
            Assert.That(response.Error!.Summary, Is.EqualTo("Invalid  ID"));
            Assert.That(response.Error!.Detail,
                Is.EqualTo("00000000-0000-0000-0000-000000000000 is not a valid  UUID. "));
        });
    }

    private static void AssertThatRequisitionsPageContainsRequisition(
        NordigenApiResponse<ResponsePage<Requisition>, BasicResponse> pagedResponse, List<string> ids)
    {
        TestHelpers.AssertNordigenApiResponseIsSuccessful(pagedResponse, HttpStatusCode.OK);
        var page2Result = pagedResponse.Result!;
        var page2Requisitions = page2Result.Results.ToList();
        Assert.Multiple(() =>
        {
            Assert.That(page2Requisitions, Has.Count.EqualTo(1));
            Assert.That(ids, Does.Contain(page2Requisitions.First().Id.ToString()));
            Assert.That(page2Requisitions.ToList().All(req => req.Status != RequisitionStatus.Undefined));
        });
    }
}

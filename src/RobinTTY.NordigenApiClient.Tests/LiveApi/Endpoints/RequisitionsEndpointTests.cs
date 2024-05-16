using RobinTTY.NordigenApiClient.Models.Requests;
using RobinTTY.NordigenApiClient.Models.Responses;
using RobinTTY.NordigenApiClient.Tests.Shared;

namespace RobinTTY.NordigenApiClient.Tests.LiveApi.Endpoints;

public class RequisitionsEndpointTests
{
    private NordigenClient _apiClient = null!;

    [OneTimeSetUp]
    public void Setup()
    {
        _apiClient = TestHelpers.GetConfiguredClient();
    }

    #region RequestsWithSuccessfulResponse

    /// <summary>
    /// Tests the retrieval of all existing requisitions.
    /// </summary>
    [Test]
    public async Task GetRequisitions()
    {
        var response = await _apiClient.RequisitionsEndpoint.GetRequisitions(100, 0);

        var requisitions = response.Result?.Results.ToList();

        Assert.Multiple(() =>
        {
            AssertionHelpers.AssertNordigenApiResponseIsSuccessful(response, HttpStatusCode.OK);
            Assert.That(requisitions, Is.Not.Null);
            Assert.That(requisitions, Has.Count.GreaterThan(0));
            Assert.That(requisitions!.All(req => req.Status != RequisitionStatus.Undefined));
            Assert.That(requisitions, Has.All.Matches<Requisition>(req => req.Id != Guid.Empty));
        });
    }

    /// <summary>
    /// Tests all methods of the requisitions endpoint.
    /// Creates 3 requisitions, retrieves them using 3 <see cref="ResponsePage{T}" />s and deletes the requisitions after.
    /// </summary>
    [Test]
    public async Task GetRequisitionsPaged()
    {
        const string institutionId = "SANDBOXFINANCE_SFIN0000";

        // Create required agreement first
        var agreementResponse = await _apiClient.AgreementsEndpoint.CreateAgreement(institutionId);
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(agreementResponse, HttpStatusCode.Created);
        var agreementId = agreementResponse.Result!.Id;

        // Get existing requisitions
        var existingRequisitions = await _apiClient.RequisitionsEndpoint.GetRequisitions(100, 0);
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(existingRequisitions, HttpStatusCode.OK);

        // Create 3 example requisitions
        var redirect = new Uri("https://github.com/RobinTTY/NordigenApiClient");
        var ids = new List<string>();

        var existingIds = existingRequisitions.Result!.Results.Select(agreement => agreement.Id.ToString()).ToList();
        ids.AddRange(existingIds);
        for (var i = 3; i < 6; i++)
        {
            var createResponse =
                await _apiClient.RequisitionsEndpoint.CreateRequisition(institutionId, redirect, agreementId,
                    $"reference_{i}");
            AssertionHelpers.AssertNordigenApiResponseIsSuccessful(createResponse, HttpStatusCode.Created);
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
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(requisitionResponseGuid, HttpStatusCode.OK);
        var requisitionResponseString =
            await _apiClient.RequisitionsEndpoint.GetRequisition(page2RequisitionId.ToString());
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(requisitionResponseString, HttpStatusCode.OK);
        Assert.That(requisitionResponseString.Result!.Id, Is.EqualTo(requisitionResponseGuid.Result!.Id));

        // Delete created resources
        var agreementDeletion = await _apiClient.AgreementsEndpoint.DeleteAgreement(agreementId);
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(agreementDeletion, HttpStatusCode.OK);
        existingIds.ForEach(id => ids.Remove(id));
        foreach (var id in ids)
        {
            var result = await _apiClient.RequisitionsEndpoint.DeleteRequisition(id);
            AssertionHelpers.AssertNordigenApiResponseIsSuccessful(result, HttpStatusCode.OK);
        }
    }

    private static void AssertThatRequisitionsPageContainsRequisition(
        NordigenApiResponse<ResponsePage<Requisition>, BasicResponse> pagedResponse, List<string> ids)
    {
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(pagedResponse, HttpStatusCode.OK);
        var page2Result = pagedResponse.Result!;
        var page2Requisitions = page2Result.Results.ToList();

        Assert.Multiple(() =>
        {
            Assert.That(page2Requisitions, Has.Count.EqualTo(1));
            Assert.That(ids, Does.Contain(page2Requisitions.First().Id.ToString()));
            Assert.That(page2Requisitions.ToList().All(req => req.Status != RequisitionStatus.Undefined));
        });
    }

    #endregion

    #region RequestsWithErrors

    /// <summary>
    /// Tests the retrieval of a requisition with an invalid guid.
    /// </summary>
    [Test]
    public async Task GetRequisitionWithInvalidGuid()
    {
        const string guid = "f84d7b8-dee4-4cd9-bc6d-842ef78f6028";

        var response = await _apiClient.RequisitionsEndpoint.GetRequisition(guid);

        Assert.Multiple(() =>
        {
            AssertionHelpers.AssertNordigenApiResponseIsUnsuccessful(response, HttpStatusCode.NotFound);
            Assert.That(response.Error!.Detail, Is.EqualTo("Not found."));
        });
    }

    /// <summary>
    /// Tests the creation of an end user agreement with invalid id.
    /// </summary>
    [Test]
    public async Task CreateRequisitionWithInvalidId()
    {
        var redirect = new Uri("ftp://ftp.test.com");
        var agreementId = Guid.Empty;
        var response = await _apiClient.RequisitionsEndpoint.CreateRequisition("123", redirect, agreementId,
            "internal_reference", "EN", null, true, true);

        AssertionHelpers.AssertNordigenApiResponseIsUnsuccessful(response, HttpStatusCode.BadRequest);
        Assert.Multiple(() =>
        {
            Assert.That(response.Error!.Summary, Is.EqualTo("Invalid  ID"));
            Assert.That(response.Error!.Detail,
                Is.EqualTo("00000000-0000-0000-0000-000000000000 is not a valid  UUID. "));
        });
    }

    /// <summary>
    /// Tests the creation of an end user agreement with invalid parameters in the <see cref="CreateRequisitionRequest" />.
    /// </summary>
    [Test]
    public async Task CreateRequisitionWithInvalidParameters()
    {
        var redirect = new Uri("ftp://ftp.test.com");
        // Agreement belongs to SANDBOXFINANCE_SFIN0000
        var agreementId = Guid.Parse("f34c3c71-4a62-4a25-b998-3f37ddce84a2");

        var response =
            await _apiClient.RequisitionsEndpoint.CreateRequisition("", redirect, agreementId, "", "AB", "12345", true,
                true);

        Assert.Multiple(() =>
        {
            AssertionHelpers.AssertNordigenApiResponseIsUnsuccessful(response, HttpStatusCode.BadRequest);

            Assert.That(response.Error!.AccountSelectionError!.Summary, Is.EqualTo("Account selection not supported"));
            Assert.That(response.Error!.AccountSelectionError!.Detail,
                Is.EqualTo("Account selection not supported for "));

            Assert.That(response.Error!.AgreementError!.Summary, Is.EqualTo("Incorrect Institution ID "));
            Assert.That(response.Error!.AgreementError!.Detail,
                Is.EqualTo(
                    "Provided Institution ID: '' for requisition does not match EUA institution ID 'SANDBOXFINANCE_SFIN0000'. Please provide correct institution ID: 'SANDBOXFINANCE_SFIN0000'"));

            Assert.That(response.Error!.InstitutionIdError!.Summary, Is.EqualTo("This field may not be blank."));
            Assert.That(response.Error!.InstitutionIdError!.Detail, Is.EqualTo("This field may not be blank."));

            Assert.That(response.Error!.ReferenceError!.Summary, Is.EqualTo("This field may not be blank."));
            Assert.That(response.Error!.ReferenceError!.Detail, Is.EqualTo("This field may not be blank."));

            Assert.That(response.Error!.SocialSecurityNumberError!.Summary,
                Is.EqualTo("SSN verification not supported"));
            Assert.That(response.Error!.SocialSecurityNumberError!.Detail,
                Is.EqualTo("SSN verification not supported for "));

            Assert.That(response.Error!.UserLanguageError!.Summary,
                Is.EqualTo("Provided user_language is invalid or not supported"));
            Assert.That(response.Error!.UserLanguageError!.Detail,
                Is.EqualTo("'AB' is an invalid or unsupported language"));
        });
    }

    #endregion
}

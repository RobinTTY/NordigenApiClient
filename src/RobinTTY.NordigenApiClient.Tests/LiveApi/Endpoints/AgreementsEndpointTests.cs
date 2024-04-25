﻿using RobinTTY.NordigenApiClient.Models.Requests;
using RobinTTY.NordigenApiClient.Models.Responses;
using RobinTTY.NordigenApiClient.Tests.Shared;

namespace RobinTTY.NordigenApiClient.Tests.LiveApi.Endpoints;

public class AgreementsEndpointTests
{
    private NordigenClient _apiClient = null!;

    [OneTimeSetUp]
    public void Setup()
    {
        _apiClient = TestHelpers.GetConfiguredClient();
    }

    #region RequestsWithSuccessfulResponse

    /// <summary>
    /// Tests the paging mechanism of retrieving end user agreements.
    /// Creates 3 agreements, retrieves them using 3 <see cref="ResponsePage{T}" />s and deletes the agreements after.
    /// </summary>
    [Test]
    public async Task GetAgreementsPaged()
    {
        // Get existing agreements
        var existingAgreements = await _apiClient.AgreementsEndpoint.GetAgreements(100, 0);
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(existingAgreements, HttpStatusCode.OK);

        // Create 3 example agreements
        var agreementRequest = new CreateAgreementRequest(90, 90,
            ["balances", "details", "transactions"], "SANDBOXFINANCE_SFIN0000");
        var ids = new List<string>();

        var existingIds = existingAgreements.Result!.Results.Select(agreement => agreement.Id.ToString()).ToList();
        ids.AddRange(existingIds);
        for (var i = 0; i < 3; i++)
        {
            var createResponse = await _apiClient.AgreementsEndpoint.CreateAgreement(agreementRequest);
            AssertionHelpers.AssertNordigenApiResponseIsSuccessful(createResponse, HttpStatusCode.Created);
            ids.Add(createResponse.Result!.Id.ToString());
        }

        // Get a response page for each agreement
        var page1Response = await _apiClient.AgreementsEndpoint.GetAgreements(1, 0);
        AssertionHelpers.AssertThatAgreementPageContainsAgreement(page1Response, ids);

        var page2Response = await page1Response.Result!.GetNextPage(_apiClient);
        Assert.That(page2Response, Is.Not.Null);
        AssertionHelpers.AssertThatAgreementPageContainsAgreement(page2Response!, ids);

        var page3Response = await page2Response!.Result!.GetNextPage(_apiClient);
        Assert.That(page3Response, Is.Not.Null);
        AssertionHelpers.AssertThatAgreementPageContainsAgreement(page3Response!, ids);

        // On the last page there should be a Url to the previous one
        Assert.That(page3Response!.Result!.Previous, Is.Not.Null);

        // Go to previous page
        var previousPageResponse = await page3Response.Result!.GetPreviousPage(_apiClient);
        Assert.That(previousPageResponse, Is.Not.Null);

        AssertionHelpers.AssertThatAgreementPageContainsAgreement(previousPageResponse!, ids);

        // The previous page agreement id should equal page 2 agreement id
        var prevAgreementId = previousPageResponse!.Result!.Results.First().Id;
        var page2AgreementId = page2Response.Result!.Results.First().Id;
        Assert.That(prevAgreementId, Is.EqualTo(page2AgreementId));

        // Delete created agreements
        existingIds.ForEach(id => ids.Remove(id));
        foreach (var id in ids)
        {
            var result = await _apiClient.AgreementsEndpoint.DeleteAgreement(id);
            AssertionHelpers.AssertNordigenApiResponseIsSuccessful(result, HttpStatusCode.OK);
        }
    }

    /// <summary>
    /// Tests the retrieval of one agreement via <see cref="Guid" /> and string id.
    /// </summary>
    [Test]
    public async Task GetAgreement()
    {
        // Create agreement
        var agreementRequest = new CreateAgreementRequest(90, 90,
            ["balances", "details", "transactions"], "SANDBOXFINANCE_SFIN0000");
        var createResponse = await _apiClient.AgreementsEndpoint.CreateAgreement(agreementRequest);
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(createResponse, HttpStatusCode.Created);
        var id = createResponse.Result!.Id;

        // Get agreement via guid and string id, should retrieve the same agreement
        var agreementResponseGuid = await _apiClient.AgreementsEndpoint.GetAgreement(id);
        var agreementResponseString = await _apiClient.AgreementsEndpoint.GetAgreement(id.ToString());
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(agreementResponseGuid, HttpStatusCode.OK);
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(agreementResponseString, HttpStatusCode.OK);
        Assert.That(agreementResponseGuid.Result!.Id, Is.EqualTo(agreementResponseString.Result!.Id));

        // Delete agreement
        var deleteResponse = await _apiClient.AgreementsEndpoint.DeleteAgreement(id);
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(deleteResponse, HttpStatusCode.OK);
    }

    /// <summary>
    /// Tests the retrieval of an agreement with an invalid guid.
    /// </summary>
    [Test]
    public async Task GetAgreementWithInvalidGuid()
    {
        const string guid = "f84d7b8-dee4-4cd9-bc6d-842ef78f6028";
        var response = await _apiClient.AgreementsEndpoint.GetAgreement(guid);
        AssertionHelpers.AssertNordigenApiResponseIsUnsuccessful(response, HttpStatusCode.BadRequest);
        AssertionHelpers.AssertBasicResponseMatchesExpectations(response.Error, "Invalid EndUserAgreement ID",
            $"{guid} is not a valid EndUserAgreement UUID. ");
    }

    /// <summary>
    /// Tests the creation and deletion of an end user agreement.
    /// </summary>
    [Test]
    public async Task CreateAcceptAndDeleteAgreement()
    {
        // Create the agreement
        var agreement = new CreateAgreementRequest(90, 90, ["balances", "details", "transactions"],
            "SANDBOXFINANCE_SFIN0000");
        var response = await _apiClient.AgreementsEndpoint.CreateAgreement(agreement);
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(response, HttpStatusCode.Created);

        var result = response.Result!;
        Assert.Multiple(() =>
        {
            Assert.That(result.Id, Is.Not.EqualTo(Guid.Empty));
            Assert.That(result.Created - DateTime.UtcNow, Is.AtMost(TimeSpan.FromSeconds(5)));
            Assert.That(result.Accepted, Is.Null);
            Assert.That(result.AccessScope.Except(new[] {"balances", "details", "transactions"}), Is.Empty);
            Assert.That(result.MaxHistoricalDays, Is.EqualTo(90));
            Assert.That(result.AccessValidForDays, Is.EqualTo(90));
        });

        // Accept the agreement (should fail)
        var acceptMetadata = new AcceptAgreementRequest("example_user_agent", "192.168.178.1");
        var acceptResponse = await _apiClient.AgreementsEndpoint.AcceptAgreement(response.Result!.Id, acceptMetadata);
        AssertionHelpers.AssertNordigenApiResponseIsUnsuccessful(acceptResponse, HttpStatusCode.Forbidden);
        Assert.That(acceptResponse.Error!.Detail,
            Is.EqualTo(
                "Your company doesn't have permission to accept EUA. You'll have to use our default form for this action."));

        // Delete the agreement
        var deletionResponse = await _apiClient.AgreementsEndpoint.DeleteAgreement(result.Id);
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(deletionResponse, HttpStatusCode.OK);
        Assert.That(deletionResponse.Result!.Summary, Is.EqualTo("End User Agreement deleted"));
    }

    #endregion

    #region RequestsWithErrors

    /// <summary>
    /// Tests the retrieving of an end user agreement with an invalid institution id.
    /// </summary>
    [Test]
    public async Task GetAgreementWithInvalidInstitutionId()
    {
        var agreement = new CreateAgreementRequest(90, 90,
            ["balances", "details", "transactions"], "invalid_institution");

        var response = await _apiClient.AgreementsEndpoint.CreateAgreement(agreement);

        AssertionHelpers.AssertNordigenApiResponseIsUnsuccessful(response, HttpStatusCode.BadRequest);
        Assert.Multiple(() =>
        {
            Assert.That(response.Error!.InstitutionIdError, Is.Not.Null);
            Assert.That(response.Error!.InstitutionIdError!.Summary,
                Is.EqualTo("Unknown Institution ID invalid_institution"));
            Assert.That(response.Error!.InstitutionIdError!.Detail,
                Is.EqualTo("Get Institution IDs from /institutions/?country={$COUNTRY_CODE}"));
        });
    }

    /// <summary>
    /// Tests the creation of an end user agreement with an invalid institution id.
    /// </summary>
    [Test]
    public async Task CreateAgreementWithInvalidInstitutionId()
    {
        var agreement = new CreateAgreementRequest(90, 90,
            ["balances", "details", "transactions"], "invalid_institution");

        var response = await _apiClient.AgreementsEndpoint.CreateAgreement(agreement);

        AssertionHelpers.AssertNordigenApiResponseIsUnsuccessful(response, HttpStatusCode.BadRequest);
        Assert.Multiple(() =>
        {
            Assert.That(response.Error!.InstitutionIdError, Is.Not.Null);
            Assert.That(response.Error!.InstitutionIdError!.Summary,
                Is.EqualTo("Unknown Institution ID invalid_institution"));
            Assert.That(response.Error!.InstitutionIdError!.Detail,
                Is.EqualTo("Get Institution IDs from /institutions/?country={$COUNTRY_CODE}"));
        });
    }

    /// <summary>
    /// Tests the creation of an end user agreement with invalid parameters.
    /// </summary>
    [Test]
    public async Task CreateAgreementWithInvalidParams()
    {
        var agreement = new CreateAgreementRequest(200, 200,
            ["balances", "details", "transactions", "invalid", "invalid2"], "SANDBOXFINANCE_SFIN0000");

        var response = await _apiClient.AgreementsEndpoint.CreateAgreement(agreement);
        var result = response.Error!;

        Assert.Multiple(() =>
        {
            AssertionHelpers.AssertNordigenApiResponseIsUnsuccessful(response, HttpStatusCode.BadRequest);
            Assert.That(new[] {result.InstitutionIdError, result.AgreementError}, Has.All.Null);
            Assert.That(result.AccessScopeError!.Detail,
                Is.EqualTo("Choose one or several from ['balances', 'details', 'transactions']"));
            Assert.That(result.AccessValidForDaysError!.Detail,
                Is.EqualTo("access_valid_for_days must be > 0 and <= 180"));
            Assert.That(result.MaxHistoricalDaysError!.Detail,
                Is.EqualTo(
                    "max_historical_days must be > 0 and <= SANDBOXFINANCE_SFIN0000 transaction_total_days (90)"));
        });
    }

    [Test]
    public async Task CreateAgreementWithInvalidParamsAtPolishInstitution()
    {
        var agreement = new CreateAgreementRequest(90, 90,
            ["balances", "transactions"], "PKO_BPKOPLPW");

        var response = await _apiClient.AgreementsEndpoint.CreateAgreement(agreement);
        var result = response.Error!;

        Assert.Multiple(() =>
        {
            AssertionHelpers.AssertNordigenApiResponseIsUnsuccessful(response, HttpStatusCode.BadRequest);
            Assert.That(new[] {result.InstitutionIdError, result.AgreementError}, Has.All.Null);
            Assert.That(result.Detail,
                Is.EqualTo("For this institution the following scopes are required together: ['details', 'balances']"));
            Assert.That(result.Summary, Is.EqualTo("Institution access scope dependencies error"));
        });
    }

    #endregion
}

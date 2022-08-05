using System.Net;
using RobinTTY.NordigenApiClient.Models.Errors;
using RobinTTY.NordigenApiClient.Models.Requests;
using RobinTTY.NordigenApiClient.Models.Responses;

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
    /// Tests the paging mechanism of retrieving end user agreements.
    /// Creates 3 agreements, retrieves them using 3 <see cref="ResponsePage{T}"/>s and deletes the agreements after.
    /// Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/agreements/retrieve%20all%20EUAs%20for%20an%20end%20user%20v2"></see>
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task GetAgreementsPaged()
    {
        // Create 3 example agreements
        var agreementRequest = new CreateAgreementRequest(90, 90, new List<string> { "balances", "details", "transactions" }, "SANDBOXFINANCE_SFIN0000");
        var ids = new List<string>();
        for (var i = 0; i < 3; i++)
        {
            var createResponse = await _apiClient.AgreementsEndpoint.CreateAgreement(agreementRequest);
            TestExtensions.AssertNordigenApiResponseIsSuccessful(createResponse, HttpStatusCode.Created);
            ids.Add(createResponse.Result!.Id.ToString());
        }
        
        // Get a response page for each agreement
        var page1Response = await _apiClient.AgreementsEndpoint.GetAgreements(1, 0);
        AssertThatAgreementPageContainsAgreement(page1Response, ids);

        var page2Response = await page1Response.Result!.GetNextPage(_apiClient);
        Assert.That(page2Response, Is.Not.Null);
        AssertThatAgreementPageContainsAgreement(page2Response!, ids);

        var page3Response = await page2Response!.Result!.GetNextPage(_apiClient);
        Assert.That(page3Response, Is.Not.Null);
        AssertThatAgreementPageContainsAgreement(page3Response!, ids);
        
        // On the last page there should be no Url to a next page, but one for the previous one
        Assert.That(page3Response!.Result!.Next, Is.Null);
        Assert.That(page3Response.Result!.Previous, Is.Not.Null);

        // Go to previous page
        var previousPageResponse = await page3Response.Result!.GetPreviousPage(_apiClient);
        Assert.That(previousPageResponse, Is.Not.Null);

        AssertThatAgreementPageContainsAgreement(previousPageResponse!, ids);

        // The previous page agreement id should equal page 2 agreement id
        var prevAgreementId = previousPageResponse!.Result!.Results.First().Id;
        var page2AgreementId = page2Response.Result!.Results.First().Id;
        Assert.That(prevAgreementId, Is.EqualTo(page2AgreementId));

        // Delete created agreements
        foreach (var id in ids)
        {
            var result = await _apiClient.AgreementsEndpoint.DeleteAgreement(id);
            TestExtensions.AssertNordigenApiResponseIsSuccessful(result, HttpStatusCode.OK);
        }
    }

    /// <summary>
    /// Tests the retrieval of one agreement via <see cref="Guid"/> and string id.
    /// Route: https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/agreements/retrieve%20EUA%20by%20id%20v2
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task GetAgreementWithGuid()
    {
        // Create agreement
        var agreementRequest = new CreateAgreementRequest(90, 90, new List<string> { "balances", "details", "transactions" }, "SANDBOXFINANCE_SFIN0000");
        var createResponse = await _apiClient.AgreementsEndpoint.CreateAgreement(agreementRequest);
        TestExtensions.AssertNordigenApiResponseIsSuccessful(createResponse, HttpStatusCode.Created);
        var id = createResponse.Result!.Id;

        // Get agreement via guid and string id, should retrieve the same agreement
        var agreementResponseGuid = await _apiClient.AgreementsEndpoint.GetAgreement(id);
        var agreementResponseString = await _apiClient.AgreementsEndpoint.GetAgreement(id.ToString());
        TestExtensions.AssertNordigenApiResponseIsSuccessful(agreementResponseGuid, HttpStatusCode.OK);
        TestExtensions.AssertNordigenApiResponseIsSuccessful(agreementResponseString, HttpStatusCode.OK);
        Assert.That(agreementResponseGuid.Result!.Id, Is.EqualTo(agreementResponseString.Result!.Id));
        
        // Delete agreement
        var deleteResponse = await _apiClient.AgreementsEndpoint.DeleteAgreement(id);
        TestExtensions.AssertNordigenApiResponseIsSuccessful(deleteResponse, HttpStatusCode.OK);
    }

    /// <summary>
    /// Tests the retrieval of an agreement with an invalid guid.
    /// Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/agreements/create%20EUA%20v2"/>
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task GetAgreementWithInvalidGuid()
    {
        const string guid = "f84d7b8-dee4-4cd9-bc6d-842ef78f6028";
        var response = await _apiClient.AgreementsEndpoint.GetAgreement(guid);
        TestExtensions.AssertNordigenApiResponseIsUnsuccessful(response, HttpStatusCode.NotFound);
        Assert.That(response.Error!.Detail, Is.EqualTo("Not found."));
    }

    /// <summary>
    /// Tests the creation and deletion of an end user agreement.
    /// Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/agreements/create%20EUA%20v2"/>
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task CreateAcceptAndDeleteAgreement()
    {
        // Create the agreement
        var agreement = new CreateAgreementRequest(90, 90, new List<string> { "balances", "details", "transactions" }, "SANDBOXFINANCE_SFIN0000");
        var response = await _apiClient.AgreementsEndpoint.CreateAgreement(agreement);
        TestExtensions.AssertNordigenApiResponseIsSuccessful(response, HttpStatusCode.Created);

        var result = response.Result!;
        Assert.Multiple(() =>
        {
            Assert.That(result.Id, Is.Not.EqualTo(Guid.Empty));
            Assert.That(result.Created - DateTime.UtcNow, Is.AtMost(TimeSpan.FromSeconds(5)));
            Assert.That(result.Accepted, Is.Null);
            Assert.That(result.AccessScope.Except(new[] { "balances", "details", "transactions" }), Is.Empty);
            Assert.That(result.MaxHistoricalDays, Is.EqualTo(90));
            Assert.That(result.AccessValidForDays, Is.EqualTo(90));
        });

        // Accept the agreement (should fail)
        var acceptMetadata = new AcceptAgreementRequest("example_user_agent", "192.168.178.1");
        var acceptResponse = await _apiClient.AgreementsEndpoint.AcceptAgreement(response.Result!.Id, acceptMetadata);
        TestExtensions.AssertNordigenApiResponseIsUnsuccessful(acceptResponse, HttpStatusCode.Forbidden);
        Assert.That(acceptResponse.Error!.Detail, Is.EqualTo("Your company doesn't have permission to accept EUA. You'll have to use our default form for this action."));

        // Delete the agreement
        var deletionResponse = await _apiClient.AgreementsEndpoint.DeleteAgreement(result.Id);
        TestExtensions.AssertNordigenApiResponseIsSuccessful(deletionResponse, HttpStatusCode.OK);
        Assert.That(deletionResponse.Result!.Summary, Is.EqualTo("End User Agreement deleted"));
    }

    /// <summary>
    /// Tests the creation of an end user agreement with an invalid institution id.
    /// Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/agreements/create%20EUA%20v2"/>
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task CreateAgreementWithInvalidInstitutionId()
    {
        var agreement = new CreateAgreementRequest(90, 90, new List<string> { "balances", "details", "transactions" }, "SANDBOXFINANCE_SFIN000");
        var response = await _apiClient.AgreementsEndpoint.CreateAgreement(agreement);
        TestExtensions.AssertNordigenApiResponseIsUnsuccessful(response, HttpStatusCode.BadRequest);

        var result = response.Error!;
        Assert.That(result.InstitutionIdError.Detail, Is.EqualTo("Get Institution IDs from /institutions/?country={$COUNTRY_CODE}"));
    }

    /// <summary>
    /// Tests the creation of an end user agreement with invalid parameters.
    /// <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/agreements/create%20EUA%20v2"/>
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task CreateAgreementWithInvalidParams()
    {
        var agreement = new CreateAgreementRequest(200, 200, new List<string> { "balances", "details", "transactions", "invalid", "invalid2" }, "SANDBOXFINANCE_SFIN0000");
        var response = await _apiClient.AgreementsEndpoint.CreateAgreement(agreement);
        TestExtensions.AssertNordigenApiResponseIsUnsuccessful(response, HttpStatusCode.BadRequest);

        var result = response.Error!;
        Assert.Multiple(() =>
        {
            Assert.That(result.AccessScopeError.Detail, Is.EqualTo("Choose one or several from ['balances', 'details', 'transactions']"));
            Assert.That(result.AccessValidForDaysError.Detail, Is.EqualTo("access_valid_for_days must be > 0 and <= 90"));
            Assert.That(result.MaxHistoricalDaysError.Detail, Is.EqualTo("max_historical_days must be > 0 and <= SANDBOXFINANCE_SFIN0000 transaction_total_days (90)"));
        });
    }

    private void AssertThatAgreementPageContainsAgreement(NordigenApiResponse<ResponsePage<Agreement>, BasicError> pagedResponse, List<string> ids)
    {
        TestExtensions.AssertNordigenApiResponseIsSuccessful(pagedResponse!, HttpStatusCode.OK);
        var page2Result = pagedResponse!.Result!;
        var page2Agreements = page2Result.Results.ToList();
        Assert.Multiple(() =>
        {
            Assert.That(page2Agreements, Has.Count.EqualTo(1));
            Assert.That(ids, Does.Contain(page2Agreements.First().Id.ToString()));
        });
    }
}

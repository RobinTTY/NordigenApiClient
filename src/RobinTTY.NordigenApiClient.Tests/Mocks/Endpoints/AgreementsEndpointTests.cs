using FakeItEasy;
using RobinTTY.NordigenApiClient.Models.Requests;
using RobinTTY.NordigenApiClient.Tests.Shared;

namespace RobinTTY.NordigenApiClient.Tests.Mocks.Endpoints;

public class AgreementsEndpointTests
{
    #region RequestsWithSuccessfulResponse

    /// <summary>
    /// Tests the retrieval of end user agreements.
    /// </summary>
    [Test]
    public async Task GetAgreements()
    {
        var apiClient = TestHelpers.GetMockClient(TestHelpers.MockData.AgreementsEndpointMockData.GetAgreements,
            HttpStatusCode.OK);

        var agreements = await apiClient.AgreementsEndpoint.GetAgreements(100, 0);
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(agreements, HttpStatusCode.OK);

        var responseAgreement = agreements.Result!.Results.First();
        Assert.Multiple(() =>
        {
            Assert.That(agreements.Result!.Count, Is.EqualTo(1));
            Assert.That(agreements.Result!.Next,
                Is.EqualTo(new Uri(
                    "https://bankaccountdata.gocardless.com/api/v2/agreements/enduser/?limit=100&offset=0")));
            Assert.That(agreements.Result!.Previous,
                Is.EqualTo(new Uri(
                    "https://bankaccountdata.gocardless.com/api/v2/agreements/enduser/?limit=100&offset=0")));
            Assert.That(agreements.Result!.Results.Count(), Is.EqualTo(1));

            Assert.That(responseAgreement.Id, Is.EqualTo(new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")));
            Assert.That(responseAgreement.Created.ToUniversalTime(),
                Is.EqualTo(DateTime.Parse("2024-04-08T20:57:00.550Z").ToUniversalTime()));
            Assert.That(((DateTime) responseAgreement.Accepted!).ToUniversalTime(),
                Is.EqualTo(DateTime.Parse("2024-04-08T20:57:00.550Z").ToUniversalTime()));
            Assert.That(responseAgreement.InstitutionId, Is.EqualTo("SANDBOXFINANCE_SFIN0000"));
            Assert.That(responseAgreement.MaxHistoricalDays, Is.EqualTo(90));
            Assert.That(responseAgreement.AccessValidForDays, Is.EqualTo(90));
            Assert.That(responseAgreement.AccessScope, Has.Count.EqualTo(3));

            var expectedAccessScopes = new[] {"balances", "details", "transactions"};
            Assert.That(responseAgreement.AccessScope, Is.EqualTo(expectedAccessScopes));
        });
    }

    /// <summary>
    /// Tests the retrieval of an end user agreement by id.
    /// </summary>
    [Test]
    public async Task GetAgreement()
    {
        var apiClient = TestHelpers.GetMockClient(TestHelpers.MockData.AgreementsEndpointMockData.GetAgreement,
            HttpStatusCode.OK);

        var agreement = await apiClient.AgreementsEndpoint.GetAgreement(A.Dummy<Guid>());
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(agreement, HttpStatusCode.OK);

        Assert.Multiple(() =>
        {
            Assert.That(agreement.Result!.Id, Is.EqualTo(new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")));
            Assert.That(agreement.Result!.InstitutionId, Is.EqualTo("SANDBOXFINANCE_SFIN0000"));
            Assert.That(agreement.Result!.MaxHistoricalDays, Is.EqualTo(90));
            Assert.That(agreement.Result!.AccessValidForDays, Is.EqualTo(90));
            Assert.That(agreement.Result!.Created.ToUniversalTime(),
                Is.EqualTo(DateTime.Parse("2024-04-08T22:54:54.869Z").ToUniversalTime()));
            Assert.That(((DateTime) agreement.Result!.Accepted!).ToUniversalTime(),
                Is.EqualTo(DateTime.Parse("2024-04-08T22:54:54.869Z").ToUniversalTime()));
            var expectedAccessScopes = new[] {"balances", "details", "transactions"};
            Assert.That(agreement.Result!.AccessScope, Is.EqualTo(expectedAccessScopes));
        });
    }

    /// <summary>
    /// Tests the creation of end user agreements.
    /// </summary>
    [Test]
    public async Task CreateAgreement()
    {
        var apiClient = TestHelpers.GetMockClient(TestHelpers.MockData.AgreementsEndpointMockData.CreateAgreement,
            HttpStatusCode.Created);

        var agreementRequest = new CreateAgreementRequest(145, 145,
            ["balances", "details", "transactions"], "SANDBOXFINANCE_SFIN0000");
        var createResponse = await apiClient.AgreementsEndpoint.CreateAgreement(agreementRequest);
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(createResponse, HttpStatusCode.Created);

        Assert.Multiple(() =>
        {
            Assert.That(createResponse.Result!.Id, Is.EqualTo(new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7")));
            Assert.That(createResponse.Result!.InstitutionId, Is.EqualTo("SANDBOXFINANCE_SFIN0000"));
            Assert.That(createResponse.Result!.MaxHistoricalDays, Is.EqualTo(145));
            Assert.That(createResponse.Result!.AccessValidForDays, Is.EqualTo(145));

            var expectedAccessScopes = new[] {"balances", "details", "transactions"};
            Assert.That(createResponse.Result!.AccessScope, Is.EqualTo(expectedAccessScopes));
        });
    }

    /// <summary>
    /// Tests the creation of end user agreements.
    /// </summary>
    [Test]
    public async Task DeleteAgreement()
    {
        var apiClient = TestHelpers.GetMockClient(TestHelpers.MockData.AgreementsEndpointMockData.DeleteAgreement,
            HttpStatusCode.OK);

        var result = await apiClient.AgreementsEndpoint.DeleteAgreement(A.Dummy<Guid>());
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(result, HttpStatusCode.OK);
        Assert.Multiple(() =>
        {
            Assert.That(result.Result?.Summary, Is.EqualTo("End User Agreement deleted"));
            Assert.That(result.Result?.Detail,
                Is.EqualTo("End User Agreement bb37bc52-5b1d-44f9-b1cd-ec9594f25387 deleted"));
        });
    }

    #endregion

    #region RequestsWithErrors

    /// <summary>
    /// Tests the retrieval of an agreement with an invalid guid.
    /// </summary>
    [Test]
    public async Task GetAgreementWithInvalidGuid()
    {
        const string guid = "f84d7b8-dee4-4cd9-bc6d-842ef78f6028";
        var apiClient = TestHelpers.GetMockClient(
            TestHelpers.MockData.AgreementsEndpointMockData.GetAgreementWithInvalidGuid,
            HttpStatusCode.BadRequest);

        var response = await apiClient.AgreementsEndpoint.GetAgreement(guid);

        Assert.Multiple(() =>
        {
            AssertionHelpers.AssertNordigenApiResponseIsUnsuccessful(response, HttpStatusCode.BadRequest);
            AssertionHelpers.AssertBasicResponseMatchesExpectations(response.Error, "Invalid EndUserAgreement ID",
                $"{guid} is not a valid EndUserAgreement UUID. ");
        });
    }

    /// <summary>
    /// Tests the creation of an end user agreement with an invalid institution id.
    /// </summary>
    [Test]
    public async Task CreateAgreementWithInvalidInstitutionId()
    {
        var apiClient = TestHelpers.GetMockClient(
            TestHelpers.MockData.AgreementsEndpointMockData.CreateAgreementWithInvalidInstitutionId,
            HttpStatusCode.BadRequest);
        var agreement = new CreateAgreementRequest(90, 90,
            ["balances", "details", "transactions"], "invalid_institution");

        var response = await apiClient.AgreementsEndpoint.CreateAgreement(agreement);

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
        var apiClient = TestHelpers.GetMockClient(
            TestHelpers.MockData.AgreementsEndpointMockData.CreateAgreementWithInvalidParams,
            HttpStatusCode.BadRequest);
        var agreement = new CreateAgreementRequest(200, 200,
            ["balances", "details", "transactions", "invalid", "invalid2"], "SANDBOXFINANCE_SFIN0000");

        var response = await apiClient.AgreementsEndpoint.CreateAgreement(agreement);
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
        var apiClient = TestHelpers.GetMockClient(
            TestHelpers.MockData.AgreementsEndpointMockData.CreateAgreementWithInvalidParamsAtPolishInstitution,
            HttpStatusCode.BadRequest);
        var agreement = new CreateAgreementRequest(90, 90,
            ["balances", "transactions"], "PKO_BPKOPLPW");

        var response = await apiClient.AgreementsEndpoint.CreateAgreement(agreement);

        Assert.Multiple(() =>
        {
            AssertionHelpers.AssertNordigenApiResponseIsUnsuccessful(response, HttpStatusCode.BadRequest);
            Assert.That(new[] {response.Error!.InstitutionIdError, response.Error!.AgreementError}, Has.All.Null);
            Assert.That(response.Error!.Detail,
                Is.EqualTo("For this institution the following scopes are required together: ['details', 'balances']"));
            Assert.That(response.Error!.Summary, Is.EqualTo("Institution access scope dependencies error"));
        });
    }

    #endregion
}

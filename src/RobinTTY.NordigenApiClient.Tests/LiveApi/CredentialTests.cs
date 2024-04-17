using System.Net;
using RobinTTY.NordigenApiClient.Models;
using RobinTTY.NordigenApiClient.Models.Requests;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Tests.LiveApi;

/// <summary>
/// Tests the instantiation of the <see cref="NordigenClient" />.
/// </summary>
internal class CredentialTests
{
    private readonly string[] _secrets = File.ReadAllLines("secrets.txt");

    /// <summary>
    /// Tests the creation of the <see cref="NordigenClient" /> with invalid credentials.
    /// The credentials have the correct structure but were not issued for use.
    /// </summary>
    [Test]
    public async Task MakeRequestWithInvalidCredentials()
    {
        using var httpClient = new HttpClient();
        var invalidCredentials = new NordigenClientCredentials("01234567-89ab-cdef-0123-456789abcdef",
            "0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef");
        var apiClient = new NordigenClient(httpClient, invalidCredentials);

        // Returns BasicError
        var agreementsResponse = await apiClient.AgreementsEndpoint.GetAgreements(10, 0);
        Assert.Multiple(() =>
        {
            Assert.That(agreementsResponse.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            Assert.That(ErrorMatchesExpectation(agreementsResponse.Error!), Is.True);
        });

        // Returns InstitutionsError
        var institutionResponse = await apiClient.InstitutionsEndpoint.GetInstitutions();
        Assert.Multiple(() =>
        {
            Assert.That(institutionResponse.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            Assert.That(ErrorMatchesExpectation(institutionResponse.Error!), Is.True);
        });

        // Returns AccountsError
        var balancesResponse = await apiClient.AccountsEndpoint.GetBalances(_secrets[9]);
        Assert.Multiple(() =>
        {
            Assert.That(balancesResponse.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            Assert.That(ErrorMatchesExpectation(balancesResponse.Error!), Is.True);
            Assert.That(
                new object?[]
                {
                    balancesResponse.Error!.EndDateError, balancesResponse.Error.StartDateError,
                    balancesResponse.Error.Type
                }, Has.All.Null);
        });

        // Returns CreateAgreementError
        var agreementRequest = new CreateAgreementRequest(90, 90,
            ["balances", "details", "transactions"], "SANDBOXFINANCE_SFIN0000");
        var createAgreementResponse = await apiClient.AgreementsEndpoint.CreateAgreement(agreementRequest);
        Assert.Multiple(() =>
        {
            Assert.That(balancesResponse.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            Assert.That(ErrorMatchesExpectation(createAgreementResponse.Error!), Is.True);
            Assert.That(new object?[]
            {
                createAgreementResponse.Error!.AccessScopeError, createAgreementResponse.Error.AccessValidForDaysError,
                createAgreementResponse.Error.AgreementError,
                createAgreementResponse.Error.InstitutionIdError, createAgreementResponse.Error.MaxHistoricalDaysError
            }, Has.All.Null);
        });

        // Returns CreateRequisitionError
        const string institutionId = "SANDBOXFINANCE_SFIN0000";
        var requisitionRequest =
            new CreateRequisitionRequest(new Uri("https://robintty.com"), institutionId, "some_reference", "EN");
        var requisitionResponse = await apiClient.RequisitionsEndpoint.CreateRequisition(requisitionRequest);
        Assert.Multiple(() =>
        {
            Assert.That(balancesResponse.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            Assert.That(ErrorMatchesExpectation(requisitionResponse.Error!), Is.True);
            Assert.That(new object?[]
            {
                requisitionResponse.Error!.AgreementError, requisitionResponse.Error.InstitutionIdError,
                requisitionResponse.Error.AccountSelectionError,
                requisitionResponse.Error.RedirectError, requisitionResponse.Error.ReferenceError,
                requisitionResponse.Error.SocialSecurityNumberError, requisitionResponse.Error.UserLanguageError
            }, Has.All.Null);
        });
    }

    private static bool ErrorMatchesExpectation(BasicResponse error)
    {
        return error is {Detail: "Authentication credentials were not provided.", Summary: "Authentication failed"};
    }
}

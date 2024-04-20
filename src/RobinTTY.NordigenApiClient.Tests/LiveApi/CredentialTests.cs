using System.Net;
using RobinTTY.NordigenApiClient.Models;
using RobinTTY.NordigenApiClient.Models.Requests;
using RobinTTY.NordigenApiClient.Models.Responses;
using RobinTTY.NordigenApiClient.Tests.Shared;

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

        // Returns AccountsError
        var balancesResponse = await apiClient.AccountsEndpoint.GetBalances(_secrets[9]);
        Assert.Multiple(() =>
        {
            Assert.That(balancesResponse.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            AssertErrorMatchesExpectation(balancesResponse.Error!);
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
            AssertErrorMatchesExpectation(createAgreementResponse.Error!);
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
            AssertErrorMatchesExpectation(requisitionResponse.Error!);
            Assert.That(new object?[]
            {
                requisitionResponse.Error!.AgreementError, requisitionResponse.Error.InstitutionIdError,
                requisitionResponse.Error.AccountSelectionError,
                requisitionResponse.Error.RedirectError, requisitionResponse.Error.ReferenceError,
                requisitionResponse.Error.SocialSecurityNumberError, requisitionResponse.Error.UserLanguageError
            }, Has.All.Null);
        });
    }

    private static void AssertErrorMatchesExpectation(BasicResponse error) =>
        AssertionHelpers.AssertBasicResponseMatchesExpectations(error, "Authentication failed",
            "No active account found with the given credentials");
}

using RobinTTY.NordigenApiClient.Events;
using RobinTTY.NordigenApiClient.Models.Jwt;
using RobinTTY.NordigenApiClient.Tests.Shared;

namespace RobinTTY.NordigenApiClient.Tests.Mocks;

public class CredentialTests
{
    #region RequestsWithSuccessfulResponse

    /// <summary>
    /// Tests that <see cref="NordigenClient.JsonWebTokenPair" /> is populated after the first authenticated request is made.
    /// </summary>
    [Test]
    public async Task CheckValidTokensAfterRequest()
    {
        var apiClient = TestHelpers.GetMockClient(TestHelpers.MockData.RequisitionsEndpointMockData.GetRequisitions,
            HttpStatusCode.OK);
        Assert.That(apiClient.JsonWebTokenPair, Is.Null);

        await apiClient.RequisitionsEndpoint.GetRequisitions(5, 0, CancellationToken.None);

        Assert.Multiple(() =>
        {
            Assert.That(apiClient.JsonWebTokenPair, Is.Not.Null);
            Assert.That(apiClient.JsonWebTokenPair!.AccessToken.EncodedToken, Has.Length.GreaterThan(0));
            Assert.That(apiClient.JsonWebTokenPair!.RefreshToken.EncodedToken, Has.Length.GreaterThan(0));
        });
    }

    /// <summary>
    /// Tests whether the <see cref="NordigenClient.TokenPairUpdated"/> event is raised when the token pair is updated
    /// automatically by the client itself. 
    /// </summary>
    [Test]
    public async Task TokenPairUpdateIsRaisedOnInternalUpdate()
    {
        var apiClient = TestHelpers.GetMockClient(null, HttpStatusCode.OK);
        TokenPairUpdatedEventArgs? eventArgs = null;

        apiClient.TokenPairUpdated += (_, e) => eventArgs = e;

        await apiClient.AccountsEndpoint.GetAccount(TestHelpers.Secrets.ValidAccountId);

        Assert.Multiple(() =>
        {
            Assert.That(eventArgs, Is.Not.Null);
            Assert.That(eventArgs!.JsonWebTokenPair, Is.Not.Null);
            Assert.That(eventArgs.JsonWebTokenPair.AccessToken.EncodedToken, Is.Not.Empty);
            Assert.That(eventArgs.JsonWebTokenPair.RefreshToken.EncodedToken, Is.Not.Empty);
        });
    }

    /// <summary>
    /// Tests whether the <see cref="NordigenClient.TokenPairUpdated"/> event is raised when the token pair is updated
    /// by the user. 
    /// </summary>
    [Test]
    public void TokenPairUpdateIsRaisedOnManualUpdate()
    {
        var apiClient = TestHelpers.GetMockClient(null, HttpStatusCode.OK);
        TokenPairUpdatedEventArgs? eventArgs = null;

        apiClient.TokenPairUpdated += (_, e) => eventArgs = e;

        apiClient.JsonWebTokenPair = new JsonWebTokenPair(TestHelpers.Secrets.ExpiredJwtAccessToken,
            TestHelpers.Secrets.ValidJwtRefreshToken);

        Assert.Multiple(() =>
        {
            Assert.That(eventArgs, Is.Not.Null);
            Assert.That(eventArgs!.JsonWebTokenPair, Is.Not.Null);
            Assert.That(eventArgs.JsonWebTokenPair.AccessToken.EncodedToken, Is.Not.Empty);
            Assert.That(eventArgs.JsonWebTokenPair.RefreshToken.EncodedToken, Is.Not.Empty);
        });
    }

    #endregion

    #region RequestsWithErrors

    /// <summary>
    /// Tests the failure of authentication when trying to execute a request.
    /// </summary>
    [Test]
    public async Task ExecuteRequestWithInvalidCredentials()
    {
        var apiClient = TestHelpers.GetMockClient(
            TestHelpers.MockData.CredentialMockData.NoAccountForGivenCredentialsError,
            HttpStatusCode.Unauthorized, false);

        var tokenPairResponse = await apiClient.TokenEndpoint.GetTokenPair();

        Assert.Multiple(() =>
        {
            AssertionHelpers.AssertNordigenApiResponseIsUnsuccessful(tokenPairResponse, HttpStatusCode.Unauthorized);
            AssertionHelpers.AssertBasicResponseMatchesExpectations(tokenPairResponse.Error, "Authentication failed",
                "No active account found with the given credentials");
        });
    }

    /// <summary>
    /// Tries to execute a request using credentials that haven't whitelisted the used IP. This should cause an error.
    /// </summary>
    [Test]
    public async Task ExecuteRequestWithUnauthorizedIp()
    {
        var apiClient = TestHelpers.GetMockClient(
            TestHelpers.MockData.CredentialMockData.IpNotWhitelistedError,
            HttpStatusCode.Forbidden);

        var response = await apiClient.RequisitionsEndpoint.GetRequisitions(5, 0, CancellationToken.None);

        Assert.Multiple(() =>
        {
            AssertionHelpers.AssertNordigenApiResponseIsUnsuccessful(response, HttpStatusCode.Forbidden);
            AssertionHelpers.AssertBasicResponseMatchesExpectations(response.Error, "IP address access denied",
                "Your IP 127.0.0.1 isn't whitelisted to perform this action");
        });
    }

    #endregion
}

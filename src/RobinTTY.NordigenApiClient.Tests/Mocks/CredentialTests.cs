using RobinTTY.NordigenApiClient.Tests.Shared;

namespace RobinTTY.NordigenApiClient.Tests.Mocks;

public class CredentialTests
{
    /// <summary>
    /// Tests the failure of authentication when trying to execute a request using mocks.
    /// </summary>
    [Test]
    public async Task GetTokenPairWithInvalidCredentials()
    {
        var apiClient = TestHelpers.GetMockClient(
            TestHelpers.MockData.TokenEndpointMockData.NoAccountForGivenCredentialsError,
            HttpStatusCode.Unauthorized, addDefaultAuthToken: false);

        var tokenPairResponse = await apiClient.TokenEndpoint.GetTokenPair();

        Assert.Multiple(() =>
        {
            AssertionHelpers.AssertNordigenApiResponseIsUnsuccessful(tokenPairResponse, HttpStatusCode.Unauthorized);
            AssertionHelpers.AssertBasicResponseMatchesExpectations(tokenPairResponse.Error, "Authentication failed",
                "No active account found with the given credentials");
        });
    }
    
    /// <summary>
    /// Tests that <see cref="NordigenClient.JsonWebTokenPair" /> is populated after the first authenticated request is made.
    /// </summary>
    [Test]
    public async Task CheckValidTokensAfterRequest()
    {
        var apiClient = TestHelpers.GetMockClient(TestHelpers.MockData.RequisitionsEndpointMockData.GetRequisitions, HttpStatusCode.OK);
        Assert.That(apiClient.JsonWebTokenPair, Is.Null);
        
        await apiClient.RequisitionsEndpoint.GetRequisitions(5, 0, CancellationToken.None);
        
        Assert.Multiple(() =>
        {
            Assert.That(apiClient.JsonWebTokenPair, Is.Not.Null);
            Assert.That(apiClient.JsonWebTokenPair!.AccessToken.EncodedToken, Has.Length.GreaterThan(0));
            Assert.That(apiClient.JsonWebTokenPair!.RefreshToken.EncodedToken, Has.Length.GreaterThan(0));
        });
    }
}

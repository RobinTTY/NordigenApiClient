using FakeItEasy;
using Microsoft.IdentityModel.JsonWebTokens;
using RobinTTY.NordigenApiClient.Tests.Shared;
using RobinTTY.NordigenApiClient.Utility;

namespace RobinTTY.NordigenApiClient.Tests.Mocks.Endpoints;

public class TokenEndpointTests
{
    /// <summary>
    /// Tests the retrieving of a new token.
    /// </summary>
    [Test]
    public async Task GetNewToken()
    {
        var apiClient = TestHelpers.GetMockClient(TestHelpers.MockData.TokenEndpointMockData.GetNewToken,
            HttpStatusCode.OK, addDefaultAuthToken: false);

        var tokenPair = await apiClient.TokenEndpoint.GetTokenPair();
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(tokenPair, HttpStatusCode.OK);

        Assert.Multiple(() =>
        {
            Assert.That(tokenPair.Result!.AccessExpires, Is.EqualTo(86_400));
            Assert.That(tokenPair.Result!.AccessToken.IsExpired(), Is.False);
            Assert.That(tokenPair.Result!.AccessToken.EncodedToken,
                Is.EqualTo(
                    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ0b2tlbl90eXBlIjoiYWNjZXNzIiwic3ViIjoiMTIzNDU2Nzg5MCIsIm5hbWUiOiJKb2huIERvZSIsImlhdCI6MTUxNjIzOTAyMiwiZXhwIjozMzI3MDExNzU5NH0.gEa5VdPSqZW2xk9IqCEqiw6bzBOer_uAR1yp2XK7FFo"));

            Assert.That(tokenPair.Result!.RefreshExpires, Is.EqualTo(2_592_000));
            Assert.That(tokenPair.Result!.RefreshToken.IsExpired(), Is.False);
            Assert.That(tokenPair.Result!.RefreshToken.EncodedToken,
                Is.EqualTo(
                    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ0b2tlbl90eXBlIjoicmVmcmVzaCIsInN1YiI6IjEyMzQ1Njc4OTAiLCJuYW1lIjoiSm9obiBEb2UiLCJpYXQiOjE1MTYyMzkwMjIsImV4cCI6MzMyNzAxMTc1OTR9.xfOrczY3KvG-SiHLZkVLPas017ZX8DHkcCN78Xd9cac"));
        });
    }

    /// <summary>
    /// Tests the retrieving of a new token.
    /// </summary>
    [Test]
    public async Task RefreshAccessToken()
    {
        var apiClient = TestHelpers.GetMockClient(TestHelpers.MockData.TokenEndpointMockData.RefreshAccessToken,
            HttpStatusCode.OK, addDefaultAuthToken: false);

        var tokenPair = await apiClient.TokenEndpoint.RefreshAccessToken(A.Fake<JsonWebToken>(options =>
        {
            options.WithArgumentsForConstructor(new object[]
            {
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ0b2tlbl90eXBlIjoicmVmcmVzaCIsInN1YiI6IjEyMzQ1Njc4OTAiLCJuYW1lIjoiSm9obiBEb2UiLCJpYXQiOjE1MTYyMzkwMjIsImV4cCI6MzMyNzAxMTc1OTR9.xfOrczY3KvG-SiHLZkVLPas017ZX8DHkcCN78Xd9cac"
            });
        }));
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(tokenPair, HttpStatusCode.OK);

        Assert.Multiple(() =>
        {
            Assert.That(tokenPair.Result!.AccessExpires, Is.EqualTo(86_400));
            Assert.That(tokenPair.Result!.AccessToken.IsExpired(), Is.False);
            Assert.That(tokenPair.Result!.AccessToken.EncodedToken,
                Is.EqualTo(
                    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ0b2tlbl90eXBlIjoiYWNjZXNzIiwic3ViIjoiMTIzNDU2Nzg5MCIsIm5hbWUiOiJKb2huIERvZSIsImlhdCI6MTUxNjIzOTAyMiwiZXhwIjozMzI3MDExNzU5NH0.gEa5VdPSqZW2xk9IqCEqiw6bzBOer_uAR1yp2XK7FFo"));
        });
    }
}

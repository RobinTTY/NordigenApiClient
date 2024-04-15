using System.Net;
using RobinTTY.NordigenApiClient.Tests.Shared;

namespace RobinTTY.NordigenApiClient.Tests.LiveApi;

public class NordigenApiClientTests
{
    /// <summary>
    /// Executes a request to the Nordigen API using the default base address.
    /// </summary>
    [Test]
    public async Task ExecuteRequestWithDefaultBaseAddress()
    {
        var apiClient = TestHelpers.GetConfiguredClient();
        await ExecuteExampleRequest(apiClient);
    }
    
    /// <summary>
    /// Executes a request to the Nordigen API using a custom base address.
    /// </summary>
    [Test]
    public async Task ExecuteRequestWithCustomBaseAddress()
    {
        var apiClient = TestHelpers.GetConfiguredClient("https://ob.gocardless.com/api/v2/");
        await ExecuteExampleRequest(apiClient);
    }
    
    private async Task ExecuteExampleRequest(NordigenClient apiClient)
    {
        var response = await apiClient.TokenEndpoint.GetTokenPair();
        TestHelpers.AssertNordigenApiResponseIsSuccessful(response, HttpStatusCode.OK);
        var response2 = await apiClient.TokenEndpoint.RefreshAccessToken(response.Result!.RefreshToken);
        TestHelpers.AssertNordigenApiResponseIsSuccessful(response2, HttpStatusCode.OK);
    }
}
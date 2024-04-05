using System.Net;

namespace RobinTTY.NordigenApiClient.Tests.LiveApi;

public class NordigenApiClientTests
{
    /// <summary>
    /// Executes a request to the Nordigen API using the default base address.
    /// </summary>
    [Test]
    public async Task ExecuteRequestWithDefaultBaseAddress()
    {
        var apiClient = TestExtensions.GetConfiguredClient();
        await ExecuteExampleRequest(apiClient);
    }
    
    /// <summary>
    /// Executes a request to the Nordigen API using a custom base address.
    /// </summary>
    [Test]
    public async Task ExecuteRequestWithCustomBaseAddress()
    {
        var apiClient = TestExtensions.GetConfiguredClient("https://ob.gocardless.com/api/v2/");
        await ExecuteExampleRequest(apiClient);
    }
    
    private async Task ExecuteExampleRequest(NordigenClient apiClient)
    {
        var response = await apiClient.TokenEndpoint.GetTokenPair();
        TestExtensions.AssertNordigenApiResponseIsSuccessful(response, HttpStatusCode.OK);
        var response2 = await apiClient.TokenEndpoint.RefreshAccessToken(response.Result!.RefreshToken);
        TestExtensions.AssertNordigenApiResponseIsSuccessful(response2, HttpStatusCode.OK);
    }
}
using System.Collections.Concurrent;
using RobinTTY.NordigenApiClient.Models.Responses;
using RobinTTY.NordigenApiClient.Tests.Shared;

namespace RobinTTY.NordigenApiClient.Tests.LiveApi;

public class NordigenApiClientTests
{
    #region RequestsWithErrors

    [Test]
    [Ignore("Test executes a lot of requests using the LiveAPI.")]
    public async Task ExecuteRequestsUntilRateLimitReached()
    {
        var apiClient = TestHelpers.GetConfiguredClient();
        NordigenApiResponse<List<Institution>, BasicResponse>? unsuccessfulRequest = null;

        while (unsuccessfulRequest is null)
        {
            var tasks = new ConcurrentBag<Task<NordigenApiResponse<List<Institution>, BasicResponse>>>();
            Parallel.For(0, 10, _ =>
            {
                var task = apiClient.InstitutionsEndpoint.GetInstitutions("LI");
                tasks.Add(task);
            });

            var results = await Task.WhenAll(tasks);
            unsuccessfulRequest = results.FirstOrDefault(result => !result.IsSuccess);
        }

#if NET6_0_OR_GREATER
        AssertionHelpers.AssertNordigenApiResponseIsUnsuccessful(unsuccessfulRequest, HttpStatusCode.TooManyRequests);
#else
        AssertionHelpers.AssertNordigenApiResponseIsUnsuccessful(unsuccessfulRequest, (HttpStatusCode) 429);
#endif
        Assert.That(unsuccessfulRequest.Error!.Summary, Is.EqualTo("Rate limit exceeded"));
        Assert.That(unsuccessfulRequest.Error!.Detail,
            Does.Match("The rate limit for this resource is [0-9]*\\/\\w*\\. Please try again in [0-9]* \\w*"));
    }

    #endregion

    #region RequestsWithSuccessfulResponse

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
    [Ignore("Alternative URL no longer valid.")]
    public async Task ExecuteRequestWithCustomBaseAddress()
    {
        var apiClient = TestHelpers.GetConfiguredClient("https://ob.gocardless.com/api/v2/");
        await ExecuteExampleRequest(apiClient);
    }

    private async Task ExecuteExampleRequest(NordigenClient apiClient)
    {
        var response = await apiClient.TokenEndpoint.GetTokenPair();
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(response, HttpStatusCode.OK);
        var response2 = await apiClient.TokenEndpoint.RefreshAccessToken(response.Result!.RefreshToken);
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(response2, HttpStatusCode.OK);
    }

    #endregion
}
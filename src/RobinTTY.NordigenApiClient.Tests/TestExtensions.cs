using System.Net;
using RobinTTY.NordigenApiClient.Models;
using RobinTTY.NordigenApiClient.Models.Jwt;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Tests;

internal static class TestExtensions
{
    internal static void AssertNordigenApiResponseIsSuccessful<TResponse, TError>(NordigenApiResponse<TResponse, TError> response, HttpStatusCode statusCode)
        where TResponse : class where TError : class
    {
        Assert.Multiple(() =>
        {
            Assert.That(response.IsSuccess, Is.True);
            Assert.That(response.Result, Is.Not.Null);
            Assert.That(response.Error, Is.Null);
            Assert.That(response.StatusCode, Is.EqualTo(statusCode));
        });
    }

    internal static void AssertNordigenApiResponseIsUnsuccessful<TResponse, TError>(NordigenApiResponse<TResponse, TError> response, HttpStatusCode statusCode)
        where TResponse : class where TError : class
    {
        Assert.Multiple(() =>
        {
            Assert.That(response.IsSuccess, Is.False);
            Assert.That(response.Result, Is.Null);
            Assert.That(response.Error, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(statusCode));
        });
    }

    internal static NordigenClient GetConfiguredClient(bool useExistingJwt = true)
    {
        var httpClient = new HttpClient();
        var secrets = File.ReadAllLines("secrets.txt");
        var credentials = new NordigenClientCredentials(secrets[0], secrets[1]);
        var tokenPair = new JsonWebTokenPair(secrets[3], secrets[4]);
        return useExistingJwt ? new NordigenClient(httpClient, credentials, tokenPair) : new NordigenClient(httpClient, credentials);
    }
}

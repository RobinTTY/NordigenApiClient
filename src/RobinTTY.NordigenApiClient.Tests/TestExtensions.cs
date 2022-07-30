using System.Net;
using RobinTTY.NordigenApiClient.Models;

namespace RobinTTY.NordigenApiClient.Tests;

internal static class TestExtensions
{
    internal static void AssertNordigenApiResponseIsSuccessful<T>(NordigenApiResponse<T> response) where T : class
    {
        Assert.Multiple(() =>
        {
            Assert.That(response.IsSuccess, Is.True);
            Assert.That(response.Result, Is.Not.Null);
            Assert.That(response.Error, Is.Null);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        });
    }
}

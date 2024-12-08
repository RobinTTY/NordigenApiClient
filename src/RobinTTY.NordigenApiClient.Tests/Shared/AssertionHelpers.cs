using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Tests.Shared;

public static class AssertionHelpers
{
    internal static void AssertNordigenApiResponseIsSuccessful<TResponse, TError>(
        NordigenApiResponse<TResponse, TError> response, HttpStatusCode statusCode)
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

    internal static void AssertNordigenApiResponseIsUnsuccessful<TResponse, TError>(
        NordigenApiResponse<TResponse, TError> response, HttpStatusCode statusCode)
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

    internal static void AssertThatAgreementPageContainsAgreement(
        NordigenApiResponse<ResponsePage<Agreement>, BasicResponse> pagedResponse, List<string> ids)
    {
        AssertNordigenApiResponseIsSuccessful(pagedResponse, HttpStatusCode.OK);
        var page2Result = pagedResponse.Result!;
        var page2Agreements = page2Result.Results.ToList();
        Assert.Multiple(() =>
        {
            Assert.That(page2Agreements, Has.Count.EqualTo(1));
            Assert.That(ids, Does.Contain(page2Agreements.First().Id.ToString()));
        });
    }

    internal static void AssertBasicResponseMatchesExpectations(BasicResponse? response, string summary, string detail)
    {
        Assert.Multiple(() =>
        {
            Assert.That(response?.Summary, Is.EqualTo(summary));
            Assert.That(response?.Detail, Is.EqualTo(detail));
        });
    }
}
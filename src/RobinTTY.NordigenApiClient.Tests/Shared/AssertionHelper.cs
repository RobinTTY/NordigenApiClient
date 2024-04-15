using System.Net;
using RobinTTY.NordigenApiClient.Models.Errors;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Tests.Shared;

public class AssertionHelper
{
    internal static void AssertThatAgreementPageContainsAgreement(
        NordigenApiResponse<ResponsePage<Agreement>, BasicError> pagedResponse, List<string> ids)
    {
        TestHelpers.AssertNordigenApiResponseIsSuccessful(pagedResponse, HttpStatusCode.OK);
        var page2Result = pagedResponse.Result!;
        var page2Agreements = page2Result.Results.ToList();
        Assert.Multiple(() =>
        {
            Assert.That(page2Agreements, Has.Count.EqualTo(1));
            Assert.That(ids, Does.Contain(page2Agreements.First().Id.ToString()));
        });
    }
}

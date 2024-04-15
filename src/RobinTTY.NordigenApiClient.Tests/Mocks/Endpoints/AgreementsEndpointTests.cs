﻿using System.Net;
using System.Text.Json;
using FakeItEasy;
using RobinTTY.NordigenApiClient.Models.Requests;
using RobinTTY.NordigenApiClient.Tests.Shared;

namespace RobinTTY.NordigenApiClient.Tests.Mocks.Endpoints;

public class AgreementsEndpointTests
{
    private readonly JsonSerializerOptions _jsonOptions = TestHelpers.GetSerializerOptions();

    /// <summary>
    /// Tests the retrieval of end user agreements.
    /// </summary>
    [Test]
    public async Task GetAgreements()
    {
        var responsePayload =
            JsonSerializer.Serialize(TestHelpers.GetMockData().AgreementsEndpointMockData.GetAgreements,
                _jsonOptions);
        var response = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(responsePayload)
        };
        var apiClient = TestHelpers.GetMockClient([response]);

        var agreements = await apiClient.AgreementsEndpoint.GetAgreements(100, 0);
        TestHelpers.AssertNordigenApiResponseIsSuccessful(agreements, HttpStatusCode.OK);

        var responseAgreement = agreements.Result!.Results.First();
        Assert.Multiple(() =>
        {
            Assert.That(agreements.Result!.Count, Is.EqualTo(1));
            Assert.That(agreements.Result!.Next,
                Is.EqualTo(new Uri(
                    "https://bankaccountdata.gocardless.com/api/v2/agreements/enduser/?limit=100&offset=0")));
            Assert.That(agreements.Result!.Previous,
                Is.EqualTo(new Uri(
                    "https://bankaccountdata.gocardless.com/api/v2/agreements/enduser/?limit=100&offset=0")));
            Assert.That(agreements.Result!.Results.Count(), Is.EqualTo(1));

            Assert.That(responseAgreement.Id, Is.EqualTo(new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")));
            Assert.That(responseAgreement.Created.ToUniversalTime(),
                Is.EqualTo(DateTime.Parse("2024-04-08T20:57:00.550Z").ToUniversalTime()));
            Assert.That(((DateTime) responseAgreement.Accepted!).ToUniversalTime(),
                Is.EqualTo(DateTime.Parse("2024-04-08T20:57:00.550Z").ToUniversalTime()));
            Assert.That(responseAgreement.InstitutionId, Is.EqualTo("SANDBOXFINANCE_SFIN0000"));
            Assert.That(responseAgreement.MaxHistoricalDays, Is.EqualTo(90));
            Assert.That(responseAgreement.AccessValidForDays, Is.EqualTo(90));
            Assert.That(responseAgreement.AccessScope, Has.Count.EqualTo(3));

            var expectedAccessScopes = new[] {"balances", "details", "transactions"};
            Assert.That(responseAgreement.AccessScope, Is.EqualTo(expectedAccessScopes));
        });
    }

    /// <summary>
    /// Tests the retrieval of an end user agreement by id.
    /// </summary>
    [Test]
    public async Task GetAgreement()
    {
        var responsePayload =
            JsonSerializer.Serialize(TestHelpers.GetMockData().AgreementsEndpointMockData.GetAgreement,
                _jsonOptions);
        var response = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(responsePayload)
        };
        var apiClient = TestHelpers.GetMockClient([response]);

        var agreement = await apiClient.AgreementsEndpoint.GetAgreement(A.Dummy<Guid>());
        TestHelpers.AssertNordigenApiResponseIsSuccessful(agreement, HttpStatusCode.OK);

        Assert.Multiple(() =>
        {
            Assert.That(agreement.Result!.Id, Is.EqualTo(new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")));
            Assert.That(agreement.Result!.InstitutionId, Is.EqualTo("SANDBOXFINANCE_SFIN0000"));
            Assert.That(agreement.Result!.MaxHistoricalDays, Is.EqualTo(90));
            Assert.That(agreement.Result!.AccessValidForDays, Is.EqualTo(90));
            Assert.That(agreement.Result!.Created.ToUniversalTime(),
                Is.EqualTo(DateTime.Parse("2024-04-08T22:54:54.869Z").ToUniversalTime()));
            Assert.That(((DateTime) agreement.Result!.Accepted!).ToUniversalTime(),
                Is.EqualTo(DateTime.Parse("2024-04-08T22:54:54.869Z").ToUniversalTime()));
            var expectedAccessScopes = new[] {"balances", "details", "transactions"};
            Assert.That(agreement.Result!.AccessScope, Is.EqualTo(expectedAccessScopes));
        });
    }

    /// <summary>
    /// Tests the creation of end user agreements.
    /// </summary>
    [Test]
    public async Task CreateAgreement()
    {
        var responsePayload =
            JsonSerializer.Serialize(TestHelpers.GetMockData().AgreementsEndpointMockData.CreateAgreement,
                _jsonOptions);
        var response = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.Created,
            Content = new StringContent(responsePayload)
        };
        var apiClient = TestHelpers.GetMockClient([response]);

        var agreementRequest = new CreateAgreementRequest(145, 145,
            ["balances", "details", "transactions"], "SANDBOXFINANCE_SFIN0000");
        var createResponse = await apiClient.AgreementsEndpoint.CreateAgreement(agreementRequest);
        TestHelpers.AssertNordigenApiResponseIsSuccessful(createResponse, HttpStatusCode.Created);

        Assert.Multiple(() =>
        {
            Assert.That(createResponse.Result!.Id, Is.EqualTo(new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7")));
            Assert.That(createResponse.Result!.InstitutionId, Is.EqualTo("SANDBOXFINANCE_SFIN0000"));
            Assert.That(createResponse.Result!.MaxHistoricalDays, Is.EqualTo(145));
            Assert.That(createResponse.Result!.AccessValidForDays, Is.EqualTo(145));

            var expectedAccessScopes = new[] {"balances", "details", "transactions"};
            Assert.That(createResponse.Result!.AccessScope, Is.EqualTo(expectedAccessScopes));
        });
    }

    /// <summary>
    /// Tests the creation of end user agreements.
    /// </summary>
    [Test]
    public async Task DeleteAgreement()
    {
        var responsePayload =
            JsonSerializer.Serialize(TestHelpers.GetMockData().AgreementsEndpointMockData.DeleteAgreement,
                _jsonOptions);
        var response = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(responsePayload)
        };
        var apiClient = TestHelpers.GetMockClient([response]);
        
        var result = await apiClient.AgreementsEndpoint.DeleteAgreement(A.Dummy<Guid>());
        TestHelpers.AssertNordigenApiResponseIsSuccessful(result, HttpStatusCode.OK);
        Assert.Multiple(() =>
        {
            Assert.That(result.Result?.Summary, Is.EqualTo("End User Agreement deleted"));
            Assert.That(result.Result?.Detail, Is.EqualTo("End User Agreement bb37bc52-5b1d-44f9-b1cd-ec9594f25387 deleted"));
        });
    }
}
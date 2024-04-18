using System.Net;
using System.Text.Json;
using FakeItEasy;
using RobinTTY.NordigenApiClient.Endpoints;
using RobinTTY.NordigenApiClient.JsonConverters;
using RobinTTY.NordigenApiClient.Models;
using RobinTTY.NordigenApiClient.Tests.Mocks;
using RobinTTY.NordigenApiClient.Tests.Mocks.Responses;

namespace RobinTTY.NordigenApiClient.Tests.Shared;

internal static class TestHelpers
{
    private static readonly string[] Secrets = File.ReadAllLines("secrets.txt");
    public static MockResponsesModel MockData { get; }

    static TestHelpers()
    {
        var json = File.ReadAllText("Mocks/Responses/responses.json");
        var jsonOptions = new JsonSerializerOptions
        {
            Converters =
            {
                new JsonWebTokenConverter(), new GuidConverter(),
                new CultureSpecificDecimalConverter(), new InstitutionsErrorConverter()
            }
        };
        MockData = JsonSerializer.Deserialize<MockResponsesModel>(json, jsonOptions) ??
                   throw new InvalidOperationException("Could not deserialize mock Data");
    }

    internal static NordigenClient GetConfiguredClient(string? baseAddress = null)
    {
        var address = baseAddress ?? NordigenEndpointUrls.Base;
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(address);
        var credentials = new NordigenClientCredentials(Secrets[0], Secrets[1]);
        return new NordigenClient(httpClient, credentials);
    }

    internal static NordigenClient GetMockClient(List<HttpResponseMessage> responseMessages,
        bool addDefaultAuthToken = true)
    {
        var fakeHttpMessageHandler = A.Fake<FakeHttpMessageHandler>();
        var token = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(
                $"{{\n  \"access\": \"{Secrets[4]}\",\n  \"access_expires\": 86400,\n" +
                $" \"refresh\": \"{Secrets[5]}\",\n  \"refresh_expires\": 2592000\n}}")
        };
        var responses = new List<HttpResponseMessage>();
        responses.AddRange(addDefaultAuthToken ? [token, ..responseMessages] : responseMessages);

        A.CallTo(() =>
                fakeHttpMessageHandler.FakeSendAsync(A<HttpRequestMessage>.Ignored, A<CancellationToken>.Ignored))
            .ReturnsNextFromSequence(responses.ToArray());

        var mockHttpClient = new HttpClient(fakeHttpMessageHandler);
        var credentials = new NordigenClientCredentials(Secrets[0], Secrets[1]);
        return new(mockHttpClient, credentials);
    }

    internal static JsonSerializerOptions GetSerializerOptions() => new()
    {
        Converters =
        {
            new JsonWebTokenConverter(), new GuidConverter(),
            new CultureSpecificDecimalConverter(), new InstitutionsErrorConverter()
        }
    };
}

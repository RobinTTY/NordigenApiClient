using System.Text.Json;
using FakeItEasy;
using Microsoft.Extensions.Configuration;
using RobinTTY.NordigenApiClient.Endpoints;
using RobinTTY.NordigenApiClient.JsonConverters;
using RobinTTY.NordigenApiClient.Models;
using RobinTTY.NordigenApiClient.Tests.Mocks;
using RobinTTY.NordigenApiClient.Tests.Mocks.Responses;

namespace RobinTTY.NordigenApiClient.Tests.Shared;

internal static class TestHelpers
{
    private static readonly JsonSerializerOptions JsonSerializerOptions;
    public static TestSecrets Secrets { get; }
    public static MockResponsesModel MockData { get; }

    static TestHelpers()
    {
        var json = File.ReadAllText("Mocks/Responses/responses.json");
        JsonSerializerOptions = new JsonSerializerOptions
        {
            Converters =
            {
                new JsonWebTokenConverter(), new GuidConverter(),
                new CultureSpecificDecimalConverter()
            }
        };
        MockData = JsonSerializer.Deserialize<MockResponsesModel>(json, JsonSerializerOptions) ??
                   throw new InvalidOperationException("Could not deserialize mock Data");
        Secrets = GetSecrets() ?? throw new InvalidOperationException("Could not get secrets");
    }

    internal static NordigenClient GetConfiguredClient(string? baseAddress = null)
    {
        var address = baseAddress ?? NordigenEndpointUrls.Base;
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(address);
        var credentials = new NordigenClientCredentials(Secrets.ValidSecretId, Secrets.ValidSecretKey);
        return new NordigenClient(httpClient, credentials);
    }

    internal static NordigenClient GetMockClient(object? value, HttpStatusCode statusCode,
        bool addDefaultAuthToken = true) => GetMockClient([new ValueTuple<object?, HttpStatusCode>(value, statusCode)],
        addDefaultAuthToken);

    private static NordigenClient GetMockClient(List<(object? Value, HttpStatusCode StatusCode)> responses,
        bool addDefaultAuthToken = true)
    {
        var fakeHttpMessageHandler = A.Fake<FakeHttpMessageHandler>();
        var httpResponseMessages = new List<HttpResponseMessage>();
        var token = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(
                $"{{\n  \"access\": \"{Secrets.ExpiredJwtAccessToken}\",\n  \"access_expires\": 86400,\n" +
                $" \"refresh\": \"{Secrets.ValidJwtRefreshToken}\",\n  \"refresh_expires\": 2592000\n}}")
        };

        if (addDefaultAuthToken)
            httpResponseMessages.Add(token);

        responses.ForEach(response =>
        {
            var responsePayload = JsonSerializer.Serialize(response.Value, JsonSerializerOptions);
            httpResponseMessages.Add(
                new HttpResponseMessage
                {
                    StatusCode = response.StatusCode,
                    Content = new StringContent(responsePayload)
                }
            );
        });

        A.CallTo(() =>
                fakeHttpMessageHandler.FakeSendAsync(A<HttpRequestMessage>.Ignored, A<CancellationToken>.Ignored))
            .ReturnsNextFromSequence(httpResponseMessages.ToArray());

        var mockHttpClient = new HttpClient(fakeHttpMessageHandler);
        var credentials = new NordigenClientCredentials(Secrets.ValidSecretId, Secrets.ValidSecretKey);
        return new NordigenClient(mockHttpClient, credentials);
    }
    
    private static TestSecrets? GetSecrets() =>
        new ConfigurationBuilder()
            .AddJsonFile("appsettings.test.json")
            .AddUserSecrets<TestSecrets>()
            .Build().Get<TestSecrets>();
}

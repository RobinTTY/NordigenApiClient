namespace RobinTTY.NordigenApiClient.Tests.Mocks;

public abstract class FakeHttpMessageHandler : HttpMessageHandler
{
    public abstract Task<HttpResponseMessage> FakeSendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken);

    // sealed so FakeItEasy won't intercept calls to this method
    protected sealed override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken) =>
        FakeSendAsync(request, cancellationToken);
}
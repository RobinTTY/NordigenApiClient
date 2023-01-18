using RobinTTY.NordigenApiClient.Models.Jwt;

namespace RobinTTY.NordigenApiClient.Tests;

internal class JsonWebTokenPairTests
{
    private NordigenClient _apiClient = null!;

    [OneTimeSetUp]
    public void Setup()
    {
        _apiClient = TestExtensions.GetConfiguredClient(false);
    }

    /// <summary>
    /// Tests that <see cref="JsonWebTokenPair"/> can be instantiated with valid JWT tokens.
    /// </summary>
    [Test]
    public void CreateValidJsonWebTokenPair()
    {
        const string exampleToken1 = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ0eXBlIjoiYWNjZXNzIiwic3ViIjoiMTIzNDU2Nzg5MCIsIm5iZiI6MTY1OTE5OTU5MiwiZXhwIjoxNjU5MjE5NTkyLCJuYW1lIjoiSm9obiBEb2UiLCJpYXQiOjE1MTYyMzkwMjJ9.WP7xByegwjRvWZMwHScxunAOkwkW77ocaLvGenI2PAU";
        const string exampleToken2 = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ0eXBlIjoicmVmcmVzaCIsInN1YiI6IjEyMzQ1Njc4OTAiLCJuYmYiOjE2NTkxOTk1OTIsImV4cCI6MTY1OTI5OTU5MiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.uB2pb0g5uf3glMZTi9ycNjNTbcpeLaQnyT9H-z15lqg";
        var token = new JsonWebTokenPair(exampleToken1, exampleToken2);

        Assert.That(token, Is.Not.Null);
        Assert.That(token.AccessToken.Alg, Is.EqualTo("HS256"));
        Assert.That(token.AccessToken.Subject, Is.EqualTo("1234567890"));
        Assert.That(token.AccessToken.GetPayloadValue<string>("name"), Is.EqualTo("John Doe"));
        Assert.That(token.RefreshToken.GetPayloadValue<string>("type"), Is.EqualTo("refresh"));
    }

    /// <summary>
    /// Tests that <see cref="JsonWebTokenPair"/> can't be instantiated with invalid JWT tokens.
    /// </summary>
    [Test]
    public void CreateInvalidJsonWebTokenPair()
    {
        var exampleToken = "eyJhbGciOiJIUzI1NisInR5cCI6IkpXVCJ9.eyJ0eXBlIjoiYWNjZXNzIiwic3ViIjoiMTIzNDU2Nzg5MCIsIm5iZiI6MTY1OTE5OTU5MiwiZXhwIjoxNjU5MjE5NTkyLCJuYWIjoiSm9obiBEb2UiLCJpYXQiOjE1MTYyMzkwMjJ9.WP7xByegwjRvWZMwHScxunAOkwkW77ocaLvGen2PAU";
        // ReSharper disable once ObjectCreationAsStatement
        Assert.Throws<ArgumentException>(() => new JsonWebTokenPair(exampleToken, exampleToken));
    }

    /// <summary>
    /// Tests that <see cref="NordigenClient.JsonWebTokenPair"/> is populated after the first authenticated request is made.
    /// </summary>
    [Test]
    public async Task CheckValidTokensAfterRequest()
    {
        Assert.That(_apiClient.JsonWebTokenPair, Is.Null);
        await _apiClient.RequisitionsEndpoint.GetRequisitions(5, 0, CancellationToken.None);
        Assert.That(_apiClient.JsonWebTokenPair, Is.Not.Null);
        Assert.That(_apiClient.JsonWebTokenPair!.AccessToken.EncodedToken.Length, Is.GreaterThan(0));
        Assert.That(_apiClient.JsonWebTokenPair!.RefreshToken.EncodedToken.Length, Is.GreaterThan(0));
    }
}

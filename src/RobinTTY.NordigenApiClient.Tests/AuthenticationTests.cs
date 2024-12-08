using Microsoft.IdentityModel.JsonWebTokens;
using RobinTTY.NordigenApiClient.Models;
using RobinTTY.NordigenApiClient.Models.Jwt;
using RobinTTY.NordigenApiClient.Utility;

namespace RobinTTY.NordigenApiClient.Tests;

/// <summary>
/// Tests aspects of authentication related to the <see cref="NordigenClientCredentials" /> and
/// <see cref="JsonWebTokenPair" /> classes.
/// </summary>
internal class AuthenticationTests
{
    /// <summary>
    /// Tests creating <see cref="NordigenClientCredentials" />, passing null as an argument.
    /// </summary>
    [Test]
    public void CreateCredentialsWithNull()
    {
        Assert.Throws<ArgumentNullException>(() => { _ = new NordigenClientCredentials(null!, null!); });
    }

    /// <summary>
    /// Tests that <see cref="JsonWebTokenPair" /> can be instantiated with valid JWT tokens.
    /// </summary>
    [Test]
    public void CreateValidJsonWebTokenPair()
    {
        const string exampleToken1 =
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ0eXBlIjoiYWNjZXNzIiwic3ViIjoiMTIzNDU2Nzg5MCIsIm5iZiI6MTY1OTE5OTU5MiwiZXhwIjoxNjU5MjE5NTkyLCJuYW1lIjoiSm9obiBEb2UiLCJpYXQiOjE1MTYyMzkwMjJ9.WP7xByegwjRvWZMwHScxunAOkwkW77ocaLvGenI2PAU";
        const string exampleToken2 =
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ0eXBlIjoicmVmcmVzaCIsInN1YiI6IjEyMzQ1Njc4OTAiLCJuYmYiOjE2NTkxOTk1OTIsImV4cCI6MTY1OTI5OTU5MiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.uB2pb0g5uf3glMZTi9ycNjNTbcpeLaQnyT9H-z15lqg";
        var token = new JsonWebTokenPair(exampleToken1, exampleToken2);

        Assert.Multiple(() =>
        {
            Assert.That(token, Is.Not.Null);
            Assert.That(token.AccessToken.Alg, Is.EqualTo("HS256"));
            Assert.That(token.AccessToken.Subject, Is.EqualTo("1234567890"));
            Assert.That(token.AccessToken.GetPayloadValue<string>("name"), Is.EqualTo("John Doe"));
            Assert.That(token.RefreshToken.GetPayloadValue<string>("type"), Is.EqualTo("refresh"));
        });
    }

    /// <summary>
    /// Tests that <see cref="JsonWebTokenPair" /> can't be instantiated with invalid JWT tokens.
    /// </summary>
    [Test]
    public void CreateInvalidJsonWebTokenPair()
    {
        const string exampleToken =
            "eyJhbGciOiJIUzI1NisInR5cCI6IkpXVCJ9.eyJ0eXBlIjoiYWNjZXNzIiwic3ViIjoiMTIzNDU2Nzg5MCIsIm5iZiI6MTY1OTE5OTU5MiwiZXhwIjoxNjU5MjE5NTkyLCJuYWIjoiSm9obiBEb2UiLCJpYXQiOjE1MTYyMzkwMjJ9.WP7xByegwjRvWZMwHScxunAOkwkW77ocaLvGen2PAU";
        // ReSharper disable once ObjectCreationAsStatement
        Assert.Throws<ArgumentException>(() => new JsonWebTokenPair(exampleToken, exampleToken));
    }

    /// <summary>
    /// Tests the token expiry extension method for correct behavior respecting time zones.
    /// </summary>
    [Test]
    public void CheckForTokenExpiry()
    {
        const string exampleToken =
            "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ0b2tlbl90eXBlIjoiYWNjZXNzIiwiZXhwIjoxNjg0Nzc3ODQ5LCJqdGkiOiIwIiwiaWQiOjEwMDAsInNlY3JldF9pZCI6IiIsImFsbG93ZWRfY2lkcnMiOlsiMC4wLjAuMC8wIiwiOjovMCJdfQ.AVVdSl2IdjeWaTQdzZy8zKjZDh4B5nqqUa-RMKqKFLQ";
        var token = new JsonWebToken(exampleToken);

        var stillValid = new DateTime(2023, 05, 22, 17, 50, 48);
        var noLongerValid = new DateTime(2023, 05, 22, 17, 50, 50);
        var diffValid = stillValid - DateTime.UtcNow;
        var diffInvalid = noLongerValid - DateTime.UtcNow;

        Assert.Multiple(() =>
        {
            Assert.That(token.IsExpired(diffValid), Is.False);
            Assert.That(token.IsExpired(diffInvalid), Is.True);
        });
    }
}
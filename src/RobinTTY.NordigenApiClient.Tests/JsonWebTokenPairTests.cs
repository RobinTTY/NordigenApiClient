using RobinTTY.NordigenApiClient.Models.Jwt;

namespace RobinTTY.NordigenApiClient.Tests;

public class JsonWebTokenPairTests
{
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

    [Test]
    
    public void CreateInvalidJsonWebTokenPair()
    {
        var exampleToken = "eyJhbGciOiJIUzI1NisInR5cCI6IkpXVCJ9.eyJ0eXBlIjoiYWNjZXNzIiwic3ViIjoiMTIzNDU2Nzg5MCIsIm5iZiI6MTY1OTE5OTU5MiwiZXhwIjoxNjU5MjE5NTkyLCJuYWIjoiSm9obiBEb2UiLCJpYXQiOjE1MTYyMzkwMjJ9.WP7xByegwjRvWZMwHScxunAOkwkW77ocaLvGen2PAU";
        Assert.Throws<ArgumentException>(() => new JsonWebTokenPair(exampleToken, exampleToken));
    }
}

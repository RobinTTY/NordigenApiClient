using System.Net.Http.Headers;
using RobinTTY.NordigenApiClient.Models.Jwt;

namespace RobinTTY.NordigenApiClient.Utility;

internal static class HttpClientExtensions
{
    /// <summary>
    ///     Sets the authentication header needed for most of the Nordigen API requests.
    ///     Nordigen docs reference: <see href="https://ob.helpscoutdocs.com/article/132-token-handling-via-api"></see>
    /// </summary>
    /// <param name="client">The <see cref="HttpClient" /> to apply the authentication header on.</param>
    /// <param name="tokenPair">
    ///     The <see cref="JsonWebTokenPair" /> to use for authentication.
    ///     If the token is null, no authentication header will be used.
    /// </param>
    internal static HttpClient UseNordigenAuthenticationHeader(this HttpClient client, JsonWebTokenPair? tokenPair)
    {
        if (tokenPair == null) return client;
        var rawToken = tokenPair.AccessToken.EncodedToken;
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", rawToken);
        return client;
    }
}

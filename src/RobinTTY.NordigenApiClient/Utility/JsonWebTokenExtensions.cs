using Microsoft.IdentityModel.Tokens;

namespace RobinTTY.NordigenApiClient.Utility;

internal static class JsonWebTokenExtensions
{
    /// <summary>
    /// Checks whether the token has expired using the current time.
    /// </summary>
    /// <param name="token">The token to check for expiration.</param>
    /// <param name="timeToExpiry">Optional <see cref="TimeSpan"/> added to the current time.</param>
    /// <returns>True if token is expired otherwise false.</returns>
    internal static bool IsExpired(this SecurityToken token, TimeSpan timeToExpiry = default) => token.ValidTo < DateTime.Now.Add(timeToExpiry);
}

using RobinTTY.NordigenApiClient.Models.Jwt;

namespace RobinTTY.NordigenApiClient.Events;

/// <summary>
/// Provides data for the <see cref="NordigenClient.TokenPairUpdated" /> event.
/// </summary>
public class TokenPairUpdatedEventArgs : EventArgs
{
    /// <summary>
    /// The updated <see cref="Models.Jwt.JsonWebTokenPair" />.
    /// </summary>
    public JsonWebTokenPair JsonWebTokenPair { get; set; }

    /// <summary>
    /// Creates a new instance of <see cref="TokenPairUpdatedEventArgs" />.
    /// </summary>
    /// <param name="jsonWebTokenPair">The updated <see cref="Models.Jwt.JsonWebTokenPair" />.</param>
    public TokenPairUpdatedEventArgs(JsonWebTokenPair jsonWebTokenPair) => JsonWebTokenPair = jsonWebTokenPair;
}

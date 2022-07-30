using System.Text.Json.Serialization;
using Microsoft.IdentityModel.JsonWebTokens;

namespace RobinTTY.NordigenApiClient.Models.Jwt;

/// <summary>
/// Represents the JWT token pair returned by the Nordigen API.
/// </summary>
public class JsonWebTokenPair
{
    /// <summary>
    /// The JWT access token returned by the Nordigen API.
    /// </summary>
    [JsonPropertyName("access")]
    public JsonWebToken AccessToken { get; set; }
    /// <summary>
    /// The JWT refresh token returned by the Nordigen API.
    /// </summary>
    [JsonPropertyName("refresh")]
    public JsonWebToken RefreshToken { get; set; }
    /// <summary>
    /// Indicates the time in seconds after which the access token expires.
    /// </summary>
    [JsonPropertyName("access_expires")]
    public uint AccessExpires { get; set; }
    /// <summary>
    /// Indicates the time in seconds after which the access token expires.
    /// </summary>
    [JsonPropertyName("refresh_expires")]
    public uint RefreshExpires { get; set; }

    /// <summary>
    /// Creates a new instance of <see cref="JsonWebTokenPair"/>.
    /// </summary>
    /// <param name="accessToken">The Nordigen access token to use.</param>
    /// <param name="refreshToken">The Nordigen refresh token to use.</param>
    /// <param name="accessExpires">The time in seconds after which the access token expires.</param>
    /// <param name="refreshExpires">The time in seconds after which the refresh token expires.</param>
    [JsonConstructor]
    public JsonWebTokenPair(JsonWebToken accessToken, JsonWebToken refreshToken, uint accessExpires, uint refreshExpires)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
        AccessExpires = accessExpires;
        RefreshExpires = refreshExpires;
    }

    /// <summary>
    /// Creates a new instance of <see cref="JsonWebTokenPair"/>.
    /// </summary>
    /// <param name="accessToken">The Nordigen access token to use.</param>
    /// <param name="refreshToken">The Nordigen refresh token to use.</param>
    public JsonWebTokenPair(string accessToken, string refreshToken)
    {
        var handler = new JsonWebTokenHandler();
        AccessToken = handler.ReadJsonWebToken(accessToken);
        RefreshToken = handler.ReadJsonWebToken(refreshToken);
        AccessExpires = (uint) (AccessToken.ValidTo - DateTime.Now).TotalSeconds;
        RefreshExpires = (uint) (RefreshToken.ValidTo - DateTime.Now).TotalSeconds;
    }
}

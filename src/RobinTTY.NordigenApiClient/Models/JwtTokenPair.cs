using System.IdentityModel.Tokens.Jwt;
using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models;

/// <summary>
/// Represents the JWT token pair returned by the Nordigen API.
/// </summary>
public class JwtTokenPair
{
    private static readonly JwtSecurityTokenHandler JwtTokenHandler = new();
    /// <summary>
    /// The JWT access token returned by the Nordigen API.
    /// </summary>
    [JsonPropertyName("access")]
    public JwtSecurityToken AccessToken { get; }
    /// <summary>
    /// The JWT refresh token returned by the Nordigen API.
    /// </summary>
    [JsonPropertyName("refresh")]
    public JwtSecurityToken RefreshToken { get; }
    /// <summary>
    /// Indicates the time in seconds after which the access token expires.
    /// </summary>
    [JsonPropertyName("access_expires")]
    public int AccessExpires { get; }
    [JsonPropertyName("refresh_expires")]
    public int RefreshExpires { get; }

    public JwtTokenPair(string accessToken, string refreshToken, int accessExpires, int refreshExpires)
    {
        AccessToken = JwtTokenHandler.ReadJwtToken(accessToken);
        RefreshToken = JwtTokenHandler.ReadJwtToken(refreshToken);
        AccessExpires = accessExpires;
        RefreshExpires = refreshExpires;
    }
}
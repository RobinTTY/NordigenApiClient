using System.IdentityModel.Tokens.Jwt;
using System.Text.Json.Serialization;
using RobinTTY.NordigenApiClient.JsonConverters;

namespace RobinTTY.NordigenApiClient.Models;

/// <summary>
/// Represents the JWT token pair returned by the Nordigen API.
/// </summary>
public class JwtTokenPair
{
    /// <summary>
    /// The JWT access token returned by the Nordigen API.
    /// </summary>
    [JsonPropertyName("access")]
    [JsonConverter(typeof(JwtSecurityTokenConverter))]
    public JwtSecurityToken AccessToken { get; init; }
    /// <summary>
    /// The JWT refresh token returned by the Nordigen API.
    /// </summary>
    [JsonPropertyName("refresh")]
    [JsonConverter(typeof(JwtSecurityTokenConverter))]
    public JwtSecurityToken RefreshToken { get; init; }
    /// <summary>
    /// Indicates the time in seconds after which the access token expires.
    /// </summary>
    [JsonPropertyName("access_expires")]
    public uint AccessExpires { get; init; }
    /// <summary>
    /// Indicates the time in seconds after which the access token expires.
    /// </summary>
    [JsonPropertyName("refresh_expires")]
    public uint RefreshExpires { get; init; }
}

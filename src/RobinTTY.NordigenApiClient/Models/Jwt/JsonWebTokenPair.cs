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
}

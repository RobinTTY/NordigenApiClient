using System.IdentityModel.Tokens.Jwt;
using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Jwt;

/// <summary>
/// Represents the JWT access token as well as the metadata returned by the Nordigen API.
/// </summary>
public class JwtAccessToken
{
    /// <summary>
    /// The JWT access token returned by the Nordigen API.
    /// </summary>
    [JsonPropertyName("access")]
    public JwtSecurityToken AccessToken { get; init; }
    /// <summary>
    /// Indicates the time in seconds after which the access token expires.
    /// </summary>
    [JsonPropertyName("access_expires")]
    public uint AccessExpires { get; init; }
}

using System.Text.Json.Serialization;
using Microsoft.IdentityModel.JsonWebTokens;

namespace RobinTTY.NordigenApiClient.Models.Jwt;

/// <summary>
/// Represents the json web access token as well as the metadata returned by the Nordigen API.
/// </summary>
public class JsonWebAccessToken
{
    /// <summary>
    /// The JWT access token returned by the Nordigen API.
    /// </summary>
    [JsonPropertyName("access")]
    public JsonWebToken AccessToken { get; init; }
    /// <summary>
    /// Indicates the time in seconds after which the access token expires.
    /// </summary>
    [JsonPropertyName("access_expires")]
    public uint AccessExpires { get; init; }
}

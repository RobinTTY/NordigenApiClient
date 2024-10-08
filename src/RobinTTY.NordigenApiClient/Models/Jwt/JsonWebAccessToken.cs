﻿using System.Text.Json.Serialization;
using Microsoft.IdentityModel.JsonWebTokens;

namespace RobinTTY.NordigenApiClient.Models.Jwt;

/// <summary>
/// Represents the json web access token as well as the metadata returned by the GoCardless API.
/// </summary>
public class JsonWebAccessToken
{
    /// <summary>
    /// The JWT access token returned by the GoCardless API.
    /// </summary>
    [JsonPropertyName("access")]
    public JsonWebToken AccessToken { get; init; }

    /// <summary>
    /// Indicates the time in seconds after which the access token expires.
    /// </summary>
    [JsonPropertyName("access_expires")]
    public int AccessExpires { get; init; }

    /// <summary>
    /// Creates a new instance of <see cref="JsonWebAccessToken" />.
    /// </summary>
    /// <param name="accessToken">The JWT access token returned by the GoCardless API.</param>
    /// <param name="accessExpires">Indicates the time in seconds after which the access token expires.</param>
    [JsonConstructor]
    public JsonWebAccessToken(JsonWebToken accessToken, int accessExpires)
    {
        AccessToken = accessToken;
        AccessExpires = accessExpires;
    }
}
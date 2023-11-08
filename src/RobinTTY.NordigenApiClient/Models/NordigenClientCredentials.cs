using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models;

/// <summary>
///     User secrets as provided by Nordigen. Used to acquire access tokens to the API.
/// </summary>
public class NordigenClientCredentials
{
    /// <summary>
    ///     Creates a new instance of <see cref="NordigenClientCredentials" />.
    /// </summary>
    /// <param name="secretId">Secret Nordigen id.</param>
    /// <param name="secretKey">Secret Nordigen key.</param>
    public NordigenClientCredentials(string secretId, string secretKey)
    {
        SecretId = secretId;
        SecretKey = secretKey;
    }

    /// <summary>
    ///     Secret Nordigen id.
    /// </summary>
    [JsonPropertyName("secret_id")]
    public string SecretId { get; }

    /// <summary>
    ///     Secret Nordigen key.
    /// </summary>
    [JsonPropertyName("secret_key")]
    public string SecretKey { get; }
}

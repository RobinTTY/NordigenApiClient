using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models;

public class NordigenClientCredentials
{
    [JsonPropertyName("secret_id")]
    public string SecretId { get; }
    [JsonPropertyName("secret_key")]
    public string SecretKey { get; }

    public NordigenClientCredentials(string secretId, string secretKey)
    {
        SecretId = secretId;
        SecretKey = secretKey;
    }
}

using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Requests;

/// <summary>
/// The metadata required to accept an end user agreement via the Nordigen API.
/// </summary>
public class AcceptAgreementRequest
{
    /// <summary>
    /// User agent of the client that accepts the request.
    /// </summary>
    [JsonPropertyName("user_agent")]
    public string UserAgent { get; set; }

    /// <summary>
    /// IP address of the client.
    /// </summary>
    [JsonPropertyName("ip_address")]
    public string IpAddress { get; set; }

    /// <summary>
    /// Creates a new instance of <see cref="AcceptAgreementRequest" />.
    /// </summary>
    /// <param name="userAgent">User agent of the client that accepts the request.</param>
    /// <param name="ipAddress">IP address of the client.</param>
    public AcceptAgreementRequest(string userAgent, string ipAddress)
    {
        UserAgent = userAgent;
        IpAddress = ipAddress;
    }
}

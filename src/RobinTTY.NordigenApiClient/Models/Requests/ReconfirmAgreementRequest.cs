using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Requests;

/// <summary>
/// The required information to reconfirm an end user agreement.
/// </summary>
internal class ReconfirmAgreementRequest
{
    /// <summary>
    /// Optional redirect URL for reconfirmation to override requisition's redirect.
    /// </summary>
    [JsonPropertyName("redirect")]
    public Uri? RedirectUrl { get; set; }

    /// <summary>
    /// Creates a new instance of <see cref="ReconfirmAgreementRequest"/>.
    /// </summary>
    public ReconfirmAgreementRequest(Uri? redirectUrl)
    {
        RedirectUrl = redirectUrl;
    }
}
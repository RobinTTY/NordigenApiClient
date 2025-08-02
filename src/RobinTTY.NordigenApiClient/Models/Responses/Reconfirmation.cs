using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// The details of a reconfirmation for an end user agreement.
/// </summary>
public class Reconfirmation
{
    /// <summary>
    /// URL for the reconfirmation process of an end user agreement.
    /// </summary>
    [JsonPropertyName("reconfirmation_url")]
    public Uri ReconfirmationUrl { get; set; }

    /// <summary>
    /// The date and time when the reconfirmation was created.
    /// </summary>
    [JsonPropertyName("created")]
    public DateTime Created { get; set; }

    /// <summary>
    /// The date and time the reconfirmation URL is valid from.
    /// </summary>
    [JsonPropertyName("url_valid_from")]
    public DateTime UrlValidFrom { get; set; }

    /// <summary>
    /// The date and time the reconfirmation URL is valid to.
    /// </summary>   
    [JsonPropertyName("url_valid_to")]
    public DateTime UrlValidTo { get; set; }

    /// <summary>
    /// The date and time when the reconfirmation was last accessed (not necessarily by the end-user).
    /// </summary>  
    [JsonPropertyName("last_accessed")]
    public DateTime? LastAccessed { get; set; }

    /// <summary>
    /// The date and time when the reconfirmation was last submitted (it can be submitted multiple times).
    /// </summary>
    [JsonPropertyName("last_submitted")]
    public DateTime? LastSubmitted { get; set; }

    /// <summary>
    /// Redirect URL for reconfirmation to override requisition's redirect.
    /// </summary>
    [JsonPropertyName("redirect")]
    public Uri RedirectUrl { get; set; }

    /// <summary>
    /// Dictionary of account IDs and their reconfirm and reject timestamps.
    /// </summary>
    [JsonPropertyName("accounts")]
    public Dictionary<string, ReconfirmationTimestamps> Accounts { get; set; }

    /// <summary>
    /// Represents the details related to the reconfirmation process for an end user agreement.
    /// </summary>
    /// <param name="reconfirmationUrl">URL for the reconfirmation process of an end user agreement.</param>
    /// <param name="created">The date and time when the reconfirmation was created.</param>
    /// <param name="urlValidFrom">The date and time the reconfirmation URL is valid from.</param>
    /// <param name="urlValidTo">The date and time the reconfirmation URL is valid to.</param>
    /// <param name="lastAccessed">The date and time when the reconfirmation was last accessed (not necessarily by the end-user).</param>
    /// <param name="lastSubmitted">The date and time when the reconfirmation was last submitted (it can be submitted multiple times).</param>
    /// <param name="redirectUrl">Redirect URL for reconfirmation to override requisition's redirect.</param>
    /// <param name="accounts">Dictionary of account IDs and their reconfirm and reject timestamps.</param>
    [JsonConstructor]
    public Reconfirmation(Uri reconfirmationUrl, DateTime created, DateTime urlValidFrom, DateTime urlValidTo,
        DateTime? lastAccessed, DateTime? lastSubmitted, Uri redirectUrl,
        Dictionary<string, ReconfirmationTimestamps> accounts)
    {
        ReconfirmationUrl = reconfirmationUrl;
        Created = created;
        UrlValidFrom = urlValidFrom;
        UrlValidTo = urlValidTo;
        LastAccessed = lastAccessed;
        LastSubmitted = lastSubmitted;
        RedirectUrl = redirectUrl;
        Accounts = accounts;
    }
}

/// <summary>
/// Represents timestamps for the reconfirmation and rejection actions within a reconfirmation process.
/// </summary>
public class ReconfirmationTimestamps
{
    /// <summary>
    /// The date and time when the reconfirmation process was completed.
    /// </summary>
    [JsonPropertyName("reconfirmed")]
    public DateTime? Reconfirmed { get; set; }

    /// <summary>
    /// The date and time when the reconfirmation process was rejected.
    /// </summary>
    [JsonPropertyName("rejected")]
    public DateTime? Rejected { get; set; }

    /// <summary>
    /// Creates a new instance of <see cref="ReconfirmationTimestamps"/>.
    /// </summary>
    /// <param name="reconfirmed">The date and time when the reconfirmation action was performed, if applicable.</param>
    /// <param name="rejected">The date and time when the rejection action was performed, if applicable.</param>
    [JsonConstructor]
    public ReconfirmationTimestamps(DateTime? reconfirmed, DateTime? rejected)
    {
        Reconfirmed = reconfirmed;
        Rejected = rejected;
    }
}
using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Errors;

/// <summary>
/// An error description as returned by some operations of the accounts endpoint of the Nordigen API.
/// </summary>
public class AccountsError : BasicError
{
    /// <summary>
    /// The type of the error.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; }

    /// <summary>
    /// Creates a new instance of <see cref="AccountsError"/>.
    /// </summary>
    /// <param name="summary">The summary of the API error.</param>
    /// <param name="detail">The detailed description of the API error.</param>
    /// <param name="type">The type of the error.</param>
    public AccountsError(string summary, string detail, string type) : base(summary, detail)
    {
        Type = type;
    }
}

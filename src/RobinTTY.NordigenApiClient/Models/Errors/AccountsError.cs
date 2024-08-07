using System.Text.Json.Serialization;
using RobinTTY.NordigenApiClient.Endpoints;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Models.Errors;

/// <summary>
/// An error description as returned by some operations of the accounts endpoint of the GoCardless API.
/// </summary>
public class AccountsError : BasicResponse
{
    /// <summary>
    /// The type of the error.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; }

#if NET6_0_OR_GREATER
    /// <summary>
    /// An error that was returned related to the
    /// <see cref="AccountsEndpoint.GetTransactions(Guid, DateOnly?, DateOnly?, CancellationToken)" /> or
    /// <see cref="AccountsEndpoint.GetTransactions(string, DateOnly?, DateOnly?, CancellationToken)" /> method because the
    /// start date value was not accepted.
    /// </summary>
#else
    /// <summary>
    /// An error that was returned related to the
    /// <see cref="AccountsEndpoint.GetTransactions(Guid, DateTime?, DateTime?, CancellationToken)" /> or
    /// <see cref="AccountsEndpoint.GetTransactions(string, DateTime?, DateTime?, CancellationToken)" /> method because the
    /// start date value was not accepted.
    /// </summary>
#endif
    [JsonPropertyName("date_from")]
    public BasicResponse? StartDateError { get; }

#if NET6_0_OR_GREATER
    /// <summary>
    /// An error that was returned related to the
    /// <see cref="AccountsEndpoint.GetTransactions(Guid, DateOnly?, DateOnly?, CancellationToken)" /> or
    /// <see cref="AccountsEndpoint.GetTransactions(string, DateOnly?, DateOnly?, CancellationToken)" /> method because the
    /// end date value was not accepted.
    /// </summary>
#else
    /// <summary>
    /// An error that was returned related to the
    /// <see cref="AccountsEndpoint.GetTransactions(Guid, DateTime?, DateTime?, CancellationToken)" /> or
    /// <see cref="AccountsEndpoint.GetTransactions(string, DateTime?, DateTime?, CancellationToken)" /> method because the end
    /// date value was not accepted.
    /// </summary>
#endif
    [JsonPropertyName("date_to")]
    public BasicResponse? EndDateError { get; }

    /// <summary>
    /// Creates a new instance of <see cref="AccountsError" />.
    /// </summary>
    public AccountsError() { }

#if NET6_0_OR_GREATER
    /// <summary>
    /// Creates a new instance of <see cref="AccountsError" />.
    /// </summary>
    /// <param name="summary">The summary of the API error.</param>
    /// <param name="detail">The detailed description of the API error.</param>
    /// <param name="type">The type of the error.</param>
    /// <param name="startDateError">
    /// An error that was returned related to the
    /// <see cref="AccountsEndpoint.GetTransactions(Guid, DateOnly?, DateOnly?, CancellationToken)" /> or
    /// <see cref="AccountsEndpoint.GetTransactions(string, DateOnly?, DateOnly?, CancellationToken)" /> method because the
    /// start date value was not accepted.
    /// </param>
    /// <param name="endDateError">
    /// An error that was returned related to the
    /// <see cref="AccountsEndpoint.GetTransactions(Guid, DateOnly?, DateOnly?, CancellationToken)" /> or
    /// <see cref="AccountsEndpoint.GetTransactions(string, DateOnly?, DateOnly?, CancellationToken)" /> method because the
    /// end date value was not accepted.
    /// </param>
#else
    /// <summary>
    /// Creates a new instance of <see cref="AccountsError" />.
    /// </summary>
    /// <param name="summary">The summary of the API error.</param>
    /// <param name="detail">The detailed description of the API error.</param>
    /// <param name="type">The type of the error.</param>
    /// <param name="startDateError">
    /// An error that was returned related to the
    /// <see cref="AccountsEndpoint.GetTransactions(Guid, DateTime?, DateTime?, CancellationToken)" /> or
    /// <see cref="AccountsEndpoint.GetTransactions(string, DateTime?, DateTime?, CancellationToken)" /> method because the
    /// start date value was not accepted.
    /// </param>
    /// <param name="endDateError">
    /// An error that was returned related to the
    /// <see cref="AccountsEndpoint.GetTransactions(Guid, DateTime?, DateTime?, CancellationToken)" /> or
    /// <see cref="AccountsEndpoint.GetTransactions(string, DateTime?, DateTime?, CancellationToken)" /> method because the end
    /// date value was not accepted.
    /// </param>
#endif
    [JsonConstructor]
    public AccountsError(string? summary, string? detail, string? type, BasicResponse? startDateError,
        BasicResponse? endDateError) : base(summary, detail)
    {
        Type = type;
        StartDateError = startDateError;
        EndDateError = endDateError;
    }
}

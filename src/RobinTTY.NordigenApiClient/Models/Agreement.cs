﻿using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models;

/// <summary>
/// An end user agreement which determines the scope and length of access to data provided by institutions.
/// </summary>
public class Agreement : AgreementRequest
{
    /// <summary>
    /// The id of the agreement assigned by the Nordigen API.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }
    /// <summary>
    /// Time when the agreement was created.
    /// </summary>
    [JsonPropertyName("created")]
    public DateTime Created { get; set; }

    /// <summary>
    /// Time when the agreement was accepted.
    /// </summary>
    [JsonPropertyName("accepted")]
    public DateTime Accepted { get; set; }

    /// <summary>
    /// Creates a new instance of <see cref="Agreement"/>.
    /// </summary>
    /// <param name="id">The id of the agreement assigned by the Nordigen API.</param>
    /// <param name="created">Time when the agreement was created.</param>
    /// <param name="maxHistoricalDays">The length of the transaction history in days.</param>
    /// <param name="accessValidForDays">The length the access to the account will be valid for.</param>
    /// <param name="accessScope">The scope of information that can be accessed.</param>
    /// <param name="accepted">Time when the agreement was accepted.</param>
    /// <param name="institutionId">The institution this agreement refers to.</param>
    public Agreement(string id, DateTime created, uint maxHistoricalDays, uint accessValidForDays, List<string> accessScope,
        DateTime accepted, string institutionId) : base(maxHistoricalDays, accessValidForDays, accessScope, institutionId)
    {
        Id = id;
        Created = created;
        Accepted = accepted;
    }
}

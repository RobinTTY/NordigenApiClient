﻿using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models;

/// <summary>
/// A paged response from the Nordigen API.
/// </summary>
/// <typeparam name="T">The contained response type.</typeparam>
public class ResponsePage<T>
{
    /// <summary>
    /// The total number of items that can be accessed via the paged responses.
    /// </summary>
    [JsonPropertyName("count")]
    public uint Count { get; set; }
    /// <summary>
    /// The URI of the next response page.
    /// </summary>
    [JsonPropertyName("next")]
    public Uri Next { get; set; }
    /// <summary>
    /// The URI of the last response page.
    /// </summary>
    [JsonPropertyName("previous")]
    public Uri Previous { get; set; }
    /// <summary>
    /// The results that were fetched with this page.
    /// </summary>
    [JsonPropertyName("results")]
    public IEnumerable<T> Results { get; set; }
}

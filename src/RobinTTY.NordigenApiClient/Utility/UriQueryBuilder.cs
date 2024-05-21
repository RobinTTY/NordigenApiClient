using System.Web;

namespace RobinTTY.NordigenApiClient.Utility;

/// <summary>
/// Provides methods for adding query parameters to URIs.
/// </summary>
internal static class UriQueryBuilder
{
    /// <summary>
    /// Constructs a query string from the given query key-value pairs.
    /// </summary>
    /// <param name="queryKeyValuePairs">The query parameters to add.</param>
    /// <returns>The query string.</returns>
    internal static string GetQueryString(IEnumerable<KeyValuePair<string, string>> queryKeyValuePairs)
    {
        var query = HttpUtility.ParseQueryString(string.Empty);
        foreach (var kvp in queryKeyValuePairs) query.Add(kvp.Key, kvp.Value);
        return query.ToString() is null ? string.Empty : $"?{query}";
    }
}

using System.Web;

namespace RobinTTY.NordigenApiClient.Utility;

/// <summary>
/// Provides methods for adding query parameters to URIs.
/// </summary>
internal static class UriQueryBuilder
{
    /// <summary>
    /// Adds query parameters to the given URI string.
    /// </summary>
    /// <param name="uri">The URI string to add the query parameters to.</param>
    /// <param name="queryKeyValuePairs">The query parameters to add.</param>
    /// <returns>The complete URI string wit added query parameters.</returns>
    internal static string BuildUriWithQueryString(string uri,
        IEnumerable<KeyValuePair<string, string>> queryKeyValuePairs)
    {
        var builder = new UriBuilder(uri);
        var query = HttpUtility.ParseQueryString(builder.Query);
        foreach (var kvp in queryKeyValuePairs) query[kvp.Key] = kvp.Value;
        builder.Query = query.ToString();
        return builder.ToString();
    }
}

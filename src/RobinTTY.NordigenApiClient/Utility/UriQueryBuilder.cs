using System.Web;

namespace RobinTTY.NordigenApiClient.Utility;

internal static class UriQueryBuilder
{
    internal static string BuildUriWithQueryString(string uri, IEnumerable<KeyValuePair<string, string>> queryKeyValuePairs)
    {
        var builder = new UriBuilder(uri);
        var query = HttpUtility.ParseQueryString(builder.Query);
        foreach (var kvp in queryKeyValuePairs)
        {
            query[kvp.Key] = kvp.Value;
        }
        builder.Query = query.ToString();
        return builder.ToString();
    }
}

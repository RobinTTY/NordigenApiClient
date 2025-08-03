using System.Net.Http.Headers;
using RobinTTY.NordigenApiClient.Endpoints;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// The rate limits of the GoCardless API.
/// <para>
/// The rate limits can be <see langword="null"/> if a request fails due to validation errors before being sent to the API
/// (e.g., no secretId/secretKey provided). So no actual API request was performed and no rate limits can be returned.
/// </para>
/// </summary>
public class ApiRateLimits
{
    /// <summary>
    /// Indicates the maximum number of allowed requests within the defined time window.
    /// Usually populated in every response.
    /// </summary>
    public int? RequestLimit { get; set; }

    /// <summary>
    /// Indicates the number of remaining requests you can make in the current time window.
    /// Usually populated in every response.
    /// </summary>
    public int? RemainingRequests { get; set; }

    /// <summary>
    /// Indicates the time remaining in the current time window (in seconds).
    /// Usually populated in every response.
    /// </summary>
    public int? RemainingSecondsInTimeWindow { get; set; }

    /// <summary>
    /// Indicates the maximum number of allowed requests to the <see cref="AccountsEndpoint" />
    /// within the defined time window. Only populated in responses from the <see cref="AccountsEndpoint" />.
    /// </summary>
    public int? RequestLimitAccountsEndpoint { get; set; }

    /// <summary>
    /// Indicates the number of remaining requests to the <see cref="AccountsEndpoint" />
    /// you can make in the current time window. Only populated in responses from the <see cref="AccountsEndpoint" />.
    /// </summary>
    public int? RemainingRequestsAccountsEndpoint { get; set; }

    /// <summary>
    /// Indicates the time remaining in the current time window (in seconds) for requests
    /// to the <see cref="AccountsEndpoint" />. Only populated in responses from the <see cref="AccountsEndpoint" />.
    /// </summary>
    public int? RemainingSecondsInTimeWindowAccountsEndpoint { get; set; }

    /// <summary>
    /// Creates a new instance of <see cref="ApiRateLimits" />.
    /// </summary>
    /// <param name="requestLimit">Indicates the maximum number of allowed requests within the defined time window.</param>
    /// <param name="remainingRequests">Indicates the number of remaining requests you can make in the current time window.</param>
    /// <param name="remainingSecondsInTimeWindow">Indicates the time remaining in the current time window (in seconds).</param>
    /// <param name="requestLimitAccountsEndpoint">
    /// Indicates the maximum number of allowed requests to the <see cref="AccountsEndpoint" />
    /// within the defined time window.
    /// </param>
    /// <param name="remainingRequestsAccountsEndpoint">
    /// Indicates the number of remaining requests to the <see cref="AccountsEndpoint" />
    /// you can make in the current time window.
    /// </param>
    /// <param name="remainingSecondsInTimeWindowAccountsEndpoint">
    /// Indicates the time remaining in the current time window (in seconds) for requests
    /// to the <see cref="AccountsEndpoint" />.
    /// </param>
    public ApiRateLimits(int? requestLimit, int? remainingRequests, int? remainingSecondsInTimeWindow,
        int? requestLimitAccountsEndpoint,
        int? remainingRequestsAccountsEndpoint, int? remainingSecondsInTimeWindowAccountsEndpoint)
    {
        RequestLimit = requestLimit;
        RemainingRequests = remainingRequests;
        RemainingSecondsInTimeWindow = remainingSecondsInTimeWindow;
        RequestLimitAccountsEndpoint = requestLimitAccountsEndpoint;
        RemainingRequestsAccountsEndpoint = remainingRequestsAccountsEndpoint;
        RemainingSecondsInTimeWindowAccountsEndpoint = remainingSecondsInTimeWindowAccountsEndpoint;
    }

    /// <summary>
    /// Creates a new instance of <see cref="ApiRateLimits" />.
    /// </summary>
    /// <param name="headers">The headers of the HTTP response containing the rate limit information.</param>
    public ApiRateLimits(HttpHeaders headers)
    {
        RequestLimit = TryParseApiLimit(headers, "HTTP_X_RATELIMIT_LIMIT");
        RemainingRequests = TryParseApiLimit(headers, "HTTP_X_RATELIMIT_REMAINING");
        RemainingSecondsInTimeWindow = TryParseApiLimit(headers, "HTTP_X_RATELIMIT_RESET");
        RequestLimitAccountsEndpoint = TryParseApiLimit(headers, "HTTP_X_RATELIMIT_ACCOUNT_SUCCESS_LIMIT");
        RemainingRequestsAccountsEndpoint = TryParseApiLimit(headers, "HTTP_X_RATELIMIT_ACCOUNT_SUCCESS_REMAINING");
        RemainingSecondsInTimeWindowAccountsEndpoint =
            TryParseApiLimit(headers, "HTTP_X_RATELIMIT_ACCOUNT_SUCCESS_RESET");
    }

    private static int? TryParseApiLimit(HttpHeaders headers, string headerName)
    {
        headers.TryGetValues(headerName, out var values);
        var firstHeaderValue = values?.FirstOrDefault();
        var parseSuccess = int.TryParse(firstHeaderValue, out var limitValue);

        return parseSuccess ? limitValue : null;
    }
}
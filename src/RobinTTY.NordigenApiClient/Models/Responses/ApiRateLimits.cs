using System.Net.Http.Headers;
using RobinTTY.NordigenApiClient.Endpoints;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// The rate limits of the GoCardless API.
/// </summary>
public class ApiRateLimits
{
    /// <summary>
    /// Indicates the maximum number of allowed requests within the defined time window.
    /// </summary>
    public int RequestLimit { get; set; }
    /// <summary>
    /// Indicates the number of remaining requests you can make in the current time window.
    /// </summary>
    public int RemainingRequests { get; set; }
    /// <summary>
    /// Indicates the time remaining in the current time window (in seconds).
    /// </summary>
    public int RemainingSecondsInTimeWindow { get; set; }
    /// <summary>
    /// Indicates the maximum number of allowed requests to the <see cref="AccountsEndpoint"/>
    /// within the defined time window.
    /// </summary>
    public int RequestLimitAccountsEndpoint { get; set; }
    /// <summary>
    /// Indicates the number of remaining requests to the <see cref="AccountsEndpoint"/>
    /// you can make in the current time window.
    /// </summary>
    public int RemainingRequestsAccountsEndpoint { get; set; }
    /// <summary>
    /// Indicates the time remaining in the current time window (in seconds) for requests
    /// to the <see cref="AccountsEndpoint"/>.
    /// </summary>
    public int RemainingSecondsInTimeWindowAccountsEndpoint { get; set; }
    
    /// <summary>
    /// Creates a new instance of <see cref="ApiRateLimits" />.
    /// </summary>
    /// <param name="requestLimit">Indicates the maximum number of allowed requests within the defined time window.</param>
    /// <param name="remainingRequests">Indicates the number of remaining requests you can make in the current time window.</param>
    /// <param name="remainingSecondsInTimeWindow">Indicates the time remaining in the current time window (in seconds).</param>
    /// <param name="requestLimitAccountsEndpoint">Indicates the maximum number of allowed requests to the <see cref="AccountsEndpoint"/>
    /// within the defined time window.</param>
    /// <param name="remainingRequestsAccountsEndpoint">Indicates the number of remaining requests to the <see cref="AccountsEndpoint"/>
    /// you can make in the current time window.</param>
    /// <param name="remainingSecondsInTimeWindowAccountsEndpoint">Indicates the time remaining in the current time window (in seconds) for requests
    /// to the <see cref="AccountsEndpoint"/>.</param>
    public ApiRateLimits(int requestLimit, int remainingRequests, int remainingSecondsInTimeWindow, int requestLimitAccountsEndpoint,
        int remainingRequestsAccountsEndpoint, int remainingSecondsInTimeWindowAccountsEndpoint)
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
        headers.TryGetValues("HTTP_X_RATELIMIT_LIMIT", out var requestLimitInTimeWindow);
        headers.TryGetValues("HTTP_X_RATELIMIT_REMAINING", out var remainingRequestsInTimeWindow);
        headers.TryGetValues("HTTP_X_RATELIMIT_RESET", out var remainingTimeInTimeWindow);
        headers.TryGetValues("HTTP_X_RATELIMIT_ACCOUNT_SUCCESS_LIMIT", out var maxAccountRequestsInTimeWindow);
        headers.TryGetValues("HTTP_X_RATELIMIT_ACCOUNT_SUCCESS_REMAINING", out var remainingAccountRequestsInTimeWindow);
        headers.TryGetValues("HTTP_X_RATELIMIT_ACCOUNT_SUCCESS_RESET", out var remainingTimeInAccountTimeWindow);

        RequestLimit = requestLimitInTimeWindow != null ? int.Parse(requestLimitInTimeWindow.First()) : 0;
        RemainingRequests = remainingRequestsInTimeWindow != null ? int.Parse(remainingRequestsInTimeWindow.First()) : 0;
        RemainingSecondsInTimeWindow = remainingTimeInTimeWindow != null ? int.Parse(remainingTimeInTimeWindow.First()) : 0;
        RequestLimitAccountsEndpoint = maxAccountRequestsInTimeWindow != null ? int.Parse(maxAccountRequestsInTimeWindow.First()) : 0;
        RemainingRequestsAccountsEndpoint = remainingAccountRequestsInTimeWindow != null ? int.Parse(remainingAccountRequestsInTimeWindow.First()) : 0;
        RemainingSecondsInTimeWindowAccountsEndpoint = remainingTimeInAccountTimeWindow != null ? int.Parse(remainingTimeInAccountTimeWindow.First()) : 0;
    }
}

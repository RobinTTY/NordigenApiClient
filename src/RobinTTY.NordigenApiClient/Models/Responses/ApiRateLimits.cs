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
    public int MaxAccountRequests { get; set; }
    /// <summary>
    /// Indicates the number of remaining requests to the <see cref="AccountsEndpoint"/>
    /// you can make in the current time window.
    /// </summary>
    public int RemainingAccountRequests { get; set; }
    /// <summary>
    /// Indicates the time remaining in the current time window (in seconds) for requests
    /// to the <see cref="AccountsEndpoint"/>.
    /// </summary>
    public int RemainingSecondsInAccountTimeWindow { get; set; }
    
    /// <summary>
    /// Creates a new instance of <see cref="ApiRateLimits" />.
    /// </summary>
    /// <param name="requestLimit">Indicates the maximum number of allowed requests within the defined time window.</param>
    /// <param name="remainingRequests">Indicates the number of remaining requests you can make in the current time window.</param>
    /// <param name="remainingTimeInTimeWindow">Indicates the time remaining in the current time window (in seconds).</param>
    /// <param name="maxAccountRequests">Indicates the maximum number of allowed requests to the <see cref="AccountsEndpoint"/>
    /// within the defined time window.</param>
    /// <param name="remainingAccountRequests">Indicates the number of remaining requests to the <see cref="AccountsEndpoint"/>
    /// you can make in the current time window.</param>
    /// <param name="remainingTimeInAccountTimeWindow">Indicates the time remaining in the current time window (in seconds) for requests
    /// to the <see cref="AccountsEndpoint"/>.</param>
    public ApiRateLimits(int requestLimit, int remainingRequests, int remainingTimeInTimeWindow, int maxAccountRequests,
        int remainingAccountRequests, int remainingTimeInAccountTimeWindow)
    {
        RequestLimit = requestLimit;
        RemainingRequests = remainingRequests;
        RemainingSecondsInTimeWindow = remainingTimeInTimeWindow;
        MaxAccountRequests = maxAccountRequests;
        RemainingAccountRequests = remainingAccountRequests;
        RemainingSecondsInAccountTimeWindow = remainingTimeInAccountTimeWindow;
    }
}

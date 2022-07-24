namespace RobinTTY.NordigenApiClient.Models;

public class NordigenApiError
{
    /// <summary>
    /// The summary of the API error.
    /// </summary>
    public string Summary { get; }
    /// <summary>
    /// The detailed description of the API error.
    /// </summary>
    public string Detail { get; }

    /// <summary>
    /// Creates a new instance of <see cref="NordigenApiError"/>.
    /// </summary>
    /// <param name="summary">The summary of the API error.</param>
    /// <param name="detail">The detailed description of the API error.</param>
    public NordigenApiError(string summary, string detail)
    {
        Summary = summary;
        Detail = detail;
    }
}

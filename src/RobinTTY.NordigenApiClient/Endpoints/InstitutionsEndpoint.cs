using RobinTTY.NordigenApiClient.Models;

namespace RobinTTY.NordigenApiClient.Endpoints;

public class InstitutionsEndpoint
{
    private readonly NordigenClient _nordigenClient;

    public InstitutionsEndpoint(NordigenClient client)
    {
        _nordigenClient = client;
    }

    /// <summary>
    /// Gets a list of institutions supported by the Nordigen API.
    /// Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/institutions/retrieve%20all%20supported%20Institutions%20in%20a%20given%20country"></see>
    /// </summary>
    /// <param name="country">The two-letter country code (<see href="https://wikipedia.org/wiki/ISO_3166-1">ISO 3166</see>) in which the institutions operate.</param>
    /// <param name="paymentsEnabled">Whether or not payments are enabled for the institutions.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{T}"/> containing a list of supported institutions if the request was successful.</returns>
    public async Task<NordigenApiResponse<List<Institution>>> GetInstitutions(string country = "", bool paymentsEnabled = false, CancellationToken cancellationToken = default)
    {
        var query = new KeyValuePair<string, string>[] {new("country", country), new("payments_enabled", paymentsEnabled.ToString())};
        return await _nordigenClient.MakeRequest<List<Institution>>(NordigenEndpointUrls.InstitutionsEndpoint, HttpMethod.Get, cancellationToken, query);
    }

    /// <summary>
    /// Gets a specific institution by id.
    /// Route: https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/institutions/retrieve%20institution
    /// </summary>
    /// <param name="id">The id assigned to the institution by Nordigen (can be retrieved via <see cref="GetInstitutions"/>).</param>
    /// <param name="cancellationToken">>Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{T}"/> containing the institution matching the id if the request was successful.</returns>
    public async Task<NordigenApiResponse<Institution>> GetInstitution(string id, CancellationToken cancellationToken = default)
    {
        return await _nordigenClient.MakeRequest<Institution>($"{NordigenEndpointUrls.InstitutionsEndpoint}{id}/", HttpMethod.Get, cancellationToken);
    }
}

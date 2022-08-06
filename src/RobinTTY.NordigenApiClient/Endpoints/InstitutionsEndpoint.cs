using RobinTTY.NordigenApiClient.Models.Errors;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Endpoints;

/// <summary>
/// Provides support for the API operations of the institutions endpoint.
/// <para>Reference: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/institutions"/></para>
/// </summary>
public class InstitutionsEndpoint
{
    private readonly NordigenClient _nordigenClient;

    /// <summary>
    /// Creates a new instance of <see cref="InstitutionsEndpoint"/>.
    /// </summary>
    /// <param name="client">The <see cref="NordigenClient"/> to use for token handling and request processing.</param>
    internal InstitutionsEndpoint(NordigenClient client)
    {
        _nordigenClient = client;
    }

    /// <summary>
    /// Gets a list of institutions supported by the Nordigen API.
    /// <para>Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/institutions/retrieve%20all%20supported%20Institutions%20in%20a%20given%20country"></see></para>
    /// </summary>
    /// <param name="country">The two-letter country code (<see href="https://wikipedia.org/wiki/ISO_3166-1">ISO 3166</see>) in which the institutions operate.</param>
    /// <param name="paymentsEnabled">Whether or not payments are enabled for the institutions.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}"/> containing a list of supported institutions if the request was successful.</returns>
    public async Task<NordigenApiResponse<List<Institution>, InstitutionsError>> GetInstitutions(string country = "", bool paymentsEnabled = false, CancellationToken cancellationToken = default)
    {
        var query = new KeyValuePair<string, string>[] {new("country", country), new("payments_enabled", paymentsEnabled.ToString())};
        return await _nordigenClient.MakeRequest<List<Institution>, InstitutionsError>(NordigenEndpointUrls.InstitutionsEndpoint, HttpMethod.Get, cancellationToken, query);
    }

    /// <summary>
    /// Gets a specific institution by id.
    /// <para>Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/institutions/retrieve%20institution"/></para>
    /// </summary>
    /// <param name="id">The id assigned to the institution by Nordigen (can be retrieved via <see cref="GetInstitutions"/>).</param>
    /// <param name="cancellationToken">>Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}"/> containing the institution matching the id if the request was successful.</returns>
    public async Task<NordigenApiResponse<Institution, BasicError>> GetInstitution(string id, CancellationToken cancellationToken = default)
    {
        return await _nordigenClient.MakeRequest<Institution, BasicError>($"{NordigenEndpointUrls.InstitutionsEndpoint}{id}/", HttpMethod.Get, cancellationToken);
    }
}

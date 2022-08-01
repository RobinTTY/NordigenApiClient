using System.Net.Http.Json;
using RobinTTY.NordigenApiClient.Models;

namespace RobinTTY.NordigenApiClient.Endpoints;

public class AgreementsEndpoint
{
    private readonly NordigenClient _nordigenClient;

    /// <summary>
    /// Creates a new instance of <see cref="AgreementsEndpoint"/>.
    /// </summary>
    /// <param name="client">The <see cref="NordigenClient"/> to use for token handling and request processing.</param>
    internal AgreementsEndpoint(NordigenClient client)
    {
        _nordigenClient = client;
    }

    /// <summary>
    /// Gets a <see cref="ResponsePage{T}"/> containing a given number of end user agreements.
    /// Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/agreements/retrieve%20all%20EUAs%20for%20an%20end%20user%20v2"/>
    /// </summary>
    /// <param name="limit">Number of results to return per page.</param>
    /// <param name="offset">The initial index from which to return the results.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{T}"/> containing a <see cref="ResponsePage{T}"/> which contains a list of end user agreements.</returns>
    public async Task<NordigenApiResponse<ResponsePage<Agreement>>> GetAgreements(int limit, int offset, CancellationToken cancellationToken = default)
    {
        var query = new KeyValuePair<string, string>[] { new("limit", limit.ToString()), new("offset", offset.ToString()) };
        return await _nordigenClient.MakeRequest<ResponsePage<Agreement>>(NordigenEndpointUrls.AgreementsEndpoint, HttpMethod.Get, cancellationToken, query);
    }

    /// <summary>
    /// Creates a new end user agreement which determines the scope and length of access to data provided by institutions.
    /// </summary>
    /// <param name="agreement">The agreement to create.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{T}"/> containing the created <see cref="Agreement"/>.</returns>
    public async Task<NordigenApiResponse<Agreement>> CreateAgreement(AgreementRequest agreement, CancellationToken cancellationToken = default)
    {
        var body = JsonContent.Create(agreement);
        return await _nordigenClient.MakeRequest<Agreement>(NordigenEndpointUrls.AgreementsEndpoint, HttpMethod.Post, cancellationToken, body: body);
    }
}

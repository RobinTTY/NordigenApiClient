using System.Net.Http.Json;
using RobinTTY.NordigenApiClient.Models.Errors;
using RobinTTY.NordigenApiClient.Models.Requests;
using RobinTTY.NordigenApiClient.Models.Responses;

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
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}"/> containing a <see cref="ResponsePage{T}"/> which contains a list of end user agreements.</returns>
    public async Task<NordigenApiResponse<ResponsePage<Agreement>, BasicError>> GetAgreements(int limit, int offset, CancellationToken cancellationToken = default)
    {
        var query = new KeyValuePair<string, string>[] { new("limit", limit.ToString()), new("offset", offset.ToString()) };
        return await _nordigenClient.MakeRequest<ResponsePage<Agreement>, BasicError>(NordigenEndpointUrls.AgreementsEndpoint, HttpMethod.Get, cancellationToken, query);
    }

    /// <summary>
    /// Gets the next <see cref="ResponsePage{T}"/>, linked to the current one.
    /// Route: https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/agreements/retrieve%20all%20EUAs%20for%20an%20end%20user%20v2
    /// </summary>
    /// <param name="agreementPage">The current response page.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>Either a <see cref="NordigenApiResponse{TResponse, TError}"/> containing a <see cref="ResponsePage{T}"/> which contains a list of end user agreements.
    /// Or null if there is no next page to retrieve.</returns>
    public async Task<NordigenApiResponse<ResponsePage<Agreement>, BasicError>?> GetNextAgreementsPage(ResponsePage<Agreement> agreementPage, CancellationToken cancellationToken = default)
    {
        if (agreementPage.Next == null) return null;
        return await _nordigenClient.MakeRequest<ResponsePage<Agreement>, BasicError>(agreementPage.Next.AbsoluteUri, HttpMethod.Get, cancellationToken);
    }

    /// <summary>
    /// Gets the previous <see cref="ResponsePage{T}"/>, linked to the current one.
    /// Route: https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/agreements/retrieve%20all%20EUAs%20for%20an%20end%20user%20v2
    /// </summary>
    /// <param name="agreementPage">The current response page.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>Either a <see cref="NordigenApiResponse{TResponse, TError}"/> containing a <see cref="ResponsePage{T}"/> which contains a list of end user agreements.
    /// Or null if there is no previous page to retrieve.</returns>
    public async Task<NordigenApiResponse<ResponsePage<Agreement>, BasicError>?> GetPreviousAgreementsPage(ResponsePage<Agreement> agreementPage, CancellationToken cancellationToken = default)
    {
        if (agreementPage.Previous == null) return null;
        return await _nordigenClient.MakeRequest<ResponsePage<Agreement>, BasicError>(agreementPage.Previous.AbsoluteUri, HttpMethod.Get, cancellationToken);
    }

    /// <summary>
    /// Gets the end user agreement with the given id.
    /// Route: https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/agreements/retrieve%20EUA%20by%20id%20v2
    /// </summary>
    /// <param name="id">The id of the agreement to retrieve.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}"/> which contains the specified end user agreements.</returns>
    public async Task<NordigenApiResponse<Agreement, BasicError>> GetAgreement(Guid id, CancellationToken cancellationToken = default)
        => await GetAgreementBase(id.ToString(), cancellationToken);

    /// <summary>
    /// Gets the end user agreement with the given id.
    /// Route: https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/agreements/retrieve%20EUA%20by%20id%20v2
    /// </summary>
    /// <param name="id">The id of the agreement to retrieve.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}"/> which contains the specified end user agreements.</returns>
    public async Task<NordigenApiResponse<Agreement, BasicError>> GetAgreement(string id, CancellationToken cancellationToken = default)
        => await GetAgreementBase(id, cancellationToken);

    private async Task<NordigenApiResponse<Agreement, BasicError>> GetAgreementBase(string id, CancellationToken cancellationToken)
    {
        return await _nordigenClient.MakeRequest<Agreement, BasicError>($"{NordigenEndpointUrls.AgreementsEndpoint}{id}/", HttpMethod.Get, cancellationToken);
    }

    /// <summary>
    /// Creates a new end user agreement which determines the scope and length of access to data provided by institutions.
    /// Route: https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/agreements/create%20EUA%20v2
    /// </summary>
    /// <param name="agreement">The agreement to create.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}"/> containing the created <see cref="Agreement"/>.</returns>
    public async Task<NordigenApiResponse<Agreement, AgreementsError>> CreateAgreement(CreateAgreementRequest agreement, CancellationToken cancellationToken = default)
    {
        var body = JsonContent.Create(agreement);
        return await _nordigenClient.MakeRequest<Agreement, AgreementsError>(NordigenEndpointUrls.AgreementsEndpoint, HttpMethod.Post, cancellationToken, body: body);
    }

    /// <summary>
    /// Deletes the end user agreement with the given id.
    /// Route: https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/agreements/delete%20EUA%20by%20id%20v2
    /// </summary>
    /// <param name="id">The id of the agreement to delete.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}"/> containing a confirmation of the deletion.</returns>
    public async Task<NordigenApiResponse<BasicResponse, BasicError>> DeleteAgreement(Guid id, CancellationToken cancellationToken = default)
        => await DeleteAgreementBase(id.ToString(), cancellationToken);

    /// <summary>
    /// Deletes the end user agreement with the given id.
    /// Route: https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/agreements/delete%20EUA%20by%20id%20v2
    /// </summary>
    /// <param name="id">The id of the agreement to delete.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}"/> containing a confirmation of the deletion.</returns>
    public async Task<NordigenApiResponse<BasicResponse, BasicError>> DeleteAgreement(string id, CancellationToken cancellationToken = default)
        => await DeleteAgreementBase(id, cancellationToken);

    private async Task<NordigenApiResponse<BasicResponse, BasicError>> DeleteAgreementBase(string id, CancellationToken cancellationToken)
    {
        return await _nordigenClient.MakeRequest<BasicResponse, BasicError>($"{NordigenEndpointUrls.AgreementsEndpoint}{id}/", HttpMethod.Delete, cancellationToken);
    }

    /// <summary>
    /// Accepts an end user agreement.
    /// </summary>
    /// <param name="id">The id of the end user agreement to accept.</param>
    /// <param name="metadata">The metadata required to accept the end user agreement.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns></returns>
    public async Task<NordigenApiResponse<Agreement, BasicError>> AcceptAgreement(Guid id, AcceptAgreementRequest metadata, CancellationToken cancellationToken = default)
        => await AcceptAgreementBase(id.ToString(), metadata, cancellationToken);

    /// <summary>
    /// Accepts an end user agreement.
    /// </summary>
    /// <param name="id">The id of the end user agreement to accept.</param>
    /// <param name="metadata">The metadata required to accept the end user agreement.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns></returns>
    public async Task<NordigenApiResponse<Agreement, BasicError>> AcceptAgreement(string id, AcceptAgreementRequest metadata, CancellationToken cancellationToken = default)
        => await AcceptAgreementBase(id, metadata, cancellationToken);

    private async Task<NordigenApiResponse<Agreement, BasicError>> AcceptAgreementBase(string id, AcceptAgreementRequest metadata, CancellationToken cancellationToken)
    {
        var body = JsonContent.Create(metadata);
        return await _nordigenClient.MakeRequest<Agreement, BasicError>($"{NordigenEndpointUrls.AgreementsEndpoint}{id}/accept/", HttpMethod.Put, cancellationToken, body: body);
    }
}

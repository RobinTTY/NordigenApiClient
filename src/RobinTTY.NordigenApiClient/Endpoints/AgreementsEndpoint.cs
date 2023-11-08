using System.Net.Http.Json;
using RobinTTY.NordigenApiClient.Models.Errors;
using RobinTTY.NordigenApiClient.Models.Requests;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Endpoints;

/// <summary>
/// Provides support for the API operations of the agreements endpoint.
/// <para>Reference: <see href="https://developer.gocardless.com/bank-account-data/endpoints" /></para>
/// </summary>
public class AgreementsEndpoint
{
    private readonly NordigenClient _nordigenClient;

    /// <summary>
    /// Creates a new instance of <see cref="AgreementsEndpoint" />.
    /// </summary>
    /// <param name="client">The <see cref="NordigenClient" /> to use for token handling and request processing.</param>
    internal AgreementsEndpoint(NordigenClient client)
    {
        _nordigenClient = client;
    }

    /// <summary>
    /// Gets a <see cref="ResponsePage{T}" /> containing a given number of end user agreements.
    /// </summary>
    /// <param name="limit">Number of results to return per page.</param>
    /// <param name="offset">The initial index from which to return the results.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>
    /// A <see cref="NordigenApiResponse{TResponse, TError}" /> containing a <see cref="ResponsePage{T}" /> which
    /// contains a list of end user agreements.
    /// </returns>
    public async Task<NordigenApiResponse<ResponsePage<Agreement>, BasicError>> GetAgreements(int limit, int offset,
        CancellationToken cancellationToken = default)
    {
        var query = new KeyValuePair<string, string>[]
            {new("limit", limit.ToString()), new("offset", offset.ToString())};
        return await _nordigenClient.MakeRequest<ResponsePage<Agreement>, BasicError>(
            NordigenEndpointUrls.AgreementsEndpoint, HttpMethod.Get, cancellationToken, query);
    }

    /// <summary>
    /// Gets the end user agreement with the given id.
    /// </summary>
    /// <param name="id">The id of the agreement to retrieve.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}" /> which contains the specified end user agreements.</returns>
    public async Task<NordigenApiResponse<Agreement, BasicError>> GetAgreement(Guid id,
        CancellationToken cancellationToken = default)
    {
        return await GetAgreementInternal(id.ToString(), cancellationToken);
    }

    /// <summary>
    /// Gets the end user agreement with the given id.
    /// </summary>
    /// <param name="id">The id of the agreement to retrieve.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}" /> which contains the specified end user agreements.</returns>
    public async Task<NordigenApiResponse<Agreement, BasicError>> GetAgreement(string id,
        CancellationToken cancellationToken = default)
    {
        return await GetAgreementInternal(id, cancellationToken);
    }

    private async Task<NordigenApiResponse<Agreement, BasicError>> GetAgreementInternal(string id,
        CancellationToken cancellationToken)
    {
        return await _nordigenClient.MakeRequest<Agreement, BasicError>(
            $"{NordigenEndpointUrls.AgreementsEndpoint}{id}/", HttpMethod.Get, cancellationToken);
    }

    /// <summary>
    /// Creates a new end user agreement which determines the scope and length of access to data provided by institutions.
    /// </summary>
    /// <param name="agreement">The agreement to create.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}" /> containing the created <see cref="Agreement" />.</returns>
    public async Task<NordigenApiResponse<Agreement, CreateAgreementError>> CreateAgreement(
        CreateAgreementRequest agreement, CancellationToken cancellationToken = default)
    {
        var body = JsonContent.Create(agreement);
        return await _nordigenClient.MakeRequest<Agreement, CreateAgreementError>(
            NordigenEndpointUrls.AgreementsEndpoint, HttpMethod.Post, cancellationToken, body: body);
    }

    /// <summary>
    /// Deletes the end user agreement with the given id.
    /// </summary>
    /// <param name="id">The id of the agreement to delete.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}" /> containing a confirmation of the deletion.</returns>
    public async Task<NordigenApiResponse<BasicResponse, BasicError>> DeleteAgreement(Guid id,
        CancellationToken cancellationToken = default)
    {
        return await DeleteAgreementInternal(id.ToString(), cancellationToken);
    }

    /// <summary>
    /// Deletes the end user agreement with the given id.
    /// </summary>
    /// <param name="id">The id of the agreement to delete.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}" /> containing a confirmation of the deletion.</returns>
    public async Task<NordigenApiResponse<BasicResponse, BasicError>> DeleteAgreement(string id,
        CancellationToken cancellationToken = default)
    {
        return await DeleteAgreementInternal(id, cancellationToken);
    }

    private async Task<NordigenApiResponse<BasicResponse, BasicError>> DeleteAgreementInternal(string id,
        CancellationToken cancellationToken)
    {
        return await _nordigenClient.MakeRequest<BasicResponse, BasicError>(
            $"{NordigenEndpointUrls.AgreementsEndpoint}{id}/", HttpMethod.Delete, cancellationToken);
    }

    /// <summary>
    /// Accepts an end user agreement. Only available to customers with an enterprise contract at Nordigen.
    /// </summary>
    /// <param name="id">The id of the end user agreement to accept.</param>
    /// <param name="metadata">The metadata required to accept the end user agreement.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns></returns>
    public async Task<NordigenApiResponse<Agreement, BasicError>> AcceptAgreement(Guid id,
        AcceptAgreementRequest metadata, CancellationToken cancellationToken = default)
    {
        return await AcceptAgreementInternal(id.ToString(), metadata, cancellationToken);
    }

    /// <summary>
    /// Accepts an end user agreement. Only available to customers with an enterprise contract at Nordigen.
    /// </summary>
    /// <param name="id">The id of the end user agreement to accept.</param>
    /// <param name="metadata">The metadata required to accept the end user agreement.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns></returns>
    public async Task<NordigenApiResponse<Agreement, BasicError>> AcceptAgreement(string id,
        AcceptAgreementRequest metadata, CancellationToken cancellationToken = default)
    {
        return await AcceptAgreementInternal(id, metadata, cancellationToken);
    }

    private async Task<NordigenApiResponse<Agreement, BasicError>> AcceptAgreementInternal(string id,
        AcceptAgreementRequest metadata, CancellationToken cancellationToken)
    {
        var body = JsonContent.Create(metadata);
        return await _nordigenClient.MakeRequest<Agreement, BasicError>(
            $"{NordigenEndpointUrls.AgreementsEndpoint}{id}/accept/", HttpMethod.Put, cancellationToken, body: body);
    }
}

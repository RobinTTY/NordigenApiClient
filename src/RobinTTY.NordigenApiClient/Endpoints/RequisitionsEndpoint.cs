using System.Net.Http.Json;
using RobinTTY.NordigenApiClient.Models.Errors;
using RobinTTY.NordigenApiClient.Models.Requests;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Endpoints;

/// <summary>
/// Provides support for the API operations of the requisitions endpoint.
/// <para>Reference: <see href="https://developer.gocardless.com/bank-account-data/endpoints"/></para>
/// </summary>
public class RequisitionsEndpoint
{
    private readonly NordigenClient _nordigenClient;

    /// <summary>
    /// Creates a new instance of <see cref="RequisitionsEndpoint"/>.
    /// </summary>
    /// <param name="client">The <see cref="NordigenClient"/> to use for token handling and request processing.</param>
    internal RequisitionsEndpoint(NordigenClient client)
    {
        _nordigenClient = client;
    }

    /// <summary>
    /// Gets all requisitions belonging to your account.
    /// </summary>
    /// <param name="limit">Number of results to return per page.</param>
    /// <param name="offset">The initial index from which to return the results.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}"/> containing a <see cref="ResponsePage{T}"/> which contains a list of requisitions.</returns>
    public async Task<NordigenApiResponse<ResponsePage<Requisition>, BasicError>> GetRequisitions(int limit, int offset, CancellationToken cancellationToken = default)
    {
        var query = new KeyValuePair<string, string>[] { new("limit", limit.ToString()), new("offset", offset.ToString()) };
        return await _nordigenClient.MakeRequest<ResponsePage<Requisition>, BasicError>(NordigenEndpointUrls.RequisitionsEndpoint, HttpMethod.Get, cancellationToken, query);
    }

    /// <summary>
    /// Gets the requisition with the given id.
    /// </summary>
    /// <param name="id">The id of the requisition to retrieve.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}"/> which contains the specified requisition.</returns>
    public async Task<NordigenApiResponse<Requisition, BasicError>> GetRequisition(Guid id, CancellationToken cancellationToken = default) => await GetRequisitionInternal(id.ToString(), cancellationToken);

    /// <summary>
    /// Gets the requisition with the given id.
    /// </summary>
    /// <param name="id">The id of the requisition to retrieve.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}"/> which contains the specified requisition.</returns>
    public async Task<NordigenApiResponse<Requisition, BasicError>> GetRequisition(string id, CancellationToken cancellationToken = default) => await GetRequisitionInternal(id, cancellationToken);

    private async Task<NordigenApiResponse<Requisition, BasicError>> GetRequisitionInternal(string id, CancellationToken cancellationToken = default)
    {
        return await _nordigenClient.MakeRequest<Requisition, BasicError>($"{NordigenEndpointUrls.RequisitionsEndpoint}{id}/", HttpMethod.Get, cancellationToken);
    }

    /// <summary>
    /// Creates a new requisition which is a collection of inputs for creating links and retrieving accounts.
    /// </summary>
    /// <param name="requisition">The requisition to create.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}"/> which contains the created requisition.</returns>
    public async Task<NordigenApiResponse<Requisition, CreateRequisitionError>> CreateRequisition(CreateRequisitionRequest requisition, CancellationToken cancellationToken = default)
    {
        var body = JsonContent.Create(requisition);
        return await _nordigenClient.MakeRequest<Requisition, CreateRequisitionError>(NordigenEndpointUrls.RequisitionsEndpoint, HttpMethod.Post, cancellationToken, body: body);
    }

    /// <summary>
    /// Deletes the requisition with the given id.
    /// </summary>
    /// <param name="id">The id of the requisition to delete.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}"/> containing a confirmation of the deletion.</returns>
    public async Task<NordigenApiResponse<BasicResponse, BasicError>> DeleteRequisition(Guid id, CancellationToken cancellationToken = default)
        => await DeleteRequisitionInternal(id.ToString(), cancellationToken);

    /// <summary>
    /// Deletes the requisition with the given id.
    /// </summary>
    /// <param name="id">The id of the requisition to delete.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}"/> containing a confirmation of the deletion.</returns>
    public async Task<NordigenApiResponse<BasicResponse, BasicError>> DeleteRequisition(string id, CancellationToken cancellationToken = default)
        => await DeleteRequisitionInternal(id, cancellationToken);

    private async Task<NordigenApiResponse<BasicResponse, BasicError>> DeleteRequisitionInternal(string id, CancellationToken cancellationToken)
    {
        return await _nordigenClient.MakeRequest<BasicResponse, BasicError>($"{NordigenEndpointUrls.RequisitionsEndpoint}{id}/", HttpMethod.Delete, cancellationToken);
    }
}

using System.Net.Http.Json;
using RobinTTY.NordigenApiClient.Contracts;
using RobinTTY.NordigenApiClient.Models.Errors;
using RobinTTY.NordigenApiClient.Models.Requests;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Endpoints;

/// <inheritdoc />
public class RequisitionsEndpoint : IRequisitionsEndpoint
{
    private readonly NordigenClient _nordigenClient;

    /// <summary>
    /// Creates a new instance of <see cref="RequisitionsEndpoint" />.
    /// </summary>
    /// <param name="client">The <see cref="NordigenClient" /> to use for token handling and request processing.</param>
    internal RequisitionsEndpoint(NordigenClient client) => _nordigenClient = client;

    /// <inheritdoc />
    public async Task<NordigenApiResponse<ResponsePage<Requisition>, BasicError>> GetRequisitions(int limit, int offset,
        CancellationToken cancellationToken = default)
    {
        var query = new KeyValuePair<string, string>[]
            {new("limit", limit.ToString()), new("offset", offset.ToString())};
        return await _nordigenClient.MakeRequest<ResponsePage<Requisition>, BasicError>(
            NordigenEndpointUrls.RequisitionsEndpoint(_nordigenClient.BaseUrl), HttpMethod.Get, cancellationToken, query);
    }

    /// <inheritdoc />
    public async Task<NordigenApiResponse<Requisition, BasicError>> GetRequisition(Guid id,
        CancellationToken cancellationToken = default) =>
        await GetRequisitionInternal(id.ToString(), cancellationToken);

    /// <inheritdoc />
    public async Task<NordigenApiResponse<Requisition, BasicError>> GetRequisition(string id,
        CancellationToken cancellationToken = default) =>
        await GetRequisitionInternal(id, cancellationToken);

    private async Task<NordigenApiResponse<Requisition, BasicError>> GetRequisitionInternal(string id,
        CancellationToken cancellationToken = default) =>
        await _nordigenClient.MakeRequest<Requisition, BasicError>(
            $"{NordigenEndpointUrls.RequisitionsEndpoint(_nordigenClient.BaseUrl)}{id}/", HttpMethod.Get, cancellationToken);

    /// <inheritdoc />
    public async Task<NordigenApiResponse<Requisition, CreateRequisitionError>> CreateRequisition(
        CreateRequisitionRequest requisition, CancellationToken cancellationToken = default)
    {
        var body = JsonContent.Create(requisition);
        return await _nordigenClient.MakeRequest<Requisition, CreateRequisitionError>(
            NordigenEndpointUrls.RequisitionsEndpoint(_nordigenClient.BaseUrl), HttpMethod.Post, cancellationToken, body: body);
    }

    /// <inheritdoc />
    public async Task<NordigenApiResponse<BasicResponse, BasicError>> DeleteRequisition(Guid id,
        CancellationToken cancellationToken = default) =>
        await DeleteRequisitionInternal(id.ToString(), cancellationToken);

    /// <inheritdoc />
    public async Task<NordigenApiResponse<BasicResponse, BasicError>> DeleteRequisition(string id,
        CancellationToken cancellationToken = default) =>
        await DeleteRequisitionInternal(id, cancellationToken);

    private async Task<NordigenApiResponse<BasicResponse, BasicError>> DeleteRequisitionInternal(string id,
        CancellationToken cancellationToken) =>
        await _nordigenClient.MakeRequest<BasicResponse, BasicError>(
            $"{NordigenEndpointUrls.RequisitionsEndpoint(_nordigenClient.BaseUrl)}{id}/", HttpMethod.Delete, cancellationToken);
}

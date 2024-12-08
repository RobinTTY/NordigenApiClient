using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
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
    public async Task<NordigenApiResponse<ResponsePage<Requisition>, BasicResponse>> GetRequisitions(int limit,
        int offset, CancellationToken cancellationToken = default)
    {
        var query = new KeyValuePair<string, string>[]
            {new("limit", limit.ToString()), new("offset", offset.ToString())};
        return await _nordigenClient.MakeRequest<ResponsePage<Requisition>, BasicResponse>(
            NordigenEndpointUrls.RequisitionsEndpoint, HttpMethod.Get, cancellationToken, query);
    }

    /// <inheritdoc />
    public async Task<NordigenApiResponse<Requisition, BasicResponse>> GetRequisition(Guid id,
        CancellationToken cancellationToken = default) =>
        await GetRequisitionInternal(id.ToString(), cancellationToken);

    /// <inheritdoc />
    public async Task<NordigenApiResponse<Requisition, BasicResponse>> GetRequisition(string id,
        CancellationToken cancellationToken = default) =>
        await GetRequisitionInternal(id, cancellationToken);

    /// <inheritdoc />
    public async Task<NordigenApiResponse<Requisition, CreateRequisitionError>> CreateRequisition(string institutionId,
        Uri redirect, Guid? agreementId = null, string? reference = null, string userLanguage = "EN",
        string? socialSecurityNumber = null, bool accountSelection = false, bool redirectImmediate = false,
        CancellationToken cancellationToken = default)
    {
        var internalReference = reference ?? Guid.NewGuid().ToString();
        var requisition = new CreateRequisitionRequest(institutionId, redirect, internalReference, userLanguage,
            agreementId, socialSecurityNumber, accountSelection, redirectImmediate);
        var body = JsonContent.Create(requisition,
            options: new JsonSerializerOptions {DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull});

        return await _nordigenClient.MakeRequest<Requisition, CreateRequisitionError>(
            NordigenEndpointUrls.RequisitionsEndpoint, HttpMethod.Post, cancellationToken, body: body);
    }

    /// <inheritdoc />
    public async Task<NordigenApiResponse<BasicResponse, BasicResponse>> DeleteRequisition(Guid id,
        CancellationToken cancellationToken = default) =>
        await DeleteRequisitionInternal(id.ToString(), cancellationToken);

    /// <inheritdoc />
    public async Task<NordigenApiResponse<BasicResponse, BasicResponse>> DeleteRequisition(string id,
        CancellationToken cancellationToken = default) =>
        await DeleteRequisitionInternal(id, cancellationToken);

    private async Task<NordigenApiResponse<Requisition, BasicResponse>> GetRequisitionInternal(string id,
        CancellationToken cancellationToken = default) =>
        await _nordigenClient.MakeRequest<Requisition, BasicResponse>(
            $"{NordigenEndpointUrls.RequisitionsEndpoint}{id}/", HttpMethod.Get, cancellationToken);

    private async Task<NordigenApiResponse<BasicResponse, BasicResponse>> DeleteRequisitionInternal(string id,
        CancellationToken cancellationToken) =>
        await _nordigenClient.MakeRequest<BasicResponse, BasicResponse>(
            $"{NordigenEndpointUrls.RequisitionsEndpoint}{id}/", HttpMethod.Delete, cancellationToken);
}
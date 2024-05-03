using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using RobinTTY.NordigenApiClient.Contracts;
using RobinTTY.NordigenApiClient.Models.Errors;
using RobinTTY.NordigenApiClient.Models.Requests;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Endpoints;

/// <inheritdoc />
public class AgreementsEndpoint : IAgreementsEndpoint
{
    private readonly NordigenClient _nordigenClient;

    /// <summary>
    /// Creates a new instance of <see cref="AgreementsEndpoint" />.
    /// </summary>
    /// <param name="client">The <see cref="NordigenClient" /> to use for token handling and request processing.</param>
    internal AgreementsEndpoint(NordigenClient client) => _nordigenClient = client;

    /// <inheritdoc />
    public async Task<NordigenApiResponse<ResponsePage<Agreement>, BasicResponse>> GetAgreements(int limit, int offset,
        CancellationToken cancellationToken = default)
    {
        var query = new KeyValuePair<string, string>[]
            {new("limit", limit.ToString()), new("offset", offset.ToString())};
        return await _nordigenClient.MakeRequest<ResponsePage<Agreement>, BasicResponse>(
            NordigenEndpointUrls.AgreementsEndpoint, HttpMethod.Get, cancellationToken, query);
    }

    /// <inheritdoc />
    public async Task<NordigenApiResponse<Agreement, BasicResponse>> GetAgreement(Guid id,
        CancellationToken cancellationToken = default) =>
        await GetAgreementInternal(id.ToString(), cancellationToken);

    /// <inheritdoc />
    public async Task<NordigenApiResponse<Agreement, BasicResponse>> GetAgreement(string id,
        CancellationToken cancellationToken = default) =>
        await GetAgreementInternal(id, cancellationToken);

    /// <inheritdoc />
    public async Task<NordigenApiResponse<Agreement, CreateAgreementError>> CreateAgreement(
        CreateAgreementRequest agreement, CancellationToken cancellationToken = default)
    {
        var body = JsonContent.Create(agreement,
            options: new JsonSerializerOptions {DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull});
        return await _nordigenClient.MakeRequest<Agreement, CreateAgreementError>(
            NordigenEndpointUrls.AgreementsEndpoint, HttpMethod.Post, cancellationToken, body: body);
    }

    /// <inheritdoc />
    public async Task<NordigenApiResponse<BasicResponse, BasicResponse>> DeleteAgreement(Guid id,
        CancellationToken cancellationToken = default) =>
        await DeleteAgreementInternal(id.ToString(), cancellationToken);

    /// <inheritdoc />
    public async Task<NordigenApiResponse<BasicResponse, BasicResponse>> DeleteAgreement(string id,
        CancellationToken cancellationToken = default) =>
        await DeleteAgreementInternal(id, cancellationToken);

    /// <inheritdoc />
    public async Task<NordigenApiResponse<Agreement, BasicResponse>> AcceptAgreement(Guid id,
        AcceptAgreementRequest metadata, CancellationToken cancellationToken = default) =>
        await AcceptAgreementInternal(id.ToString(), metadata, cancellationToken);

    /// <inheritdoc />
    public async Task<NordigenApiResponse<Agreement, BasicResponse>> AcceptAgreement(string id,
        AcceptAgreementRequest metadata, CancellationToken cancellationToken = default) =>
        await AcceptAgreementInternal(id, metadata, cancellationToken);

    private async Task<NordigenApiResponse<Agreement, BasicResponse>> GetAgreementInternal(string id,
        CancellationToken cancellationToken) =>
        await _nordigenClient.MakeRequest<Agreement, BasicResponse>(
            $"{NordigenEndpointUrls.AgreementsEndpoint}{id}/", HttpMethod.Get, cancellationToken);

    private async Task<NordigenApiResponse<BasicResponse, BasicResponse>> DeleteAgreementInternal(string id,
        CancellationToken cancellationToken) =>
        await _nordigenClient.MakeRequest<BasicResponse, BasicResponse>(
            $"{NordigenEndpointUrls.AgreementsEndpoint}{id}/", HttpMethod.Delete, cancellationToken);

    private async Task<NordigenApiResponse<Agreement, BasicResponse>> AcceptAgreementInternal(string id,
        AcceptAgreementRequest metadata, CancellationToken cancellationToken)
    {
        var body = JsonContent.Create(metadata);
        return await _nordigenClient.MakeRequest<Agreement, BasicResponse>(
            $"{NordigenEndpointUrls.AgreementsEndpoint}{id}/accept/", HttpMethod.Put, cancellationToken, body: body);
    }
}

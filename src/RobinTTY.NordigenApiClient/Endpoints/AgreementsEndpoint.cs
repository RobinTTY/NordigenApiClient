using System.Net.Http.Json;
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
    public async Task<NordigenApiResponse<ResponsePage<Agreement>, BasicError>> GetAgreements(int limit, int offset,
        CancellationToken cancellationToken = default)
    {
        var query = new KeyValuePair<string, string>[]
            {new("limit", limit.ToString()), new("offset", offset.ToString())};
        return await _nordigenClient.MakeRequest<ResponsePage<Agreement>, BasicError>(
            NordigenEndpointUrls.AgreementsEndpoint(_nordigenClient.BaseUrl), HttpMethod.Get, cancellationToken, query);
    }

    /// <inheritdoc />
    public async Task<NordigenApiResponse<Agreement, BasicError>> GetAgreement(Guid id,
        CancellationToken cancellationToken = default) =>
        await GetAgreementInternal(id.ToString(), cancellationToken);

    /// <inheritdoc />
    public async Task<NordigenApiResponse<Agreement, BasicError>> GetAgreement(string id,
        CancellationToken cancellationToken = default) =>
        await GetAgreementInternal(id, cancellationToken);

    private async Task<NordigenApiResponse<Agreement, BasicError>> GetAgreementInternal(string id,
        CancellationToken cancellationToken) =>
        await _nordigenClient.MakeRequest<Agreement, BasicError>(
            $"{NordigenEndpointUrls.AgreementsEndpoint(_nordigenClient.BaseUrl)}{id}/", HttpMethod.Get, cancellationToken);

    /// <inheritdoc />
    public async Task<NordigenApiResponse<Agreement, CreateAgreementError>> CreateAgreement(
        CreateAgreementRequest agreement, CancellationToken cancellationToken = default)
    {
        var body = JsonContent.Create(agreement);
        return await _nordigenClient.MakeRequest<Agreement, CreateAgreementError>(
            NordigenEndpointUrls.AgreementsEndpoint(_nordigenClient.BaseUrl), HttpMethod.Post, cancellationToken, body: body);
    }

    /// <inheritdoc />
    public async Task<NordigenApiResponse<BasicResponse, BasicError>> DeleteAgreement(Guid id,
        CancellationToken cancellationToken = default) =>
        await DeleteAgreementInternal(id.ToString(), cancellationToken);

    /// <inheritdoc />
    public async Task<NordigenApiResponse<BasicResponse, BasicError>> DeleteAgreement(string id,
        CancellationToken cancellationToken = default) =>
        await DeleteAgreementInternal(id, cancellationToken);

    private async Task<NordigenApiResponse<BasicResponse, BasicError>> DeleteAgreementInternal(string id,
        CancellationToken cancellationToken)
    {
        return await _nordigenClient.MakeRequest<BasicResponse, BasicError>(
            $"{NordigenEndpointUrls.AgreementsEndpoint(_nordigenClient.BaseUrl)}{id}/", HttpMethod.Delete, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<NordigenApiResponse<Agreement, BasicError>> AcceptAgreement(Guid id,
        AcceptAgreementRequest metadata, CancellationToken cancellationToken = default) =>
        await AcceptAgreementInternal(id.ToString(), metadata, cancellationToken);

    /// <inheritdoc />
    public async Task<NordigenApiResponse<Agreement, BasicError>> AcceptAgreement(string id,
        AcceptAgreementRequest metadata, CancellationToken cancellationToken = default) =>
        await AcceptAgreementInternal(id, metadata, cancellationToken);

    private async Task<NordigenApiResponse<Agreement, BasicError>> AcceptAgreementInternal(string id,
        AcceptAgreementRequest metadata, CancellationToken cancellationToken)
    {
        var body = JsonContent.Create(metadata);
        return await _nordigenClient.MakeRequest<Agreement, BasicError>(
            $"{NordigenEndpointUrls.AgreementsEndpoint(_nordigenClient.BaseUrl)}{id}/accept/", HttpMethod.Put, cancellationToken, body: body);
    }
}

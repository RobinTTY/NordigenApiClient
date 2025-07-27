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
            { new("limit", limit.ToString()), new("offset", offset.ToString()) };
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
    public async Task<NordigenApiResponse<Agreement, CreateAgreementError>> CreateAgreement(string institutionId,
        uint accessValidForDays = 90, uint maxHistoricalDays = 90, List<AccessScope>? accessScope = null,
        bool reconfirmationSupported = false, CancellationToken cancellationToken = default)
    {
        var scope = accessScope ?? [AccessScope.Balances, AccessScope.Transactions, AccessScope.Details];
        var agreement = new CreateAgreementRequest(institutionId, scope, maxHistoricalDays, accessValidForDays,
            reconfirmationSupported);
        var body = JsonContent.Create(agreement,
            options: new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });

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
        string userAgent, string ipAddress, CancellationToken cancellationToken = default) =>
        await AcceptAgreementInternal(id.ToString(), userAgent, ipAddress, cancellationToken);

    /// <inheritdoc />
    public async Task<NordigenApiResponse<Agreement, BasicResponse>> AcceptAgreement(string id,
        string userAgent, string ipAddress, CancellationToken cancellationToken = default) =>
        await AcceptAgreementInternal(id, userAgent, ipAddress, cancellationToken);

    /// <inheritdoc />
    public async Task<NordigenApiResponse<Reconfirmation, BasicResponse>> GetReconfirmationDetails(Guid agreementId,
        CancellationToken cancellationToken = default) =>
        await GetReconfirmationDetailsInternal(agreementId.ToString(), cancellationToken);

    /// <inheritdoc />
    public async Task<NordigenApiResponse<Reconfirmation, BasicResponse>> GetReconfirmationDetails(string agreementId,
        CancellationToken cancellationToken = default) =>
        await GetReconfirmationDetailsInternal(agreementId, cancellationToken);

    /// <inheritdoc />
    public async Task<NordigenApiResponse<Reconfirmation, BasicResponse>> ReconfirmAgreement(Guid agreementId,
        Uri? redirect = null, CancellationToken cancellationToken = default) =>
        await ReconfirmAgreementInternal(agreementId.ToString(), redirect, cancellationToken);

    /// <inheritdoc />
    public async Task<NordigenApiResponse<Reconfirmation, BasicResponse>> ReconfirmAgreement(string agreementId,
        Uri? redirect = null,
        CancellationToken cancellationToken = default) =>
        await ReconfirmAgreementInternal(agreementId, redirect, cancellationToken);

    private async Task<NordigenApiResponse<Agreement, BasicResponse>> GetAgreementInternal(string id,
        CancellationToken cancellationToken) =>
        await _nordigenClient.MakeRequest<Agreement, BasicResponse>(
            $"{NordigenEndpointUrls.AgreementsEndpoint}{id}/", HttpMethod.Get, cancellationToken);

    private async Task<NordigenApiResponse<BasicResponse, BasicResponse>> DeleteAgreementInternal(string id,
        CancellationToken cancellationToken) =>
        await _nordigenClient.MakeRequest<BasicResponse, BasicResponse>(
            $"{NordigenEndpointUrls.AgreementsEndpoint}{id}/", HttpMethod.Delete, cancellationToken);

    private async Task<NordigenApiResponse<Agreement, BasicResponse>> AcceptAgreementInternal(string id,
        string userAgent, string ipAddress, CancellationToken cancellationToken)
    {
        var acceptAgreementRequest = new AcceptAgreementRequest(userAgent, ipAddress);
        var body = JsonContent.Create(acceptAgreementRequest);
        return await _nordigenClient.MakeRequest<Agreement, BasicResponse>(
            $"{NordigenEndpointUrls.AgreementsEndpoint}{id}/accept/", HttpMethod.Put, cancellationToken, body: body);
    }

    private async Task<NordigenApiResponse<Reconfirmation, BasicResponse>>
        GetReconfirmationDetailsInternal(string id, CancellationToken cancellationToken) =>
        await _nordigenClient.MakeRequest<Reconfirmation, BasicResponse>(
            $"{NordigenEndpointUrls.AgreementsEndpoint}{id}/reconfirm/", HttpMethod.Get, cancellationToken);

    private async Task<NordigenApiResponse<Reconfirmation, BasicResponse>>
        ReconfirmAgreementInternal(string id, Uri? redirect = null, CancellationToken cancellationToken = default)
    {
        var reconfirmAgreementRequest = new ReconfirmAgreementRequest(redirect);
        var body = JsonContent.Create(reconfirmAgreementRequest);
        return await _nordigenClient.MakeRequest<Reconfirmation, BasicResponse>(
            $"{NordigenEndpointUrls.AgreementsEndpoint}{id}/reconfirm/", HttpMethod.Post, cancellationToken,
            body: body);
    }
}
using System.Text.Json.Serialization;
using RobinTTY.NordigenApiClient.Models.Requests;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Models.Errors;

/// <summary>
/// An error description as returned by the create operation of the agreements endpoint of the Nordigen API.
/// </summary>
public class CreateAgreementError : BasicResponse
{
    /// <summary>
    /// An error that was returned related to the <see cref="CreateAgreementRequest.InstitutionId" /> property sent during
    /// the request.
    /// </summary>
    [JsonPropertyName("institution_id")]
    public BasicResponse? InstitutionIdError { get; }

    /// <summary>
    /// An error that was returned related to the <see cref="CreateAgreementRequest.AccessScope" /> property sent during
    /// the request.
    /// </summary>
    [JsonPropertyName("access_scope")]
    public BasicResponse? AccessScopeError { get; }

    /// <summary>
    /// An error that was returned related to the <see cref="CreateAgreementRequest.MaxHistoricalDays" /> property sent
    /// during the request.
    /// </summary>
    [JsonPropertyName("max_historical_days")]
    public BasicResponse? MaxHistoricalDaysError { get; }

    /// <summary>
    /// An error that was returned related to the <see cref="CreateAgreementRequest.AccessValidForDays" /> property sent
    /// during the request.
    /// </summary>
    [JsonPropertyName("access_valid_for_days")]
    public BasicResponse? AccessValidForDaysError { get; }

    /// <summary>
    /// An error that was returned related to the <see cref="CreateAgreementRequest.InstitutionId" /> property sent during
    /// the request.
    /// </summary>
    [JsonPropertyName("agreement")]
    public BasicResponse? AgreementError { get; }

    /// <summary>
    /// Creates a new instance of <see cref="CreateAgreementError" />.
    /// </summary>
    /// <param name="summary">The summary of the API error.</param>
    /// <param name="detail">The detailed description of the API error.</param>
    /// <param name="institutionIdError">
    /// An error that was returned related to the
    /// <see cref="CreateAgreementRequest.InstitutionId" /> property sent during the request.
    /// </param>
    /// <param name="accessScopeError">
    /// An error that was returned related to the
    /// <see cref="CreateAgreementRequest.AccessScope" /> property sent during the request.
    /// </param>
    /// <param name="maxHistoricalDaysError">
    /// An error that was returned related to the
    /// <see cref="CreateAgreementRequest.MaxHistoricalDays" /> property sent during the request.
    /// </param>
    /// <param name="accessValidForDaysError">
    /// An error that was returned related to the
    /// <see cref="CreateAgreementRequest.AccessValidForDays" /> property sent during the request.
    /// </param>
    /// <param name="agreementError">
    /// An error that was returned related to the
    /// <see cref="CreateAgreementRequest.InstitutionId" /> property sent during the request.
    /// </param>
    [JsonConstructor]
    public CreateAgreementError(
        string summary,
        string detail,
        BasicResponse? institutionIdError,
        BasicResponse? accessScopeError,
        BasicResponse? maxHistoricalDaysError,
        BasicResponse? accessValidForDaysError,
        BasicResponse? agreementError
    ) : base(summary, detail)
    {
        InstitutionIdError = institutionIdError;
        AccessScopeError = accessScopeError;
        MaxHistoricalDaysError = maxHistoricalDaysError;
        AccessValidForDaysError = accessValidForDaysError;
        AgreementError = agreementError;
    }
}

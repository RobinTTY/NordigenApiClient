using System.Text.Json.Serialization;
using RobinTTY.NordigenApiClient.Models.Requests;

namespace RobinTTY.NordigenApiClient.Models.Errors;

/// <summary>
/// An error description as returned by the create operation of the agreements endpoint of the Nordigen API.
/// </summary>
public class CreateAgreementError : BasicError
{
    /// <summary>
    /// An error that was returned related to the <see cref="CreateAgreementRequest.InstitutionId"/> property sent during the request.
    /// </summary>
    [JsonPropertyName("institution_id")]
    public BasicError? InstitutionIdError { get; }
    /// <summary>
    /// An error that was returned related to the <see cref="CreateAgreementRequest.AccessScope"/> property sent during the request.
    /// </summary>
    [JsonPropertyName("access_scope")]
    public BasicError? AccessScopeError { get; }
    /// <summary>
    /// An error that was returned related to the <see cref="CreateAgreementRequest.MaxHistoricalDays"/> property sent during the request.
    /// </summary>
    [JsonPropertyName("max_historical_days")]
    public BasicError? MaxHistoricalDaysError { get; }
    /// <summary>
    /// An error that was returned related to the <see cref="CreateAgreementRequest.AccessValidForDays"/> property sent during the request.
    /// </summary>
    [JsonPropertyName("access_valid_for_days")]
    public BasicError? AccessValidForDaysError { get; }
    /// <summary>
    /// An error that was returned related to the <see cref="CreateAgreementRequest.InstitutionId"/> property sent during the request.
    /// </summary>
    [JsonPropertyName("agreement")]
    public BasicError? AgreementError { get; }

    /// <summary>
    /// Creates a new instance of <see cref="CreateAgreementError"/>.
    /// </summary>
    /// <param name="summary">The summary of the API error.</param>
    /// <param name="detail">The detailed description of the API error.</param>
    /// <param name="institutionIdError">An error that was returned related to the <see cref="CreateAgreementRequest.InstitutionId"/> property sent during the request.</param>
    /// <param name="accessScopeError">An error that was returned related to the <see cref="CreateAgreementRequest.AccessScope"/> property sent during the request.</param>
    /// <param name="maxHistoricalDaysError">An error that was returned related to the <see cref="CreateAgreementRequest.MaxHistoricalDays"/> property sent during the request.</param>
    /// <param name="accessValidForDaysError">An error that was returned related to the <see cref="CreateAgreementRequest.AccessValidForDays"/> property sent during the request.</param>
    /// <param name="agreementError">An error that was returned related to the <see cref="CreateAgreementRequest.InstitutionId"/> property sent during the request.</param>
    [JsonConstructor]
    public CreateAgreementError(
        string summary,
        string detail,
        BasicError? institutionIdError,
        BasicError? accessScopeError,
        BasicError? maxHistoricalDaysError,
        BasicError? accessValidForDaysError,
        BasicError? agreementError
        ) : base(summary, detail)
    {
        InstitutionIdError = institutionIdError;
        AccessScopeError = accessScopeError;
        MaxHistoricalDaysError = maxHistoricalDaysError;
        AccessValidForDaysError = accessValidForDaysError;
        AgreementError = agreementError;
    }
}

using System.Text.Json.Serialization;
using RobinTTY.NordigenApiClient.Models.Requests;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Models.Errors;

/// <summary>
/// An error description as returned by the create operation of the requisitions endpoint of the Nordigen API.
/// </summary>
public class CreateRequisitionError : BasicResponse
{
    /// <summary>
    /// An error that was returned related to the <see cref="CreateRequisitionRequest.Reference" /> property sent during
    /// the request.
    /// </summary>
    [JsonPropertyName("reference")]
    public BasicResponse? ReferenceError { get; }

    /// <summary>
    /// An error that was returned related to the <see cref="CreateRequisitionRequest.UserLanguage" /> property sent during
    /// the request.
    /// </summary>
    [JsonPropertyName("user_language")]
    public BasicResponse? UserLanguageError { get; }

    /// <summary>
    /// An error that was returned related to the <see cref="CreateRequisitionRequest.AgreementId" /> property sent during
    /// the request.
    /// </summary>
    [JsonPropertyName("agreement")]
    public BasicResponse? AgreementError { get; }

    /// <summary>
    /// An error that was returned related to the <see cref="CreateRequisitionRequest.Redirect" /> property sent during the
    /// request.
    /// </summary>
    [JsonPropertyName("redirect")]
    public BasicResponse? RedirectError { get; }

    /// <summary>
    /// An error that was returned related to the <see cref="CreateRequisitionRequest.SocialSecurityNumber" /> property
    /// sent during the request.
    /// </summary>
    [JsonPropertyName("ssn")]
    public BasicResponse? SocialSecurityNumberError { get; }

    /// <summary>
    /// An error that was returned related to the <see cref="CreateRequisitionRequest.AccountSelection" /> property sent
    /// during the request.
    /// </summary>
    [JsonPropertyName("account_selection")]
    public BasicResponse? AccountSelectionError { get; }

    /// <summary>
    /// An error that was returned related to the <see cref="CreateRequisitionRequest.InstitutionId" /> property sent
    /// during the request.
    /// </summary>
    [JsonPropertyName("institution_id")]
    public BasicResponse? InstitutionIdError { get; }
    
    /// <summary>
    /// Creates a new instance of <see cref="CreateRequisitionError" />.
    /// </summary>
    public CreateRequisitionError(){}

    /// <summary>
    /// Creates a new instance of <see cref="CreateRequisitionError" />.
    /// </summary>
    /// <param name="summary">The summary of the API error.</param>
    /// <param name="detail">The detailed description of the API error.</param>
    /// <param name="referenceError">
    /// An error that was returned related to the
    /// <see cref="CreateRequisitionRequest.Reference" /> property sent during the request.
    /// </param>
    /// <param name="userLanguageError">
    /// An error that was returned related to the
    /// <see cref="CreateRequisitionRequest.UserLanguage" /> property sent during the request.
    /// </param>
    /// <param name="agreementError">
    /// An error that was returned related to the
    /// <see cref="CreateRequisitionRequest.AgreementId" /> property sent during the request.
    /// </param>
    /// <param name="redirectError">
    /// An error that was returned related to the <see cref="CreateRequisitionRequest.Redirect" />
    /// property sent during the request.
    /// </param>
    /// <param name="socialSecurityNumberError">
    /// An error that was returned related to the
    /// <see cref="CreateRequisitionRequest.SocialSecurityNumber" /> property sent during the request.
    /// </param>
    /// <param name="accountSelectionError">
    /// An error that was returned related to the
    /// <see cref="CreateRequisitionRequest.AccountSelection" /> property sent during the request.
    /// </param>
    /// <param name="institutionIdError">
    /// An error that was returned related to the
    /// <see cref="CreateRequisitionRequest.InstitutionId" /> property sent during the request.
    /// </param>
    [JsonConstructor]
    public CreateRequisitionError(string summary, string detail, BasicResponse? referenceError,
        BasicResponse? userLanguageError, BasicResponse? agreementError,
        BasicResponse? redirectError, BasicResponse? socialSecurityNumberError, BasicResponse? accountSelectionError,
        BasicResponse? institutionIdError) : base(summary, detail)
    {
        ReferenceError = referenceError;
        UserLanguageError = userLanguageError;
        AgreementError = agreementError;
        RedirectError = redirectError;
        SocialSecurityNumberError = socialSecurityNumberError;
        AccountSelectionError = accountSelectionError;
        InstitutionIdError = institutionIdError;
    }
}

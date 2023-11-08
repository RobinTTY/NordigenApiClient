using System.Text.Json.Serialization;
using RobinTTY.NordigenApiClient.Models.Requests;

namespace RobinTTY.NordigenApiClient.Models.Errors;

/// <summary>
///     An error description as returned by the create operation of the requisitions endpoint of the Nordigen API.
/// </summary>
public class CreateRequisitionError : BasicError
{
    /// <summary>
    ///     Creates a new instance of <see cref="CreateRequisitionError" />.
    /// </summary>
    /// <param name="summary">The summary of the API error.</param>
    /// <param name="detail">The detailed description of the API error.</param>
    /// <param name="referenceError">
    ///     An error that was returned related to the
    ///     <see cref="CreateRequisitionRequest.Reference" /> property sent during the request.
    /// </param>
    /// <param name="userLanguageError">
    ///     An error that was returned related to the
    ///     <see cref="CreateRequisitionRequest.UserLanguage" /> property sent during the request.
    /// </param>
    /// <param name="agreementError">
    ///     An error that was returned related to the
    ///     <see cref="CreateRequisitionRequest.AgreementId" /> property sent during the request.
    /// </param>
    /// <param name="redirectError">
    ///     An error that was returned related to the <see cref="CreateRequisitionRequest.Redirect" />
    ///     property sent during the request.
    /// </param>
    /// <param name="socialSecurityNumberError">
    ///     An error that was returned related to the
    ///     <see cref="CreateRequisitionRequest.SocialSecurityNumber" /> property sent during the request.
    /// </param>
    /// <param name="accountSelectionError">
    ///     An error that was returned related to the
    ///     <see cref="CreateRequisitionRequest.AccountSelection" /> property sent during the request.
    /// </param>
    /// <param name="institutionIdError">
    ///     An error that was returned related to the
    ///     <see cref="CreateRequisitionRequest.InstitutionId" /> property sent during the request.
    /// </param>
    [JsonConstructor]
    public CreateRequisitionError(string summary, string detail, BasicError? referenceError,
        BasicError? userLanguageError, BasicError? agreementError,
        BasicError? redirectError, BasicError? socialSecurityNumberError, BasicError? accountSelectionError,
        BasicError? institutionIdError) : base(summary, detail)
    {
        ReferenceError = referenceError;
        UserLanguageError = userLanguageError;
        AgreementError = agreementError;
        RedirectError = redirectError;
        SocialSecurityNumberError = socialSecurityNumberError;
        AccountSelectionError = accountSelectionError;
        InstitutionIdError = institutionIdError;
    }

    /// <summary>
    ///     An error that was returned related to the <see cref="CreateRequisitionRequest.Reference" /> property sent during
    ///     the request.
    /// </summary>
    [JsonPropertyName("reference")]
    public BasicError? ReferenceError { get; }

    /// <summary>
    ///     An error that was returned related to the <see cref="CreateRequisitionRequest.UserLanguage" /> property sent during
    ///     the request.
    /// </summary>
    [JsonPropertyName("user_language")]
    public BasicError? UserLanguageError { get; }

    /// <summary>
    ///     An error that was returned related to the <see cref="CreateRequisitionRequest.AgreementId" /> property sent during
    ///     the request.
    /// </summary>
    [JsonPropertyName("agreement")]
    public BasicError? AgreementError { get; }

    /// <summary>
    ///     An error that was returned related to the <see cref="CreateRequisitionRequest.Redirect" /> property sent during the
    ///     request.
    /// </summary>
    [JsonPropertyName("redirect")]
    public BasicError? RedirectError { get; }

    /// <summary>
    ///     An error that was returned related to the <see cref="CreateRequisitionRequest.SocialSecurityNumber" /> property
    ///     sent during the request.
    /// </summary>
    [JsonPropertyName("ssn")]
    public BasicError? SocialSecurityNumberError { get; }

    /// <summary>
    ///     An error that was returned related to the <see cref="CreateRequisitionRequest.AccountSelection" /> property sent
    ///     during the request.
    /// </summary>
    [JsonPropertyName("account_selection")]
    public BasicError? AccountSelectionError { get; }

    /// <summary>
    ///     An error that was returned related to the <see cref="CreateRequisitionRequest.InstitutionId" /> property sent
    ///     during the request.
    /// </summary>
    [JsonPropertyName("institution_id")]
    public BasicError? InstitutionIdError { get; }
}

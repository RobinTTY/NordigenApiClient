﻿using System.Text.Json.Serialization;
using RobinTTY.NordigenApiClient.JsonConverters;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Models.Errors;

/// <summary>
/// An error description as returned by the create operation of the agreements endpoint of the GoCardless API.
/// </summary>
public class CreateAgreementError : BasicResponse
{
    /// <summary>
    /// An error that was returned related to the institutionId sent during the request.
    /// </summary>
    [JsonPropertyName("institution_id")]
    [JsonConverter(typeof(StringArrayToBasicResponseConverter))]
    public BasicResponse? InstitutionIdError { get; }

    /// <summary>
    /// An error that was returned related to the accessScope property sent during the request.
    /// </summary>
    [JsonPropertyName("access_scope")]
    [JsonConverter(typeof(StringArrayToBasicResponseConverter))]
    public BasicResponse? AccessScopeError { get; }

    /// <summary>
    /// An error that was returned related to the maxHistoricalDays property sent during the request.
    /// during the request.
    /// </summary>
    [JsonPropertyName("max_historical_days")]
    [JsonConverter(typeof(StringArrayToBasicResponseConverter))]
    public BasicResponse? MaxHistoricalDaysError { get; }

    /// <summary>
    /// An error that was returned related to the accessValidForDays property sent during the request.
    /// </summary>
    [JsonPropertyName("access_valid_for_days")]
    [JsonConverter(typeof(StringArrayToBasicResponseConverter))]
    public BasicResponse? AccessValidForDaysError { get; }

    /// <summary>
    /// An error that was returned related to the institutionId property sent during the request.
    /// </summary>
    [JsonPropertyName("agreement")]
    [JsonConverter(typeof(StringArrayToBasicResponseConverter))]
    public BasicResponse? AgreementError { get; }

    /// <summary>
    /// Creates a new instance of <see cref="CreateAgreementError" />.
    /// </summary>
    public CreateAgreementError()
    {
    }

    /// <summary>
    /// Creates a new instance of <see cref="CreateAgreementError" />.
    /// </summary>
    /// <param name="summary">The summary of the API error.</param>
    /// <param name="detail">The detailed description of the API error.</param>
    /// <param name="institutionIdError">
    /// An error that was returned related to the institutionId sent during the request.
    /// </param>
    /// <param name="accessScopeError">
    /// An error that was returned related to the accessScope property sent during the request.
    /// </param>
    /// <param name="maxHistoricalDaysError">
    /// An error that was returned related to the maxHistoricalDays property sent during the request.
    /// </param>
    /// <param name="accessValidForDaysError">
    /// An error that was returned related to the accessValidForDays property sent during the request.
    /// </param>
    /// <param name="agreementError">
    /// An error that was returned related to the institutionId property sent during the request.
    /// </param>
    [JsonConstructor]
    public CreateAgreementError(
        string? summary,
        string? detail,
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
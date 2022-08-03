using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Errors;

/// <summary>
/// An error description returned by the agreements endpoint of the Nordigen API.
/// Only used for deserialization.
/// </summary>
public class AgreementsError : BasicError
{
    [JsonPropertyName("institution_id")]
    public BasicError InstitutionIdError { get; }
    [JsonPropertyName("access_scope")]
    public BasicError AccessScopeError { get; }
    [JsonPropertyName("max_historical_days")]
    public BasicError MaxHistoricalDaysError { get; }
    [JsonPropertyName("access_valid_for_days")]
    public BasicError AccessValidForDaysError { get; }
    [JsonPropertyName("agreement")]
    public BasicError AgreementError { get; }


    /// <summary>
    /// Creates a new instance of <see cref="AgreementsError"/>.
    /// </summary>
    /// <param name="summary"></param>
    /// <param name="detail"></param>
    /// <param name="institutionIdError"></param>
    /// <param name="accessScopeError"></param>
    /// <param name="maxHistoricalDaysError"></param>
    /// <param name="accessValidForDaysError"></param>
    /// <param name="agreementError"></param>
    [JsonConstructor]
    public AgreementsError(
        string summary,
        string detail,
        BasicError institutionIdError,
        BasicError accessScopeError,
        BasicError maxHistoricalDaysError,
        BasicError accessValidForDaysError,
        BasicError agreementError
        ) : base(summary, detail)
    {
        InstitutionIdError = institutionIdError;
        AccessScopeError = accessScopeError;
        MaxHistoricalDaysError = maxHistoricalDaysError;
        AccessValidForDaysError = accessValidForDaysError;
        AgreementError = agreementError;
    }
}

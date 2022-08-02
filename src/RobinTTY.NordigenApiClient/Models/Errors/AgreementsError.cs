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
    public BasicError AccessScopeErrors { get; }
    [JsonPropertyName("max_historical_days")]
    public BasicError MaxHistoricalDaysErrors { get; }
    [JsonPropertyName("access_valid_for_days")]
    public BasicError AccessValidForDaysErrors { get; }
    [JsonPropertyName("agreement")]
    public BasicError AgreementError { get; }


    /// <summary>
    /// Creates a new instance of <see cref="AgreementsError"/>.
    /// </summary>
    /// <param name="summary"></param>
    /// <param name="detail"></param>
    /// <param name="institutionIdError"></param>
    /// <param name="accessScopeErrors"></param>
    /// <param name="maxHistoricalDaysErrors"></param>
    /// <param name="accessValidForDaysErrors"></param>
    /// <param name="agreementError"></param>
    [JsonConstructor]
    public AgreementsError(
        string summary,
        string detail,
        BasicError institutionIdError,
        BasicError accessScopeErrors,
        BasicError maxHistoricalDaysErrors,
        BasicError accessValidForDaysErrors,
        BasicError agreementError
        ) : base(summary, detail)
    {
        InstitutionIdError = institutionIdError;
        AccessScopeErrors = accessScopeErrors;
        MaxHistoricalDaysErrors = maxHistoricalDaysErrors;
        AccessValidForDaysErrors = accessValidForDaysErrors;
        AgreementError = agreementError;
    }
}

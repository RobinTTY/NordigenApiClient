using RobinTTY.NordigenApiClient.Contracts;
using RobinTTY.NordigenApiClient.Models.Errors;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Endpoints;

/// <inheritdoc />
public class InstitutionsEndpoint : IInstitutionsEndpoint
{
    private readonly NordigenClient _nordigenClient;

    /// <summary>
    /// Creates a new instance of <see cref="InstitutionsEndpoint" />.
    /// </summary>
    /// <param name="client">The <see cref="NordigenClient" /> to use for token handling and request processing.</param>
    internal InstitutionsEndpoint(NordigenClient client) => _nordigenClient = client;

    /// <inheritdoc />
    public async Task<NordigenApiResponse<List<Institution>, InstitutionsError>> GetInstitutions(string? country = null,
        bool? accessScopesSupported = null, bool? accountSelectionSupported = null,
        bool? businessAccountsSupported = null,
        bool? cardAccountsSupported = null, bool? corporateAccountsSupported = null,
        bool? privateAccountsSupported = null, bool? readRefundAccountSupported = null, bool? paymentsEnabled = null,
        bool? paymentSubmissionSupported = null,
        bool? pendingTransactionsSupported = null, bool? ssnVerificationSupported = null,
        CancellationToken cancellationToken = default)
    {
        var query = new List<KeyValuePair<string, string>>();
        if (country != null) query.Add(new KeyValuePair<string, string>("country", country));
        if (accessScopesSupported.HasValue)
            query.Add(GetSupportFlagQuery("access_scopes_supported", accessScopesSupported.Value));
        if (accountSelectionSupported.HasValue)
            query.Add(GetSupportFlagQuery("account_selection_supported", accountSelectionSupported.Value));
        if (businessAccountsSupported.HasValue)
            query.Add(GetSupportFlagQuery("business_accounts_supported", businessAccountsSupported.Value));
        if (cardAccountsSupported.HasValue)
            query.Add(GetSupportFlagQuery("card_accounts_supported", cardAccountsSupported.Value));
        if (corporateAccountsSupported.HasValue)
            query.Add(GetSupportFlagQuery("corporate_accounts_supported", corporateAccountsSupported.Value));
        if (privateAccountsSupported.HasValue)
            query.Add(GetSupportFlagQuery("private_accounts_supported", privateAccountsSupported.Value));
        if (readRefundAccountSupported.HasValue)
            query.Add(GetSupportFlagQuery("read_refund_account_supported", readRefundAccountSupported.Value));
        if (paymentsEnabled.HasValue) query.Add(GetSupportFlagQuery("payments_enabled", paymentsEnabled.Value));
        if (paymentSubmissionSupported.HasValue)
            query.Add(GetSupportFlagQuery("payment_submission_supported", paymentSubmissionSupported.Value));
        if (pendingTransactionsSupported.HasValue)
            query.Add(GetSupportFlagQuery("pending_transactions_supported", pendingTransactionsSupported.Value));
        if (ssnVerificationSupported.HasValue)
            query.Add(GetSupportFlagQuery("ssn_verification_supported", ssnVerificationSupported.Value));
        return await _nordigenClient.MakeRequest<List<Institution>, InstitutionsError>(
            NordigenEndpointUrls.InstitutionsEndpoint(_nordigenClient.BaseUrl), HttpMethod.Get, cancellationToken, query);
    }

    private static KeyValuePair<string, string> GetSupportFlagQuery(string flag, bool value)
        => new(flag, value.ToString().ToLower());

    /// <inheritdoc />
    public async Task<NordigenApiResponse<Institution, BasicError>> GetInstitution(string id,
        CancellationToken cancellationToken = default) =>
        await _nordigenClient.MakeRequest<Institution, BasicError>(
            $"{NordigenEndpointUrls.InstitutionsEndpoint(_nordigenClient.BaseUrl)}{id}/", HttpMethod.Get, cancellationToken);
}

using RobinTTY.NordigenApiClient.Models.Errors;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Endpoints;

/// <summary>
/// Provides support for the API operations of the institutions endpoint.
/// <para>Reference: <see href="https://developer.gocardless.com/bank-account-data/endpoints"/></para>
/// </summary>
public class InstitutionsEndpoint
{
    private readonly NordigenClient _nordigenClient;

    /// <summary>
    /// Creates a new instance of <see cref="InstitutionsEndpoint"/>.
    /// </summary>
    /// <param name="client">The <see cref="NordigenClient"/> to use for token handling and request processing.</param>
    internal InstitutionsEndpoint(NordigenClient client)
    {
        _nordigenClient = client;
    }

    /// <summary>
    /// Gets a list of institutions supported by the Nordigen API (optionally filtered by country and supported features).
    /// </summary>
    /// <param name="country">The two-letter country code (<see href="https://wikipedia.org/wiki/ISO_3166-1">ISO 3166</see>) in which the institutions operate. Parameter won't be sent in the query if <see langword="null"/>.</param>
    /// <param name="accessScopesSupported">Whether or not access scopes are supported by this institution. Parameter won't be sent in the query if <see langword="null"/>.</param>
    /// <param name="accountSelectionSupported">Whether or not account selection is supported by this institution. Parameter won't be sent in the query if <see langword="null"/>.</param>
    /// <param name="businessAccountsSupported">Whether or not business accounts are supported by this institution. Parameter won't be sent in the query if <see langword="null"/>.</param>
    /// <param name="cardAccountsSupported">Whether or not card accounts are supported by this institution. Parameter won't be sent in the query if <see langword="null"/>.</param>
    /// <param name="corporateAccountsSupported">Whether or not corporate accounts are supported by this institution. Parameter won't be sent in the query if <see langword="null"/>.</param>
    /// <param name="privateAccountsSupported">Whether or not private accounts are supported by this institution. Parameter won't be sent in the query if <see langword="null"/>.</param>
    /// <param name="readRefundAccountSupported">Whether or not read refund account is supported by this institution. Parameter won't be sent in the query if <see langword="null"/>.</param>
    /// <param name="paymentsEnabled">Whether or not payments are enabled by this institution. Parameter won't be sent in the query if <see langword="null"/>.</param>
    /// <param name="paymentSubmissionSupported">Whether or not payment submission is supported by this institution. Parameter won't be sent in the query if <see langword="null"/>.</param>
    /// <param name="pendingTransactionsSupported">Whether or not pending transactions are supported by this institution. Parameter won't be sent in the query if <see langword="null"/>.</param>
    /// <param name="ssnVerificationSupported">Whether or not SSN verification is supported by this institution. Parameter won't be sent in the query if <see langword="null"/>.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}"/> containing a list of supported institutions if the request was successful.</returns>
    public async Task<NordigenApiResponse<List<Institution>, InstitutionsError>> GetInstitutions(string? country = null, bool? accessScopesSupported = null, bool? accountSelectionSupported = null, bool? businessAccountsSupported = null,
        bool? cardAccountsSupported = null, bool? corporateAccountsSupported = null, bool? privateAccountsSupported = null, bool? readRefundAccountSupported = null, bool? paymentsEnabled = null, bool? paymentSubmissionSupported = null, 
        bool? pendingTransactionsSupported = null, bool? ssnVerificationSupported = null, CancellationToken cancellationToken = default)
    {
        var query = new List<KeyValuePair<string, string>>();
        if (country != null) query.Add(new KeyValuePair<string, string>("country", country));
        if (accessScopesSupported.HasValue) query.Add(GetSupportFlagQuery("access_scopes_supported", accessScopesSupported.Value));
        if (accountSelectionSupported.HasValue) query.Add(GetSupportFlagQuery("account_selection_supported", accountSelectionSupported.Value));
        if (businessAccountsSupported.HasValue) query.Add(GetSupportFlagQuery("business_accounts_supported", businessAccountsSupported.Value));
        if (cardAccountsSupported.HasValue) query.Add(GetSupportFlagQuery("card_accounts_supported", cardAccountsSupported.Value));
        if (corporateAccountsSupported.HasValue) query.Add(GetSupportFlagQuery("corporate_accounts_supported", corporateAccountsSupported.Value));
        if (privateAccountsSupported.HasValue) query.Add(GetSupportFlagQuery("private_accounts_supported", privateAccountsSupported.Value));
        if (readRefundAccountSupported.HasValue) query.Add(GetSupportFlagQuery("read_refund_account_supported", readRefundAccountSupported.Value));
        if (paymentsEnabled.HasValue) query.Add(GetSupportFlagQuery("payments_enabled", paymentsEnabled.Value));
        if (paymentSubmissionSupported.HasValue) query.Add(GetSupportFlagQuery("payment_submission_supported", paymentSubmissionSupported.Value));
        if (pendingTransactionsSupported.HasValue) query.Add(GetSupportFlagQuery("pending_transactions_supported", pendingTransactionsSupported.Value));
        if (ssnVerificationSupported.HasValue) query.Add(GetSupportFlagQuery("ssn_verification_supported", ssnVerificationSupported.Value));
        return await _nordigenClient.MakeRequest<List<Institution>, InstitutionsError>(NordigenEndpointUrls.InstitutionsEndpoint, HttpMethod.Get, cancellationToken, query);
    }

    private static KeyValuePair<string, string> GetSupportFlagQuery(string flag, bool value) => new(flag, value.ToString().ToLower());

    /// <summary>
    /// Gets a specific institution by id.
    /// </summary>
    /// <param name="id">The id assigned to the institution by Nordigen (can be retrieved via <see cref="GetInstitutions"/>).</param>
    /// <param name="cancellationToken">>Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}"/> containing the institution matching the id if the request was successful.</returns>
    public async Task<NordigenApiResponse<Institution, BasicError>> GetInstitution(string id, CancellationToken cancellationToken = default)
    {
        return await _nordigenClient.MakeRequest<Institution, BasicError>($"{NordigenEndpointUrls.InstitutionsEndpoint}{id}/", HttpMethod.Get, cancellationToken);
    }
}

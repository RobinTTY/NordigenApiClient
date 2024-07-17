using RobinTTY.NordigenApiClient.Models.Requests;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Contracts;

/// <summary>
/// Provides support for the API operations of the institutions endpoint.
/// <para>
/// Reference: <a href="https://developer.gocardless.com/bank-account-data/endpoints">GoCardless Documentation</a>
/// </para>
/// </summary>
public interface IInstitutionsEndpoint
{
    /// <summary>
    /// Gets a list of institutions supported by the Nordigen API (optionally filtered by country and supported features).
    /// </summary>
    /// <param name="country">
    /// The two-letter country code (<a href="https://wikipedia.org/wiki/ISO_3166-1">ISO 3166</a>) in
    /// which the institutions operate. Parameter won't be sent in the query if <see langword="null" />.
    /// </param>
    /// <param name="accessScopesSupported">
    /// Whether or not access scopes are supported by this institution. Parameter won't be
    /// sent in the query if <see langword="null" />.
    /// </param>
    /// <param name="accountSelectionSupported">
    /// Whether or not account selection is supported by this institution. Parameter
    /// won't be sent in the query if <see langword="null" />.
    /// </param>
    /// <param name="businessAccountsSupported">
    /// Whether or not business accounts are supported by this institution. Parameter
    /// won't be sent in the query if <see langword="null" />.
    /// </param>
    /// <param name="cardAccountsSupported">
    /// Whether or not card accounts are supported by this institution. Parameter won't be
    /// sent in the query if <see langword="null" />.
    /// </param>
    /// <param name="corporateAccountsSupported">
    /// Whether or not corporate accounts are supported by this institution. Parameter
    /// won't be sent in the query if <see langword="null" />.
    /// </param>
    /// <param name="privateAccountsSupported">
    /// Whether or not private accounts are supported by this institution. Parameter
    /// won't be sent in the query if <see langword="null" />.
    /// </param>
    /// <param name="readRefundAccountSupported">
    /// Whether or not read refund account is supported by this institution. Parameter
    /// won't be sent in the query if <see langword="null" />.
    /// </param>
    /// <param name="paymentsEnabled">
    /// Whether or not payments are enabled by this institution. Parameter won't be sent in the
    /// query if <see langword="null" />.
    /// </param>
    /// <param name="paymentSubmissionSupported">
    /// Whether or not payment submission is supported by this institution. Parameter
    /// won't be sent in the query if <see langword="null" />.
    /// </param>
    /// <param name="pendingTransactionsSupported">
    /// Whether or not pending transactions are supported by this institution.
    /// Parameter won't be sent in the query if <see langword="null" />.
    /// </param>
    /// <param name="ssnVerificationSupported">
    /// Whether or not SSN verification is supported by this institution. Parameter
    /// won't be sent in the query if <see langword="null" />.
    /// </param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>
    /// A <see cref="NordigenApiResponse{TResponse, TError}" /> containing a list of supported institutions if the
    /// request was successful.
    /// </returns>
    Task<NordigenApiResponse<List<Institution>, BasicResponse>> GetInstitutions(string? country = null,
        bool? accessScopesSupported = null, bool? accountSelectionSupported = null,
        bool? businessAccountsSupported = null,
        bool? cardAccountsSupported = null, bool? corporateAccountsSupported = null,
        bool? privateAccountsSupported = null, bool? readRefundAccountSupported = null, bool? paymentsEnabled = null,
        bool? paymentSubmissionSupported = null,
        bool? pendingTransactionsSupported = null, bool? ssnVerificationSupported = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a list of institutions supported by the Nordigen API (optionally filtered by country and supported features).
    /// </summary>
    /// <param name="country">
    /// The country in which the institutions operate.
    /// </param>
    /// <param name="accessScopesSupported">
    /// Whether or not access scopes are supported by this institution. Parameter won't be
    /// sent in the query if <see langword="null" />.
    /// </param>
    /// <param name="accountSelectionSupported">
    /// Whether or not account selection is supported by this institution. Parameter
    /// won't be sent in the query if <see langword="null" />.
    /// </param>
    /// <param name="businessAccountsSupported">
    /// Whether or not business accounts are supported by this institution. Parameter
    /// won't be sent in the query if <see langword="null" />.
    /// </param>
    /// <param name="cardAccountsSupported">
    /// Whether or not card accounts are supported by this institution. Parameter won't be
    /// sent in the query if <see langword="null" />.
    /// </param>
    /// <param name="corporateAccountsSupported">
    /// Whether or not corporate accounts are supported by this institution. Parameter
    /// won't be sent in the query if <see langword="null" />.
    /// </param>
    /// <param name="privateAccountsSupported">
    /// Whether or not private accounts are supported by this institution. Parameter
    /// won't be sent in the query if <see langword="null" />.
    /// </param>
    /// <param name="readRefundAccountSupported">
    /// Whether or not read refund account is supported by this institution. Parameter
    /// won't be sent in the query if <see langword="null" />.
    /// </param>
    /// <param name="paymentsEnabled">
    /// Whether or not payments are enabled by this institution. Parameter won't be sent in the
    /// query if <see langword="null" />.
    /// </param>
    /// <param name="paymentSubmissionSupported">
    /// Whether or not payment submission is supported by this institution. Parameter
    /// won't be sent in the query if <see langword="null" />.
    /// </param>
    /// <param name="pendingTransactionsSupported">
    /// Whether or not pending transactions are supported by this institution.
    /// Parameter won't be sent in the query if <see langword="null" />.
    /// </param>
    /// <param name="ssnVerificationSupported">
    /// Whether or not SSN verification is supported by this institution. Parameter
    /// won't be sent in the query if <see langword="null" />.
    /// </param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>
    /// A <see cref="NordigenApiResponse{TResponse, TError}" /> containing a list of supported institutions if the
    /// request was successful.
    /// </returns>
    Task<NordigenApiResponse<List<Institution>, BasicResponse>> GetInstitutions(SupportedCountry country,
        bool? accessScopesSupported = null, bool? accountSelectionSupported = null,
        bool? businessAccountsSupported = null, bool? cardAccountsSupported = null,
        bool? corporateAccountsSupported = null, bool? privateAccountsSupported = null,
        bool? readRefundAccountSupported = null, bool? paymentsEnabled = null, bool? paymentSubmissionSupported = null,
        bool? pendingTransactionsSupported = null, bool? ssnVerificationSupported = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a specific institution by id.
    /// </summary>
    /// <param name="id">The id assigned to the institution by Nordigen (can be retrieved via
    /// <see cref="o:InstitutionsEndpoint.GetInstitutions" />).</param>
    /// <param name="cancellationToken">>Optional token to signal cancellation of the operation.</param>
    /// <returns>
    /// A <see cref="NordigenApiResponse{TResponse, TError}" /> containing the institution matching the id if the
    /// request was successful.
    /// </returns>
    Task<NordigenApiResponse<Institution, BasicResponse>> GetInstitution(string id,
        CancellationToken cancellationToken = default);
}

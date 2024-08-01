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
    /// If set to true filters institutions by the country in which they operate. The country has to be specified by the
    /// two-letter country code following <a href="https://wikipedia.org/wiki/ISO_3166-1">ISO 3166</a>.
    /// </param>
    /// <param name="accessScopesSupported">
    /// If set to true filters institutions by whether or not access scopes are supported.
    /// </param>
    /// <param name="accountSelectionSupported">
    /// If set to true filters institutions by whether or not account selection is supported.
    /// </param>
    /// <param name="businessAccountsSupported">
    /// If set to true filters institutions by whether or not business accounts are supported.
    /// </param>
    /// <param name="cardAccountsSupported">
    /// If set to true filters institutions by whether or not card accounts are supported by this institution.
    /// </param>
    /// <param name="corporateAccountsSupported">
    /// If set to true filters institutions by whether or not corporate accounts are supported.
    /// </param>
    /// <param name="privateAccountsSupported">
    /// If set to true filters institutions by whether or not private accounts is supported.
    /// </param>
    /// <param name="readRefundAccountSupported">
    /// If set to true filters filters institutions by whether or not read refund account is supported.
    /// </param>
    /// <param name="readDebtorAccountSupported">
    /// If set to true filters institutions by whether or not the debtor account can be read before submitting payment.
    /// </param>
    /// <param name="paymentsEnabled">
    /// If set to true filters institutions by whether or not payments are supported.
    /// </param>
    /// <param name="paymentSubmissionSupported">
    /// If set to true filters institutions by whether or not payment submission is supported.
    /// </param>
    /// <param name="pendingTransactionsSupported">
    /// If set to true filters institutions by whether or not pending transactions are supported.
    /// </param>
    /// <param name="ssnVerificationSupported">
    /// If set to true filters institutions by whether or not SSN verification is supported.
    /// </param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>
    /// A <see cref="NordigenApiResponse{TResponse, TError}" /> containing a list of supported institutions if the
    /// request was successful.
    /// </returns>
    Task<NordigenApiResponse<List<Institution>, BasicResponse>> GetInstitutions(string? country = null,
        bool? accessScopesSupported = null, bool? accountSelectionSupported = null,
        bool? businessAccountsSupported = null, bool? cardAccountsSupported = null,
        bool? corporateAccountsSupported = null, bool? privateAccountsSupported = null,
        bool? readRefundAccountSupported = null, bool? readDebtorAccountSupported = null,
        bool? paymentsEnabled = null, bool? paymentSubmissionSupported = null,
        bool? pendingTransactionsSupported = null, bool? ssnVerificationSupported = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a list of institutions supported by the Nordigen API (optionally filtered by country and supported features).
    /// </summary>
    /// <param name="country">
    /// If set to true filters institutions by the country in which they operate. The country has to be specified by the
    /// two-letter country code following <a href="https://wikipedia.org/wiki/ISO_3166-1">ISO 3166</a>.
    /// </param>
    /// <param name="accessScopesSupported">
    /// If set to true filters institutions by whether or not access scopes are supported.
    /// </param>
    /// <param name="accountSelectionSupported">
    /// If set to true filters institutions by whether or not account selection is supported.
    /// </param>
    /// <param name="businessAccountsSupported">
    /// If set to true filters institutions by whether or not business accounts are supported.
    /// </param>
    /// <param name="cardAccountsSupported">
    /// If set to true filters institutions by whether or not card accounts are supported by this institution.
    /// </param>
    /// <param name="corporateAccountsSupported">
    /// If set to true filters institutions by whether or not corporate accounts are supported.
    /// </param>
    /// <param name="privateAccountsSupported">
    /// If set to true filters institutions by whether or not private accounts is supported.
    /// </param>
    /// <param name="readRefundAccountSupported">
    /// If set to true filters filters institutions by whether or not read refund account is supported.
    /// </param>
    /// <param name="readDebtorAccountSupported">
    /// If set to true filters institutions by whether or not the debtor account can be read before submitting payment.
    /// </param>
    /// <param name="paymentsEnabled">
    /// If set to true filters institutions by whether or not payments are supported.
    /// </param>
    /// <param name="paymentSubmissionSupported">
    /// If set to true filters institutions by whether or not payment submission is supported.
    /// </param>
    /// <param name="pendingTransactionsSupported">
    /// If set to true filters institutions by whether or not pending transactions are supported.
    /// </param>
    /// <param name="ssnVerificationSupported">
    /// If set to true filters institutions by whether or not SSN verification is supported.
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
        bool? readRefundAccountSupported = null, bool? readDebtorAccountSupported = null,
        bool? paymentsEnabled = null, bool? paymentSubmissionSupported = null,
        bool? pendingTransactionsSupported = null, bool? ssnVerificationSupported = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a specific institution by id.
    /// </summary>
    /// <param name="id">The id of the institution to retrieve (can be retrieved via
    /// <see cref="o:InstitutionsEndpoint.GetInstitutions" />).</param>
    /// <param name="cancellationToken">>Optional token to signal cancellation of the operation.</param>
    /// <returns>
    /// A <see cref="NordigenApiResponse{TResponse, TError}" /> containing the institution matching the id if the
    /// request was successful.
    /// </returns>
    Task<NordigenApiResponse<Institution, BasicResponse>> GetInstitution(string id,
        CancellationToken cancellationToken = default);
}
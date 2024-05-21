using RobinTTY.NordigenApiClient.Models.Errors;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Contracts;

/// <summary>
/// Provides support for the API operations of the requisitions endpoint.
/// <para>
/// Reference: <a href="https://developer.gocardless.com/bank-account-data/endpoints">GoCardless Documentation</a>
/// </para>
/// </summary>
public interface IRequisitionsEndpoint
{
    /// <summary>
    /// Gets all requisitions belonging to your account.
    /// </summary>
    /// <param name="limit">Number of results to return per page.</param>
    /// <param name="offset">The initial index from which to return the results.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>
    /// A <see cref="NordigenApiResponse{TResponse, TError}" /> containing a <see cref="ResponsePage{T}" /> which
    /// contains a list of requisitions.
    /// </returns>
    Task<NordigenApiResponse<ResponsePage<Requisition>, BasicResponse>> GetRequisitions(int limit, int offset,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the requisition with the given id.
    /// </summary>
    /// <param name="id">The id of the requisition to retrieve.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}" /> which contains the specified requisition.</returns>
    Task<NordigenApiResponse<Requisition, BasicResponse>> GetRequisition(Guid id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the requisition with the given id.
    /// </summary>
    /// <param name="id">The id of the requisition to retrieve.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}" /> which contains the specified requisition.</returns>
    Task<NordigenApiResponse<Requisition, BasicResponse>> GetRequisition(string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new requisition which is a collection of inputs for creating links and retrieving accounts.
    /// </summary>
    /// <param name="institutionId">The id of the institution the requisition will be linked to.</param>
    /// <param name="redirect">URI where the end user will be redirected after finishing authentication.</param>
    /// <param name="agreementId">The agreement this requisition will be linked to.</param>
    /// <param name="reference">A unique ID which can be used for internal referencing. By default, set to a random
    /// <see cref="Guid" />.</param>
    /// <param name="userLanguage">Enforces a language for all end user steps hosted by GoCardless. Passed as a two-letter country code
    /// <a href="https://wikipedia.org/wiki/ISO_639-1">(ISO 639-1)</a>. For a list of all possible languages
    /// see the
    /// <a
    ///     href="https://bankaccountdata.zendesk.com/hc/en-gb/articles/11529165730332-Is-it-possible-to-change-language-for-GoCardless-consent-step">GoCardless documentation</a>
    /// .</param>
    /// <param name="socialSecurityNumber">Some European banks allow sending an end-user's SSN to check whether the SSN is valid.
    /// For bank availability see the
    /// <a href="https://nordigen.zendesk.com/hc/en-gb/articles/6761166365085-SSN-verification-feature-for-specific-banks">
    /// GoCardless
    /// Documentation
    /// </a>
    /// .
    /// </param>
    /// <param name="accountSelection">Enables the end user to select which accounts they want to share (like joint accounts, accounts of children, etc.)
    /// if set to true. For details see the
    /// <a href="https://nordigen.zendesk.com/hc/en-gb/articles/6760703821725-Account-selection-feature">
    /// GoCardless
    /// Documentation
    /// </a>
    /// .</param>
    /// <param name="redirectImmediate">Enables you to redirect end users back to your app immediately after they have given their consent to access the account
    /// information data from the bank, instead of waiting for transaction data being processed. Accounts endpoint status will be
    /// PROCESSING and you have to wait until account status is READY before you're able to query the transactions. For details see the
    /// <a
    ///     href="https://nordigen.zendesk.com/hc/en-gb/articles/6772857816477-Immediate-end-user-redirect-from-bank-after-consent">
    /// GoCardless
    /// Documentation
    /// </a>
    /// .</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}" /> which contains the created requisition.</returns>
    Task<NordigenApiResponse<Requisition, CreateRequisitionError>> CreateRequisition(string institutionId,
        Uri redirect, Guid? agreementId = null, string? reference = null, string userLanguage = "EN",
        string? socialSecurityNumber = null, bool accountSelection = false, bool redirectImmediate = false,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes the requisition with the given id.
    /// </summary>
    /// <param name="id">The id of the requisition to delete.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}" /> containing a confirmation of the deletion.</returns>
    Task<NordigenApiResponse<BasicResponse, BasicResponse>> DeleteRequisition(Guid id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes the requisition with the given id.
    /// </summary>
    /// <param name="id">The id of the requisition to delete.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}" /> containing a confirmation of the deletion.</returns>
    Task<NordigenApiResponse<BasicResponse, BasicResponse>> DeleteRequisition(string id,
        CancellationToken cancellationToken = default);
}

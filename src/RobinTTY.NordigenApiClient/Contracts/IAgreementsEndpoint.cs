using RobinTTY.NordigenApiClient.Models.Errors;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Contracts;

/// <summary>
/// Provides support for the API operations of the agreements endpoint.
/// <para>
/// Reference: <a href="https://developer.gocardless.com/bank-account-data/endpoints">GoCardless Documentation</a>
/// </para>
/// </summary>
public interface IAgreementsEndpoint
{
    /// <summary>
    /// Gets a <see cref="ResponsePage{T}" /> containing a given number of end user agreements.
    /// </summary>
    /// <param name="limit">Number of results to return per page.</param>
    /// <param name="offset">The initial index from which to return the results.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>
    /// A <see cref="NordigenApiResponse{TResponse, TError}" /> containing a <see cref="ResponsePage{T}" /> which
    /// contains a list of end user agreements.
    /// </returns>
    Task<NordigenApiResponse<ResponsePage<Agreement>, BasicResponse>> GetAgreements(int limit, int offset,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the end user agreement with the given id.
    /// </summary>
    /// <param name="id">The id of the agreement to retrieve.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}" /> which contains the specified end user agreements.</returns>
    Task<NordigenApiResponse<Agreement, BasicResponse>> GetAgreement(Guid id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the end user agreement with the given id.
    /// </summary>
    /// <param name="id">The id of the agreement to retrieve.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}" /> which contains the specified end user agreements.</returns>
    Task<NordigenApiResponse<Agreement, BasicResponse>> GetAgreement(string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new end user agreement which determines the scope and length of access to data provided by institutions.
    /// </summary>
    /// <param name="institutionId">The institution this agreement will refer to.</param>
    /// <param name="accessValidForDays">The length the access to the account will be valid for to request.</param>
    /// <param name="maxHistoricalDays">The length of the transaction history in days to request.</param>
    /// <param name="accessScope">
    /// The scope of information that will be available for access to request. By default, all access scopes
    /// (balances, transactions and details) will be requested.
    /// </param>
    /// <param name="reconfirmationSupported">Whether this agreement should be extendable. Supported by British banks only.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}" /> containing the created <see cref="Agreement" />.</returns>
    Task<NordigenApiResponse<Agreement, CreateAgreementError>> CreateAgreement(string institutionId,
        uint accessValidForDays = 90, uint maxHistoricalDays = 90, List<AccessScope>? accessScope = null,
        bool reconfirmationSupported = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes the end user agreement with the given id.
    /// </summary>
    /// <param name="id">The id of the agreement to delete.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}" /> containing a confirmation of the deletion.</returns>
    Task<NordigenApiResponse<BasicResponse, BasicResponse>> DeleteAgreement(Guid id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes the end user agreement with the given id.
    /// </summary>
    /// <param name="id">The id of the agreement to delete.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}" /> containing a confirmation of the deletion.</returns>
    Task<NordigenApiResponse<BasicResponse, BasicResponse>> DeleteAgreement(string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Accepts an end user agreement. Only available to customers with an enterprise contract at GoCardless.
    /// </summary>
    /// <param name="id">The id of the end user agreement to accept.</param>
    /// <param name="userAgent">User agent of the client that accepts the request.</param>
    /// <param name="ipAddress">IP address of the client that accepts the request.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}" /> which contains the accepted end user agreement.</returns>
    Task<NordigenApiResponse<Agreement, BasicResponse>> AcceptAgreement(Guid id, string userAgent, string ipAddress,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Accepts an end user agreement. Only available to customers with an enterprise contract at GoCardless.
    /// </summary>
    /// <param name="id">The id of the end user agreement to accept.</param>
    /// <param name="userAgent">User agent of the client that accepts the request.</param>
    /// <param name="ipAddress">IP address of the client that accepts the request.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}" /> which contains the accepted end user agreement.</returns>
    Task<NordigenApiResponse<Agreement, BasicResponse>> AcceptAgreement(string id, string userAgent, string ipAddress,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a <see cref="Reconfirmation" /> for a specific agreement. Only available to customers with an enterprise contract at GoCardless.
    /// <para>
    /// <b>Currently untested because of enterprise account requirement.
    /// Please <a href="https://github.com/RobinTTY/NordigenApiClient/issues/new">report issues</a> if you encounter them.</b>
    /// </para>
    /// </summary>
    /// <param name="agreementId">The unique identifier of the agreement to retrieve the reconfirmation details for.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>
    /// A <see cref="NordigenApiResponse{TResult, TError}" /> containing a <see cref="Reconfirmation" /> object with relevant reconfirmation details.
    /// </returns>
    Task<NordigenApiResponse<Reconfirmation, BasicResponse>> GetReconfirmationDetails(Guid agreementId,
        CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Retrieves a <see cref="Reconfirmation" /> for a specific agreement.
    /// <para>
    /// <b>Currently untested because of enterprise account requirement.
    /// Please <a href="https://github.com/RobinTTY/NordigenApiClient/issues/new">report issues</a> if you encounter them.</b>
    /// </para>
    /// </summary>
    /// <param name="agreementId">The unique identifier of the agreement to retrieve the reconfirmation details for.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>
    /// A <see cref="NordigenApiResponse{TResult, TError}" /> containing a <see cref="Reconfirmation" /> object with relevant reconfirmation details.
    /// </returns>
    Task<NordigenApiResponse<Reconfirmation, BasicResponse>> GetReconfirmationDetails(string agreementId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Reconfirms an existing agreement based on the provided identifier.
    /// <para>
    /// <b>Currently untested because of enterprise account requirement.
    /// Please <a href="https://github.com/RobinTTY/NordigenApiClient/issues/new">report issues</a> if you encounter them.</b>
    /// </para>
    /// </summary>
    /// <param name="agreementId">The unique identifier of the agreement to be reconfirmed.</param>
    /// <param name="redirect">Optional URL overriding the requisition's redirect.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>
    /// A <see cref="NordigenApiResponse{Reconfirmation, BasicResponse}" /> containing a <see cref="Reconfirmation" /> if the operation succeeds,
    /// or a <see cref="BasicResponse" /> in case of an error.
    /// </returns>
    Task<NordigenApiResponse<Reconfirmation, BasicResponse>> ReconfirmAgreement(Guid agreementId, Uri? redirect = null,
        CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Reconfirms an existing agreement based on the provided identifier.
    /// <para>
    /// <b>Currently untested because of enterprise account requirement.
    /// Please <a href="https://github.com/RobinTTY/NordigenApiClient/issues/new">report issues</a> if you encounter them.</b>
    /// </para>
    /// </summary>
    /// <param name="agreementId">The unique identifier of the agreement to be reconfirmed.</param>
    /// <param name="redirect">Optional URL overriding the requisition's redirect.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>
    /// A <see cref="NordigenApiResponse{Reconfirmation, BasicResponse}" /> containing a <see cref="Reconfirmation" /> if the operation succeeds,
    /// or a <see cref="BasicResponse" /> in case of an error.
    /// </returns>
    Task<NordigenApiResponse<Reconfirmation, BasicResponse>> ReconfirmAgreement(string agreementId, Uri? redirect = null,
        CancellationToken cancellationToken = default);
}
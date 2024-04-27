using RobinTTY.NordigenApiClient.Models.Errors;
using RobinTTY.NordigenApiClient.Models.Requests;
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
    /// <param name="agreement">The agreement to create.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}" /> containing the created <see cref="Agreement" />.</returns>
    Task<NordigenApiResponse<Agreement, CreateAgreementError>> CreateAgreement(
        CreateAgreementRequest agreement, CancellationToken cancellationToken = default);

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
    /// Accepts an end user agreement. Only available to customers with an enterprise contract at Nordigen.
    /// </summary>
    /// <param name="id">The id of the end user agreement to accept.</param>
    /// <param name="metadata">The metadata required to accept the end user agreement.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}" /> which contains the accepted end user agreement.</returns>
    Task<NordigenApiResponse<Agreement, BasicResponse>> AcceptAgreement(Guid id,
        AcceptAgreementRequest metadata, CancellationToken cancellationToken = default);

    /// <summary>
    /// Accepts an end user agreement. Only available to customers with an enterprise contract at Nordigen.
    /// </summary>
    /// <param name="id">The id of the end user agreement to accept.</param>
    /// <param name="metadata">The metadata required to accept the end user agreement.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}" /> which contains the accepted end user agreement.</returns>
    Task<NordigenApiResponse<Agreement, BasicResponse>> AcceptAgreement(string id,
        AcceptAgreementRequest metadata, CancellationToken cancellationToken = default);
}
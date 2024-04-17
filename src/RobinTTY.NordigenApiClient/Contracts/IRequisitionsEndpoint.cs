using RobinTTY.NordigenApiClient.Models.Errors;
using RobinTTY.NordigenApiClient.Models.Requests;
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
    /// <param name="requisition">The requisition to create.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}" /> which contains the created requisition.</returns>
    Task<NordigenApiResponse<Requisition, CreateRequisitionError>> CreateRequisition(
        CreateRequisitionRequest requisition, CancellationToken cancellationToken = default);

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
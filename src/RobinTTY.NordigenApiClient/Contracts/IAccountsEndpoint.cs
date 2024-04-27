using RobinTTY.NordigenApiClient.Models.Errors;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Contracts;

/// <summary>
/// Provides support for the API operations of the accounts endpoint.
/// <para>
/// Reference: <a href="https://developer.gocardless.com/bank-account-data/endpoints">GoCardless Documentation</a>
/// </para>
/// </summary>
public interface IAccountsEndpoint
{
    /// <summary>
    /// Gets the bank account with the given id.
    /// </summary>
    /// <param name="id">The id of the account to get.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}" /> which contains the specified account.</returns>
    Task<NordigenApiResponse<BankAccount, BasicResponse>> GetAccount(Guid id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the bank account with the given id.
    /// </summary>
    /// <param name="id">The id of the account to get.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}" /> which contains the specified account.</returns>
    Task<NordigenApiResponse<BankAccount, BasicResponse>> GetAccount(string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the balances of the specified account.
    /// </summary>
    /// <param name="accountId">The id of the account for which to get the balances.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}" /> which contains the balances for the specified account.</returns>
    Task<NordigenApiResponse<List<Balance>, AccountsError>> GetBalances(Guid accountId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the balances of the specified account.
    /// </summary>
    /// <param name="accountId">The id of the account for which to get the balances.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}" /> which contains the balances for the specified account.</returns>
    Task<NordigenApiResponse<List<Balance>, AccountsError>> GetBalances(string accountId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets detailed information about the specified bank account.
    /// </summary>
    /// <param name="id">The id of the account for which to retrieve the detailed information.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>
    /// A <see cref="NordigenApiResponse{TResponse, TError}" /> which contains detailed information about the
    /// specified account.
    /// </returns>
    Task<NordigenApiResponse<BankAccountDetails, AccountsError>> GetAccountDetails(Guid id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets detailed information about the specified bank account.
    /// </summary>
    /// <param name="id">The id of the account for which to retrieve the detailed information.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>
    /// A <see cref="NordigenApiResponse{TResponse, TError}" /> which contains detailed information about the
    /// specified account.
    /// </returns>
    Task<NordigenApiResponse<BankAccountDetails, AccountsError>> GetAccountDetails(string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the transactions of the specified bank account.
    /// </summary>
    /// <param name="id">The id of the account for which to retrieve the transactions.</param>
    /// <param name="startDate">Optional date to limit the transactions which are returned to those after the specified date.</param>
    /// <param name="endDate">Optional date to limit the transactions which are returned to those before the specified date.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>
    /// A <see cref="NordigenApiResponse{TResponse, TError}" /> which contains transaction data of the specified
    /// account.
    /// </returns>
#if NET6_0_OR_GREATER
    Task<NordigenApiResponse<AccountTransactions, AccountsError>> GetTransactions(Guid id,
        DateOnly? startDate = null, DateOnly? endDate = null, CancellationToken cancellationToken = default);
#else
    Task<NordigenApiResponse<AccountTransactions, AccountsError>> GetTransactions(Guid id,
        DateTime? startDate = null, DateTime? endDate = null, CancellationToken cancellationToken = default);
#endif

    /// <summary>
    /// Gets the transactions of the specified bank account.
    /// </summary>
    /// <param name="id">The id of the account for which to retrieve the transactions.</param>
    /// <param name="startDate">Optional date to limit the transactions which are returned to those after the specified date.</param>
    /// <param name="endDate">Optional date to limit the transactions which are returned to those before the specified date.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>
    /// A <see cref="NordigenApiResponse{TResponse, TError}" /> which contains transaction data of the specified
    /// account.
    /// </returns>
#if NET6_0_OR_GREATER
    Task<NordigenApiResponse<AccountTransactions, AccountsError>> GetTransactions(string id,
        DateOnly? startDate = null, DateOnly? endDate = null, CancellationToken cancellationToken = default);
#else
    Task<NordigenApiResponse<AccountTransactions, AccountsError>> GetTransactions(string id,
        DateTime? startDate = null, DateTime? endDate = null, CancellationToken cancellationToken = default);
#endif
}
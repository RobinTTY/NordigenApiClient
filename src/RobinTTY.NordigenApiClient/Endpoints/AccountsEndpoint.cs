using RobinTTY.NordigenApiClient.Models.Errors;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Endpoints;

/// <summary>
/// Provides support for the API operations of the accounts endpoint.
/// <para>Reference: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/accounts"/></para>
/// </summary>
public class AccountsEndpoint
{
    private readonly NordigenClient _nordigenClient;

    /// <summary>
    /// Creates a new instance of <see cref="AccountsEndpoint"/>.
    /// </summary>
    /// <param name="client">The <see cref="NordigenClient"/> to use for token handling and request processing.</param>
    internal AccountsEndpoint(NordigenClient client)
    {
        _nordigenClient = client;
    }

    /// <summary>
    /// Gets the bank account with the given id.
    /// <para>Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/accounts/retrieve%20account%20metadata"/></para>
    /// </summary>
    /// <param name="id">The id of the account to get.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}"/> which contains the specified account.</returns>
    public async Task<NordigenApiResponse<BankAccount, BasicError>> GetAccount(Guid id, CancellationToken cancellationToken = default)
        => await GetAccountInternal(id.ToString(), cancellationToken);

    /// <summary>
    /// Gets the bank account with the given id.
    /// <para>Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/accounts/retrieve%20account%20metadata"/></para>
    /// </summary>
    /// <param name="id">The id of the account to get.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}"/> which contains the specified account.</returns>
    public async Task<NordigenApiResponse<BankAccount, BasicError>> GetAccount(string id, CancellationToken cancellationToken = default)
        => await GetAccountInternal(id, cancellationToken);

    private async Task<NordigenApiResponse<BankAccount, BasicError>> GetAccountInternal(string id, CancellationToken cancellationToken)
    {
        return await _nordigenClient.MakeRequest<BankAccount, BasicError>($"{NordigenEndpointUrls.AccountsEndpoint}{id}/", HttpMethod.Get, cancellationToken);
    }

    /// <summary>
    /// Gets the balances of the specified account.
    /// <para>Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/accounts/accounts_balances_retrieve"/></para>
    /// </summary>
    /// <param name="accountId">The id of the account for which to get the balances.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}"/> which contains the balances for the specified account.</returns>
    public async Task<NordigenApiResponse<List<Balance>, AccountsError>> GetBalances(Guid accountId, CancellationToken cancellationToken = default)
        => await GetBalancesInternal(accountId.ToString(), cancellationToken);

    /// <summary>
    /// Gets the balances of the specified account.
    /// <para>Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/accounts/accounts_balances_retrieve"/></para>
    /// </summary>
    /// <param name="accountId">The id of the account for which to get the balances.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}"/> which contains the balances for the specified account.</returns>
    public async Task<NordigenApiResponse<List<Balance>, AccountsError>> GetBalances(string accountId, CancellationToken cancellationToken = default)
        => await GetBalancesInternal(accountId, cancellationToken);

    private async Task<NordigenApiResponse<List<Balance>, AccountsError>> GetBalancesInternal(string accountId, CancellationToken cancellationToken)
    {
        var response = await _nordigenClient.MakeRequest<BalanceJsonWrapper, AccountsError>($"{NordigenEndpointUrls.AccountsEndpoint}{accountId}/balances/", HttpMethod.Get, cancellationToken);
        return new NordigenApiResponse<List<Balance>, AccountsError>(response.StatusCode, response.IsSuccess, response.Result?.Balances, response.Error);
    }

    /// <summary>
    /// Gets detailed information about the specified bank account.
    /// <para>Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/accounts/accounts_details_retrieve"/></para>
    /// </summary>
    /// <param name="id">The id of the account for which to retrieve the detailed information.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}"/> which contains detailed information about the specified account.</returns>
    public async Task<NordigenApiResponse<BankAccountDetails, AccountsError>> GetAccountDetails(Guid id, CancellationToken cancellationToken = default)
    => await GetAccountDetailsInternal(id.ToString(), cancellationToken);

    /// <summary>
    /// Gets detailed information about the specified bank account.
    /// <para>Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/accounts/accounts_details_retrieve"/></para>
    /// </summary>
    /// <param name="id">The id of the account for which to retrieve the detailed information.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}"/> which contains detailed information about the specified account.</returns>
    public async Task<NordigenApiResponse<BankAccountDetails, AccountsError>> GetAccountDetails(string id, CancellationToken cancellationToken = default)
        => await GetAccountDetailsInternal(id, cancellationToken);

    private async Task<NordigenApiResponse<BankAccountDetails, AccountsError>> GetAccountDetailsInternal(string id, CancellationToken cancellationToken)
    {
        var response = await _nordigenClient.MakeRequest<BankAccountDetailsWrapper, AccountsError>($"{NordigenEndpointUrls.AccountsEndpoint}{id}/details/", HttpMethod.Get, cancellationToken);
        return new NordigenApiResponse<BankAccountDetails, AccountsError>(response.StatusCode, response.IsSuccess, response.Result?.Account, response.Error);
    }

    /// <summary>
    /// Gets the transactions of the specified bank account.
    /// <para>Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/accounts/accounts_transactions_retrieve"/></para>
    /// </summary>
    /// <param name="id">The id of the account for which to retrieve the transactions.</param>
    /// <param name="startDate">Optional date to limit the transactions which are returned to those after the specified date.</param>
    /// <param name="endDate">Optional date to limit the transactions which are returned to those before the specified date.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}"/> which contains transaction data of the specified account.</returns>
    public async Task<NordigenApiResponse<AccountTransactions, AccountsError>> GetTransactions(Guid id, DateOnly? startDate = null, DateOnly? endDate = null, CancellationToken cancellationToken = default)
        => await GetTransactionsInternal(id.ToString(), startDate, endDate, cancellationToken);

    /// <summary>
    /// Gets the transactions of the specified bank account.
    /// <para>Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/accounts/accounts_transactions_retrieve"/></para>
    /// </summary>
    /// <param name="id">The id of the account for which to retrieve the transactions.</param>
    /// <param name="startDate">Optional date to limit the transactions which are returned to those after the specified date.</param>
    /// <param name="endDate">Optional date to limit the transactions which are returned to those before the specified date.</param>
    /// <param name="cancellationToken">Optional token to signal cancellation of the operation.</param>
    /// <returns>A <see cref="NordigenApiResponse{TResponse, TError}"/> which contains transaction data of the specified account.</returns>
    public async Task<NordigenApiResponse<AccountTransactions, AccountsError>> GetTransactions(string id, DateOnly? startDate = null, DateOnly? endDate = null, CancellationToken cancellationToken = default)
        => await GetTransactionsInternal(id, startDate, endDate, cancellationToken);

    private async Task<NordigenApiResponse<AccountTransactions, AccountsError>> GetTransactionsInternal(string id, DateOnly? startDate, DateOnly? endDate, CancellationToken cancellationToken)
    {
        var query = new List<KeyValuePair<string, string>>();
        if (startDate != null)
            query.Add(new KeyValuePair<string, string>("date_from", DateToIso8601(startDate.Value)));
        if (endDate != null)
            query.Add(new KeyValuePair<string, string>("date_to", DateToIso8601(endDate.Value)));
            
        var response = await _nordigenClient.MakeRequest<AccountTransactionsWrapper, AccountsError>($"{NordigenEndpointUrls.AccountsEndpoint}{id}/transactions/", HttpMethod.Get, cancellationToken, query);
        return new NordigenApiResponse<AccountTransactions, AccountsError>(response.StatusCode, response.IsSuccess, response.Result?.Transactions, response.Error);
    }

    private string DateToIso8601(DateOnly date) => date.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
}

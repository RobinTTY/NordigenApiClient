using System.Globalization;
using RobinTTY.NordigenApiClient.Contracts;
using RobinTTY.NordigenApiClient.Models.Errors;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Endpoints;

/// <inheritdoc />
public class AccountsEndpoint : IAccountsEndpoint
{
    private readonly NordigenClient _nordigenClient;

    /// <summary>
    /// Creates a new instance of <see cref="AccountsEndpoint" />.
    /// </summary>
    /// <param name="client">The <see cref="NordigenClient" /> to use for token handling and request processing.</param>
    internal AccountsEndpoint(NordigenClient client) => _nordigenClient = client;

    /// <inheritdoc />
    public async Task<NordigenApiResponse<BankAccount, BasicError>> GetAccount(Guid id,
        CancellationToken cancellationToken = default) =>
        await GetAccountInternal(id.ToString(), cancellationToken);


    /// <inheritdoc />
    public async Task<NordigenApiResponse<BankAccount, BasicError>> GetAccount(string id,
        CancellationToken cancellationToken = default) =>
        await GetAccountInternal(id, cancellationToken);

    private async Task<NordigenApiResponse<BankAccount, BasicError>> GetAccountInternal(string id,
        CancellationToken cancellationToken)
    {
        return await _nordigenClient.MakeRequest<BankAccount, BasicError>(
            $"{NordigenEndpointUrls.AccountsEndpoint}{id}/", HttpMethod.Get, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<NordigenApiResponse<List<Balance>, AccountsError>> GetBalances(Guid accountId,
        CancellationToken cancellationToken = default) =>
        await GetBalancesInternal(accountId.ToString(), cancellationToken);

    /// <inheritdoc />
    public async Task<NordigenApiResponse<List<Balance>, AccountsError>> GetBalances(string accountId,
        CancellationToken cancellationToken = default) =>
        await GetBalancesInternal(accountId, cancellationToken);

    private async Task<NordigenApiResponse<List<Balance>, AccountsError>> GetBalancesInternal(string accountId,
        CancellationToken cancellationToken)
    {
        var response = await _nordigenClient.MakeRequest<BalanceJsonWrapper, AccountsError>(
            $"{NordigenEndpointUrls.AccountsEndpoint}{accountId}/balances/", HttpMethod.Get, cancellationToken);
        return new NordigenApiResponse<List<Balance>, AccountsError>(response.StatusCode, response.IsSuccess,
            response.Result?.Balances, response.Error);
    }

    /// <inheritdoc />
    public async Task<NordigenApiResponse<BankAccountDetails, AccountsError>> GetAccountDetails(Guid id,
        CancellationToken cancellationToken = default) =>
        await GetAccountDetailsInternal(id.ToString(), cancellationToken);

    /// <inheritdoc />
    public async Task<NordigenApiResponse<BankAccountDetails, AccountsError>> GetAccountDetails(string id,
        CancellationToken cancellationToken = default) =>
        await GetAccountDetailsInternal(id, cancellationToken);

    private async Task<NordigenApiResponse<BankAccountDetails, AccountsError>> GetAccountDetailsInternal(string id,
        CancellationToken cancellationToken)
    {
        var response = await _nordigenClient.MakeRequest<BankAccountDetailsWrapper, AccountsError>(
            $"{NordigenEndpointUrls.AccountsEndpoint}{id}/details/", HttpMethod.Get, cancellationToken);
        return new NordigenApiResponse<BankAccountDetails, AccountsError>(response.StatusCode, response.IsSuccess,
            response.Result?.Account, response.Error);
    }

    /// <inheritdoc />
#if NET6_0_OR_GREATER
    public async Task<NordigenApiResponse<AccountTransactions, AccountsError>> GetTransactions(Guid id,
        DateOnly? startDate = null, DateOnly? endDate = null, CancellationToken cancellationToken = default)
        => await GetTransactionsInternal(id.ToString(), startDate, endDate, cancellationToken);
#else
    public async Task<NordigenApiResponse<AccountTransactions, AccountsError>> GetTransactions(Guid id,
        DateTime? startDate = null, DateTime? endDate = null, CancellationToken cancellationToken = default)
        => await GetTransactionsInternal(id.ToString(), startDate, endDate, cancellationToken);
#endif

    /// <inheritdoc />
#if NET6_0_OR_GREATER
    public async Task<NordigenApiResponse<AccountTransactions, AccountsError>> GetTransactions(string id,
        DateOnly? startDate = null, DateOnly? endDate = null, CancellationToken cancellationToken = default)
        => await GetTransactionsInternal(id, startDate, endDate, cancellationToken);
#else
    public async Task<NordigenApiResponse<AccountTransactions, AccountsError>> GetTransactions(string id,
        DateTime? startDate = null, DateTime? endDate = null, CancellationToken cancellationToken = default)
        => await GetTransactionsInternal(id, startDate, endDate, cancellationToken);
#endif

#if NET6_0_OR_GREATER
    private async Task<NordigenApiResponse<AccountTransactions, AccountsError>> GetTransactionsInternal(string id,
        DateOnly? startDate, DateOnly? endDate, CancellationToken cancellationToken)
#else
    private async Task<NordigenApiResponse<AccountTransactions, AccountsError>> GetTransactionsInternal(string id,
        DateTime? startDate, DateTime? endDate, CancellationToken cancellationToken)
#endif
    {
        var query = new List<KeyValuePair<string, string>>();
        if (startDate != null)
            query.Add(new KeyValuePair<string, string>("date_from", DateToIso8601(startDate.Value)));
        if (endDate != null)
            query.Add(new KeyValuePair<string, string>("date_to", DateToIso8601(endDate.Value)));

        var response = await _nordigenClient.MakeRequest<AccountTransactionsWrapper, AccountsError>(
            $"{NordigenEndpointUrls.AccountsEndpoint}{id}/transactions/", HttpMethod.Get, cancellationToken, query);
        return new NordigenApiResponse<AccountTransactions, AccountsError>(response.StatusCode, response.IsSuccess,
            response.Result?.Transactions, response.Error);
    }

#if NET6_0_OR_GREATER
    private static string DateToIso8601(DateOnly date) => date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
#else
    private string DateToIso8601(DateTime date) => date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
#endif
}

using RobinTTY.NordigenApiClient.Models.Errors;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Tests.Mocks.Responses;

internal class MockResponsesModel(AccountsEndpoint accountsEndpoint)
{
    public AccountsEndpoint AccountsEndpoint { get; set; } = accountsEndpoint;
}

internal class AccountsEndpoint(
    BankAccount getAccount,
    BalanceJsonWrapper getBalances,
    BankAccountDetailsWrapper getAccountDetails,
    AccountTransactionsWrapper getTransactions,
    AccountTransactionsWrapper getTransactionRange,
    AccountsError getTransactionRangeInFuture)
{
    public BankAccount GetAccount { get; set; } = getAccount;
    public BalanceJsonWrapper GetBalances { get; set; } = getBalances;
    public BankAccountDetailsWrapper GetAccountDetails { get; set; } = getAccountDetails;
    public AccountTransactionsWrapper GetTransactions { get; set; } = getTransactions;
    public AccountTransactionsWrapper GetTransactionRange { get; set; } = getTransactionRange;
    public AccountsError GetTransactionRangeInFuture { get; set; } = getTransactionRangeInFuture;
}

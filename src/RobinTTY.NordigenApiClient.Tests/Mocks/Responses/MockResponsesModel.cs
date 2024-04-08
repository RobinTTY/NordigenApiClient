using RobinTTY.NordigenApiClient.Models.Errors;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Tests.Mocks.Responses;

internal class MockResponsesModel(
    AccountsEndpointMockData accountsEndpointMockData,
    AgreementsEndpointMockData agreementsEndpointMockData)
{
    public AccountsEndpointMockData AccountsEndpointMockData { get; set; } = accountsEndpointMockData;
    public AgreementsEndpointMockData AgreementsEndpointMockData { get; set; } = agreementsEndpointMockData;
}

internal class AccountsEndpointMockData(
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

internal class AgreementsEndpointMockData(
    ResponsePage<Agreement> getAgreements,
    Agreement createAgreement,
    Agreement getAgreement,
    BasicResponse deleteAgreement)
{
    public ResponsePage<Agreement> GetAgreements { get; set; } = getAgreements;
    public Agreement CreateAgreement { get; set; } = createAgreement;
    public Agreement GetAgreement { get; set; } = getAgreement;
    public BasicResponse DeleteAgreement { get; set; } = deleteAgreement;
}

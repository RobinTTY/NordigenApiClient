using RobinTTY.NordigenApiClient.Models.Errors;
using RobinTTY.NordigenApiClient.Models.Jwt;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Tests.Mocks.Responses;

internal class MockResponsesModel(
    AccountsEndpointMockData accountsEndpointMockData,
    AgreementsEndpointMockData agreementsEndpointMockData,
    InstitutionsEndpointMockData institutionsEndpointMockData,
    RequisitionsEndpointMockData requisitionsEndpointMockData,
    TokenEndpointMockData tokenEndpointMockData)
{
    public AccountsEndpointMockData AccountsEndpointMockData { get; set; } = accountsEndpointMockData;
    public AgreementsEndpointMockData AgreementsEndpointMockData { get; set; } = agreementsEndpointMockData;
    public InstitutionsEndpointMockData InstitutionsEndpointMockData { get; set; } = institutionsEndpointMockData;
    public RequisitionsEndpointMockData RequisitionsEndpointMockData { get; set; } = requisitionsEndpointMockData;
    public TokenEndpointMockData TokenEndpointMockData { get; set; } = tokenEndpointMockData;
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

internal class InstitutionsEndpointMockData(List<Institution> getInstitutions, Institution getInstitution)
{
    public List<Institution> GetInstitutions { get; set; } = getInstitutions;
    public Institution GetInstitution { get; set; } = getInstitution;
}

internal class RequisitionsEndpointMockData(
    ResponsePage<Requisition> getRequisitions,
    Requisition getRequisition,
    Requisition createRequisition,
    BasicResponse deleteRequisition)
{
    public ResponsePage<Requisition> GetRequisitions { get; set; } = getRequisitions;
    public Requisition GetRequisition { get; set; } = getRequisition;
    public Requisition CreateRequisition { get; set; } = createRequisition;
    public BasicResponse DeleteRequisition { get; set; } = deleteRequisition;
}

internal class TokenEndpointMockData(
    JsonWebTokenPair getNewToken,
    JsonWebAccessToken refreshAccessToken,
    BasicResponse noActiveAccountForGivenCredentialsError)
{
    public JsonWebTokenPair GetNewToken { get; set; } = getNewToken;
    public JsonWebAccessToken RefreshAccessToken { get; set; } = refreshAccessToken;
    public BasicResponse NoActiveAccountForGivenCredentialsError { get; set; } = noActiveAccountForGivenCredentialsError;
}

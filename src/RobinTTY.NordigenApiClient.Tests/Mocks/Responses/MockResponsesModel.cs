using RobinTTY.NordigenApiClient.Models.Errors;
using RobinTTY.NordigenApiClient.Models.Jwt;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Tests.Mocks.Responses;

internal class MockResponsesModel(
    AccountsEndpointMockData accountsEndpointMockData,
    AgreementsEndpointMockData agreementsEndpointMockData,
    InstitutionsEndpointMockData institutionsEndpointMockData,
    RequisitionsEndpointMockData requisitionsEndpointMockData,
    TokenEndpointMockData tokenEndpointMockData,
    CredentialMockData credentialMockData)
{
    public AccountsEndpointMockData AccountsEndpointMockData { get; set; } = accountsEndpointMockData;
    public AgreementsEndpointMockData AgreementsEndpointMockData { get; set; } = agreementsEndpointMockData;
    public InstitutionsEndpointMockData InstitutionsEndpointMockData { get; set; } = institutionsEndpointMockData;
    public RequisitionsEndpointMockData RequisitionsEndpointMockData { get; set; } = requisitionsEndpointMockData;
    public TokenEndpointMockData TokenEndpointMockData { get; set; } = tokenEndpointMockData;
    public CredentialMockData CredentialMockData { get; set; } = credentialMockData;
}

internal class AccountsEndpointMockData(
    BankAccount getAccount,
    BalanceJsonWrapper getBalances,
    BankAccountDetailsWrapper getAccountDetails,
    AccountTransactionsWrapper getTransactions,
    AccountTransactionsWrapper getTransactionRange,
    AccountsError getTransactionRangeInFuture,
    AccountsError getAccountWithInvalidGuid,
    AccountsError getAccountThatDoesNotExist,
    AccountsError getBalancesForAccountThatDoesNotExist)
{
    public BankAccount GetAccount { get; set; } = getAccount;
    public BalanceJsonWrapper GetBalances { get; set; } = getBalances;
    public BankAccountDetailsWrapper GetAccountDetails { get; set; } = getAccountDetails;
    public AccountTransactionsWrapper GetTransactions { get; set; } = getTransactions;
    public AccountTransactionsWrapper GetTransactionRange { get; set; } = getTransactionRange;
    public AccountsError GetTransactionRangeInFuture { get; set; } = getTransactionRangeInFuture;
    public AccountsError GetAccountWithInvalidGuid { get; set; } = getAccountWithInvalidGuid;
    public AccountsError GetAccountThatDoesNotExist { get; set; } = getAccountThatDoesNotExist;
    public AccountsError GetBalancesForAccountThatDoesNotExist { get; set; } = getBalancesForAccountThatDoesNotExist;
}

internal class AgreementsEndpointMockData(
    ResponsePage<Agreement> getAgreements,
    Agreement createAgreement,
    Agreement getAgreement,
    BasicResponse deleteAgreement,
    BasicResponse getAgreementWithInvalidGuid,
    CreateAgreementError createAgreementWithInvalidInstitutionId,
    CreateAgreementError createAgreementWithInvalidParams,
    CreateAgreementError createAgreementWithInvalidParamsAtPolishInstitution)
{
    public ResponsePage<Agreement> GetAgreements { get; set; } = getAgreements;
    public Agreement CreateAgreement { get; set; } = createAgreement;
    public Agreement GetAgreement { get; set; } = getAgreement;
    public BasicResponse DeleteAgreement { get; set; } = deleteAgreement;

    public BasicResponse GetAgreementWithInvalidGuid { get; set; } = getAgreementWithInvalidGuid;

    public CreateAgreementError CreateAgreementWithInvalidInstitutionId { get; set; } =
        createAgreementWithInvalidInstitutionId;

    public CreateAgreementError CreateAgreementWithInvalidParams { get; set; } = createAgreementWithInvalidParams;

    public CreateAgreementError CreateAgreementWithInvalidParamsAtPolishInstitution { get; set; } =
        createAgreementWithInvalidParamsAtPolishInstitution;
}

internal class InstitutionsEndpointMockData(
    List<Institution> getInstitutions,
    Institution getInstitution,
    InstitutionsErrorInternal getInstitutionsForNotCoveredCountry,
    BasicResponse getNonExistingInstitution)
{
    public List<Institution> GetInstitutions { get; set; } = getInstitutions;
    public Institution GetInstitution { get; set; } = getInstitution;
    public InstitutionsErrorInternal GetInstitutionsForNotCoveredCountry { get; set; } = getInstitutionsForNotCoveredCountry;
    public BasicResponse GetNonExistingInstitution { get; set; } = getNonExistingInstitution;
}

internal class RequisitionsEndpointMockData(
    ResponsePage<Requisition> getRequisitions,
    Requisition getRequisition,
    Requisition createRequisition,
    BasicResponse deleteRequisition,
    BasicResponse getRequisitionWithInvalidGuid,
    CreateRequisitionError createRequisitionWithInvalidId,
    CreateRequisitionError createRequisitionWithInvalidParameters)
{
    public ResponsePage<Requisition> GetRequisitions { get; set; } = getRequisitions;
    public Requisition GetRequisition { get; set; } = getRequisition;
    public Requisition CreateRequisition { get; set; } = createRequisition;
    public BasicResponse DeleteRequisition { get; set; } = deleteRequisition;
    public BasicResponse GetRequisitionWithInvalidGuid { get; set; } = getRequisitionWithInvalidGuid;
    public CreateRequisitionError CreateRequisitionWithInvalidId { get; set; } = createRequisitionWithInvalidId;

    public CreateRequisitionError CreateRequisitionWithInvalidParameters { get; set; } =
        createRequisitionWithInvalidParameters;
}

internal class TokenEndpointMockData(
    JsonWebTokenPair getNewToken,
    JsonWebAccessToken refreshAccessToken)
{
    public JsonWebTokenPair GetNewToken { get; set; } = getNewToken;
    public JsonWebAccessToken RefreshAccessToken { get; set; } = refreshAccessToken;
}

internal class CredentialMockData(BasicResponse noAccountForGivenCredentialsError, BasicResponse ipNotWhitelistedError)
{
    public BasicResponse NoAccountForGivenCredentialsError { get; set; } = noAccountForGivenCredentialsError;
    public BasicResponse IpNotWhitelistedError { get; set; } = ipNotWhitelistedError;
}

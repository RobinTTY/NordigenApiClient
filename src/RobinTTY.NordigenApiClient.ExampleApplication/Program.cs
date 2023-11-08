using RobinTTY.NordigenApiClient;
using RobinTTY.NordigenApiClient.Models;
using RobinTTY.NordigenApiClient.Models.Requests;

// Create the client used to access the API
using var httpClient = new HttpClient();
var credentials = new NordigenClientCredentials("my-secret-id", "my-secret-key");
var client = new NordigenClient(httpClient, credentials);

////* Getting balances and transactions for a bank account */////
// 1. Get a list of institutions in your country (e.g. Great Britain):
var institutionsResponse = await client.InstitutionsEndpoint.GetInstitutions("GB");
if (institutionsResponse.IsSuccess)
    institutionsResponse.Result.ForEach(institution =>
    {
        Console.WriteLine($"Institution: {institution.Name}, Id: {institution.Id}");
    });
else
    Console.WriteLine($"Couldn't retrieve institutions, error: {institutionsResponse.Error.Summary}");

// 2. Choose the institution your bank account is registered with and create a requisition for it:

var institution = "BANK_OF_SCOTLAND_BOFSGBS1";
var userLanguage = "EN";
var reference = "your-internal-reference";
var redirect = new Uri("https://where-nordigen-will-redirect-after-authentication.com");
var requisitionRequest = new CreateRequisitionRequest(redirect, institution, reference, userLanguage);
var requisitionResponse = await client.RequisitionsEndpoint.CreateRequisition(requisitionRequest);

if (requisitionResponse.IsSuccess)
{
    Console.WriteLine($"Requisition id: {requisitionResponse.Result.Id}");
    Console.WriteLine($"Start authentication: {requisitionResponse.Result.AuthenticationLink}");
}

else
{
    Console.WriteLine($"Requisition couldn't be created: {requisitionResponse.Error.Summary}");
}

// 3. You will now need to accept the end user agreement by following the authentication link.
// After that you will be able to retrieve the accounts linked to your bank account:

var requisitionId = "your-requisition-id";
var accountsResponse = await client.RequisitionsEndpoint.GetRequisition(requisitionId);
if (accountsResponse.IsSuccess)
    accountsResponse.Result.Accounts.ForEach(accountId => { Console.WriteLine($"Account id: {accountId}"); });
else
    Console.WriteLine($"Accounts couldn't be retrieved: {accountsResponse.Error.Summary}");

// 4. Now you can retrieve details about the bank account and the balances/transactions:

var accountId = "your-account-id";
var bankAccountDetailsResponse = await client.AccountsEndpoint.GetAccountDetails(accountId);
if (bankAccountDetailsResponse.IsSuccess)
{
    Console.WriteLine($"IBAN: {bankAccountDetailsResponse.Result.Iban}");
    Console.WriteLine($"Account name: {bankAccountDetailsResponse.Result.Name}");
}

var balancesResponse = await client.AccountsEndpoint.GetBalances(accountId);
if (balancesResponse.IsSuccess)
    balancesResponse.Result.ForEach(balance =>
    {
        var balanceAmount = balance.BalanceAmount;
        Console.WriteLine($"Type: {balance.BalanceType}");
        Console.WriteLine($"Balance: {balanceAmount.Amount} {balanceAmount.Currency}");
    });

var transactionsResponse = await client.AccountsEndpoint.GetTransactions(accountId);
if (transactionsResponse.IsSuccess)
    transactionsResponse.Result.BookedTransactions.ForEach(transaction =>
    {
        var transactionAmount = transaction.TransactionAmount;
        Console.WriteLine($"Remittance: {transaction.RemittanceInformationUnstructured}");
        Console.WriteLine($"Booking date:{transaction.ValueDate}");
        Console.WriteLine($"Amount: {transactionAmount.Amount} {transactionAmount.Currency}");
    });

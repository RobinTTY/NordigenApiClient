---
sidebar_position: 2
title: The Quickstart Guide
---

You are looking to integrate with the GoCardless API quickly? This guide will help you getting your first real bank account data in no time.

:::info
To get a more thorough understanding of this client and its capabilities, please refer to the [full documentation](/docs/intro), which will lead you through the different endpoints and their usage.
:::

1. To get started install the package via the package manager:

   ```powershell
   Install-Package RobinTTY.NordigenApiClient
   ```

2. Next you need to create a new instance of the client:

   ```cs
   using var httpClient = new HttpClient();
   var credentials = new NordigenClientCredentials("my-secret-id", "my-secret-key");
   var client = new NordigenClient(httpClient, credentials);
   ```

   Note: The client will obtain the required JWT access/refresh token itself and manage it accordingly, for
   access/refresh token reuse see the advanced section.

3. You can now use the different endpoints through the client:

   ```cs
   var response = await client.InstitutionsEndpoint.GetInstitutions(country: "GB");
   ```

   The responses that are returned always have the same structure:

   ```cs
   // If the request was successful "Result" will contain the returned data (Error will be null)
   if(response.IsSuccess){
      var institutions = response.Result;
      institutions.ForEach(institution => Console.WriteLine(institution.Name));
   }
   // If the request was not successful "Error" will contain the reason it failed (Result will be null)
   else
      Console.WriteLine(response.Error.Summary);
   ```

## Getting balances and transactions for a bank account

Here is how you would go about retrieving the balances and transactions for a bank account (you can find this full
example [here](https://github.com/RobinTTY/NordigenApiClient/tree/main/src/RobinTTY.NordigenApiClient.ExampleApplication)):

### 1. Get a list of institutions in your country

```cs
var institutionsResponse = await client.InstitutionsEndpoint.GetInstitutions(country: "GB");
if (institutionsResponse.IsSuccess)
    institutionsResponse.Result.ForEach(institution =>
    {
        Console.WriteLine($"Institution: {institution.Name}, Id: {institution.Id}");
    });
else
    Console.WriteLine($"Couldn't retrieve institutions, error: {institutionsResponse.Error.Summary}");
```

### 2. Create a requisition for a bank account

```cs
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
    Console.WriteLine($"Requisition couldn't be created: {requisitionResponse.Error.Summary}");
```

### 3. Accept the end user agreement

TODO

### 4. Retrieve the accounts associated with the requisition

```cs
var requisitionId = "your-requisition-id";
var accountsResponse = await client.RequisitionsEndpoint.GetRequisition(requisitionId);
if (accountsResponse.IsSuccess)
    accountsResponse.Result.Accounts.ForEach(accountId =>
    {
        Console.WriteLine($"Account id: {accountId}");
    });
else
    Console.WriteLine($"Accounts couldn't be retrieved: {accountsResponse.Error.Summary}");
```

### 5. Retrieve details, balances and transactions of the account

```cs
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
```

That's it! You are now able to retrieve the balances, transactions and details of a bank account. If you wanna learn more about this library please refer to the [full documentation](/docs/intro).

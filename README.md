# NordigenApiClient

This project provides a C# client for the [Nordigen API](https://www.nordigen.com/). The project targets .NET 6/7 & .NET Standard 2.0 and supports the following endpoints of the API:

- Token
- Institutions
- Agreements
- Requisitions
- Accounts

## Getting started

1. To get started install the package via the package manager:

   ```ps
   Install-Package RobinTTY.NordigenApiClient
   ```

2. Next you need to create a new instance of the client:

   ```cs
   using var httpClient = new HttpClient();
   var credentials = new NordigenClientCredentials("my-secret-id", "my-secret-key");
   var client = new NordigenClient(httpClient, credentials);
   ```

   Note: The client will obtain the required JWT access/refresh token itself and manage it accordingly, for access/refresh token reuse see the advanced section.

3. You can now use the different endpoints through the client:

   ```cs
   var response = await client.InstitutionsEndpoint.GetInstitutions(country: "GB");
   ```

   The responses that are returned always have the same structure:

   ```cs
   // If the response is successful the Result will not be null (the Error will be null)
   if(response.IsSuccess){
      var institutions = response.Result!;
      institutions.ForEach(institution => Console.WriteLine(institution.Name));
   }
   // If the response is not successful the Error will not be null (the Result will be null)
   else
      Console.WriteLine(response.Error!.Summary);
   ```

## Getting balances and transactions for a bank account

Here is how you would go about retrieving the balances and transactions for a bank account:

1. Get a list of institutions in your country (e.g. Great Britain):

   ```cs
   var institutionsResponse = await client.InstitutionsEndpoint.GetInstitutions(country: "GB");
   if(institutionsResponse.IsSuccess)
      institutionsResponse.Result!.ForEach(institution =>
      {
          Console.WriteLine($"Institution: {institution.Name}, Id: {institution.Id}");
      });
   else
      Console.WriteLine($"Couldn't retrieve institutions, error: {institutionsResponse.Error!.Summary}");
   ```

2. Choose the institution your bank account is registered with and create a requisition for it:

   ```cs
   var institution = "BANK_OF_SCOTLAND_BOFSGBS1";
   var userLanguage = "EN";
   var reference = "your-internal-reference";
   var redirect = new Uri("https://where-nordigen-will-redirect-after-authentication.com");
   var requisitionRequest = new CreateRequisitionRequest(redirect, institution, reference, userLanguage);
   var requisitionResponse = await client.RequisitionsEndpoint.CreateRequisition(requisitionRequest);

    if (requisitionResponse.IsSuccess)
    {
        Console.WriteLine($"Requisition id: {requisitionResponse.Result!.Id}");
        Console.WriteLine($"Start authentication: {requisitionResponse.Result!.AuthenticationLink}");
    }

    else
        Console.WriteLine($"Requisition couldn't be created: {requisitionResponse.Error!.Summary}");
   ```

3. You will now need to accept the end user agreement by following the authentication link. After that you will be able to retrieve the accounts linked to your bank account:

   ```cs
   var requisitionId = "your-requisition-id";
   var accountsResponse = await client.RequisitionsEndpoint.GetRequisition(requisitionId);
   if(accountsResponse.IsSuccess)
       accountsResponse.Result!.Accounts.ForEach(accountId =>
       {
            Console.WriteLine($"Account id: {accountId}");
       });
   else
       Console.WriteLine($"Accounts couldn't be retrieved: {accountsResponse.Error!.Summary}");
   ```

4. Now you can retrieve details about the bank account and the balances/transactions:

   ```cs
   var accountId = "your-account-id";
   var bankAccountDetailsResponse = await client.AccountsEndpoint.GetAccountDetails(accountId);
   if(bankAccountDetailsResponse.IsSuccess)
   {
        Console.WriteLine($"IBAN: {bankAccountDetailsResponse.Result!.Iban}");
        Console.WriteLine($"Account name: {bankAccountDetailsResponse.Result!.Name}");
   }

   var balancesResponse = await client.AccountsEndpoint.GetBalances(accountId);
   if(balancesResponse.IsSuccess)
       balancesResponse.Result!.ForEach(balance =>
       {
           var balanceAmount = balance.BalanceAmount;
           Console.WriteLine($"Type: {balance.BalanceType}");
           Console.WriteLine($"Balance: {balanceAmount.AmountParsed} {balanceAmount.Currency}");
       });

   var transactionsResponse = await client.AccountsEndpoint.GetTransactions(accountId);
   if (transactionsResponse.IsSuccess)
       transactionsResponse.Result!.BookedTransactions.ForEach(transaction =>
       {
           var transactionAmount = transaction.TransactionAmount;
           Console.WriteLine($"Remittance: {transaction.RemittanceInformationUnstructured}");
           Console.WriteLine($"Booking date:{transaction.ValueDate}");
           Console.WriteLine($"Amount: {transactionAmount.AmountParsed} {transactionAmount.Currency}");
       });
   ```

## Advanced Usage

### Acess/Refresh Token reuse

If you wan't to persist the access/refresh token used by the client you can do so by accessing the `JsonWebTokenPair` property of the client. After the first request that requires authentication this property will be populated with the access/refresh token that was automatically aquired.

```cs
Console.WriteLine(client.JsonWebTokenPair.AccessToken.EncodedToken);
Console.WriteLine(client.JsonWebTokenPair.RefreshToken.EncodedToken);
```

The next time you instantiate the client you can pass the access/refresh token to the client constructor:

```cs
using var httpClient = new HttpClient();
var credentials = new NordigenClientCredentials("my-secret-id", "my-secret-key");
var tokenPair = new JsonWebTokenPair("encoded-access-token", "encoded-refresh-token");
var client = new NordigenClient(httpClient, credentials, tokenPair);
```

The client will now use the given token pair and refresh it automatically if it is expired.

Alternatively you can also use the tokens endpoint directly:

```cs
var response = await client.TokenEndpoint.GetTokenPair();
if (response.IsSuccess)
{
    Console.WriteLine($"Access token: {response.Result!.AccessToken.EncodedToken}");
    Console.WriteLine($"Refresh token: {response.Result!.RefreshToken.EncodedToken}");
}

// Set the token pair on the client
client.JsonWebTokenPair = response.Result;
```

To get notified whenever the token pair is updated you can subscribe to the ```TokenPairUpdated``` event:

```cs
client.TokenPairUpdated += OnTokenPairUpdated;

void OnTokenPairUpdated(object? sender, TokenPairUpdatedEventArgs e)
{
    // The event args contain the updated token
    Console.WriteLine("Updated token pair:");
    Console.WriteLine($"Access Token: {e.JsonWebTokenPair!.AccessToken.EncodedToken}");
    Console.WriteLine($"Refresh Token: {e.JsonWebTokenPair!.RefreshToken.EncodedToken}");
}
```

## Usage with Frameworks older than .NET 6.0

If you use this library with .NET versions older than 6.0 you will receive warnings informing you that various dependencies of this packet don't necessarily support your chosen .NET version. The .NET Standard version of this package is tested against .NET Framework 4.8 and other versions (including .NET Core) should work fine as well. You can surpress those warnings by adding the following option to your csproj file:

```xml
<PropertyGroup>
   ...
   <SuppressTfmSupportBuildWarnings>true</SuppressTfmSupportBuildWarnings>
   ...
</PropertyGroup>
```

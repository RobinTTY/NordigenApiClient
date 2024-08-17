---
title: AccountsEndpoint
---

The `AccountsEndpoint` class provides support for the API operations of the accounts endpoint.

## Methods

### `GetAccount`

Gets the bank account with the given id.

```csharp
public async Task<NordigenApiResponse<BankAccount, BasicResponse>>
  GetAccount(Guid id, CancellationToken cancellationToken = default)
```

Overloaded `id` parameter using the `string` type:

```csharp
public async Task<NordigenApiResponse<BankAccount, BasicResponse>>
  GetAccount(string id, CancellationToken cancellationToken = default)
```

#### Parameters

##### `id` - [Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid) | [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

The id of the account to get.

##### `cancellationToken` - [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)

A token to signal cancellation of the operation.

#### Returns

[Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)\<[NordigenApiResponse](/docs/api-reference/responses/nordigen-api-response)\<[BankAccount](/docs/api-reference/responses/bank-account), [BasicResponse](/docs/api-reference/responses/basic-response)\>\>

A `NordigenApiResponse` which contains the specified account if the request was successful.

### `GetBalances`

Gets the balances of the specified account.

```csharp
public async Task<NordigenApiResponse<List<Balance>, AccountsError>>
  GetBalances(Guid accountId, CancellationToken cancellationToken = default)
```

Overloaded `id` parameter using the `string` type:

```csharp
public async Task<NordigenApiResponse<List<Balance>, AccountsError>>
  GetBalances(Guid accountId, CancellationToken cancellationToken = default)
```

#### Parameters

##### `id` - [Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid) | [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

The id of the account for which to get the balances.

##### `cancellationToken` - [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)

A token to signal cancellation of the operation.

#### Returns

[Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)\<[NordigenApiResponse](/docs/api-reference/responses/nordigen-api-response)\<[List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)\<[Balance](/docs/api-reference/responses/balance)\>, [AccountsError](/docs/api-reference/errors/accounts-error)\>\>

A `NordigenApiResponse` which contains which contains a list of the balances for the specified account if the request was successful.

### `GetAccountDetails`

Gets detailed information about the specified bank account.

```csharp
public async Task<NordigenApiResponse<BankAccountDetails, AccountsError>>
  GetAccountDetails(Guid id, CancellationToken cancellationToken = default)
```

Overloaded `id` parameter using the `string` type:

```csharp
public async Task<NordigenApiResponse<BankAccountDetails, AccountsError>>
  GetAccountDetails(string id, CancellationToken cancellationToken = default)
```

#### Parameters

##### `id` - [Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid) | [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

The id of the account for which to retrieve the detailed information.

##### `cancellationToken` - [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)

A token to signal cancellation of the operation.

#### Returns

[Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)\<[NordigenApiResponse](/docs/api-reference/responses/nordigen-api-response)\<[BankAccountDetails](/docs/api-reference/responses/bank-account-details), [AccountsError](/docs/api-reference/errors/accounts-error)\>\>

A `NordigenApiResponse` which contains detailed information about the specified account if the request was successful.

### `GetTransactions`

Gets the transactions of the specified bank account.

```csharp
public async Task<NordigenApiResponse<AccountTransactions, AccountsError>>
  GetTransactions(Guid id, DateOnly? startDate = null, DateOnly? endDate = null,
        CancellationToken cancellationToken = default)
```

Overloaded `id` parameter using the `string` type:

```csharp
public async Task<NordigenApiResponse<AccountTransactions, AccountsError>>
  GetTransactions(string id, DateOnly? startDate = null, DateOnly? endDate = null,
        CancellationToken cancellationToken = default)
```

:::warning
If you are consuming the .NET Standard version of the library the parameters `startDate` and `endDate` will be of type [`DateTime`](https://learn.microsoft.com/en-us/dotnet/api/system.datetime).
:::

#### Parameters

##### `id` - [Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid) | [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

The id of the account for which to retrieve the transactions.

##### `startDate` - [DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly) | [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

Optional date to limit the transactions which are returned to those after the specified date.

##### `endDate` - [DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly) | [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

Optional date to limit the transactions which are returned to those before the specified date.

##### `cancellationToken` - [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)

A token to signal cancellation of the operation.

#### Returns

[Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)\<[NordigenApiResponse](/docs/api-reference/responses/nordigen-api-response)\<[AccountTransactions](/docs/api-reference/responses/account-transactions), [AccountsError](/docs/api-reference/errors/accounts-error)\>\>

A `NordigenApiResponse` which contains transaction data of the specified account.

---
title: AccountsError
---

The `AccountsError` class represents an error description as returned by some operations of the accounts endpoint of the GoCardless API.

## Properties

### `Summary` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

The summary text of the error.

### `Detail` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

The detailed description of the error.

### `Type` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

The type of the error.

### `StartDateError` - [BasicResponse](/docs/api-reference/responses/basic-response)?

An error that was returned related to the [`AccountsEndpoint.GetTransactions`](/docs/api-reference/endpoints/accounts-endpoint#gettransactions) method because the start date value was not accepted.

### `EndDateError` - [BasicResponse](/docs/api-reference/responses/basic-response)?

An error that was returned related to the [`AccountsEndpoint.GetTransactions`](/docs/api-reference/endpoints/accounts-endpoint#gettransactions) method because the end date value was not accepted.

## Constructor

```csharp
public AccountsError(string summary, string detail, string? type,
      BasicResponse? startDateError, BasicResponse? endDateError)
```

### Parameters

#### `summary` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

The summary text of the error.

#### `detail` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

The detailed description of the error.

#### `type` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

The type of the error.

#### `startDateError` - [BasicResponse](/docs/api-reference/responses/basic-response)?

An error that was returned related to the [`AccountsEndpoint.GetTransactions`](/docs/api-reference/endpoints/accounts-endpoint#gettransactions) method because the start date value was not accepted.

#### `endDateError` - [BasicResponse](/docs/api-reference/responses/basic-response)?

An error that was returned related to the [`AccountsEndpoint.GetTransactions`](/docs/api-reference/endpoints/accounts-endpoint#gettransactions) method because the end date value was not accepted.

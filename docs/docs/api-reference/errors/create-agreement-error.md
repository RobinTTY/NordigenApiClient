---
title: CreateAgreementError
---

The `CreateAgreementError` class represents an error description as returned by the create operation of the agreements endpoint of the GoCardless API.

## Properties

### `Summary` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

The summary text of the error.

### `Detail` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

The detailed description of the error.

### `InstitutionIdError` - [BasicResponse](/docs/api-reference/responses/basic-response)?

An error that was returned related to the institutionId sent during the request.

### `AccessScopeError` - [BasicResponse](/docs/api-reference/responses/basic-response)?

An error that was returned related to the accessScope property sent during the request.

### `MaxHistoricalDaysError` - [BasicResponse](/docs/api-reference/responses/basic-response)?

An error that was returned related to the maxHistoricalDays property sent during the request.

### `AccessValidForDaysError` - [BasicResponse](/docs/api-reference/responses/basic-response)?

An error that was returned related to the accessValidForDays property sent during the request.

### `AgreementError` - [BasicResponse](/docs/api-reference/responses/basic-response)?

An error that was returned related to the institutionId property sent during the request.

## Constructor

```csharp
public CreateAgreementError(
      string? summary, string? detail, BasicResponse? institutionIdError,
      BasicResponse? accessScopeError, BasicResponse? maxHistoricalDaysError,
      BasicResponse? accessValidForDaysError, BasicResponse? agreementError)
```

### Parameters

#### `summary` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

The summary text of the error.

#### `detail` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

The detailed description of the error.

#### `institutionIdError` - [BasicResponse](/docs/api-reference/responses/basic-response)?

An error that was returned related to the institutionId sent during the request.

#### `accessScopeError` - [BasicResponse](/docs/api-reference/responses/basic-response)?

An error that was returned related to the accessScope property sent during the request.

#### `maxHistoricalDaysError` - [BasicResponse](/docs/api-reference/responses/basic-response)?

An error that was returned related to the maxHistoricalDays property sent during the request.

#### `accessValidForDaysError` - [BasicResponse](/docs/api-reference/responses/basic-response)?

An error that was returned related to the accessValidForDays property sent during the request.

#### `agreementError` - [BasicResponse](/docs/api-reference/responses/basic-response)?

An error that was returned related to the institutionId property sent during the request.

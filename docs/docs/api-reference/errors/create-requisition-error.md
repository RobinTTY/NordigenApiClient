---
title: CreateRequisitionError
---

The `CreateRequisitionError` class represents an error description as returned by the create operation of the requisitions endpoint of the GoCardless API.

## Properties

### `Summary` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

The summary text of the error.

### `Detail` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

The detailed description of the error.

### `ReferenceError` - [BasicResponse](/docs/api-reference/responses/basic-response)?

An error that was returned related to the reference property sent during the request.

### `UserLanguageError` - [BasicResponse](/docs/api-reference/responses/basic-response)?

An error that was returned related to the userLanguage property sent during the request.

### `AgreementError` - [BasicResponse](/docs/api-reference/responses/basic-response)?

An error that was returned related to the agreementId property sent during the request.

### `RedirectError` - [BasicResponse](/docs/api-reference/responses/basic-response)?

An error that was returned related to the redirect property sent during the request.

### `SocialSecurityNumberError` - [BasicResponse](/docs/api-reference/responses/basic-response)?

An error that was returned related to the socialSecurityNumber property sent during the request.

### `AccountSelectionError` - [BasicResponse](/docs/api-reference/responses/basic-response)?

An error that was returned related to the accountSelection property sent during the request.

### `InstitutionIdError` - [BasicResponse](/docs/api-reference/responses/basic-response)?

An error that was returned related to the institutionId property sent during the request.

## Constructor

```csharp
public CreateRequisitionError(string? summary, string? detail, BasicResponse? referenceError,
      BasicResponse? userLanguageError, BasicResponse? agreementError, BasicResponse? redirectError,
      BasicResponse? socialSecurityNumberError, BasicResponse? accountSelectionError,
      BasicResponse? institutionIdError)
```

### Parameters

#### `summary` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

The summary text of the error.

#### `detail` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

The detailed description of the error.

#### `referenceError` - [BasicResponse](/docs/api-reference/responses/basic-response)?

An error that was returned related to the reference property sent during the request.

#### `userLanguageError` - [BasicResponse](/docs/api-reference/responses/basic-response)?

An error that was returned related to the userLanguage property sent during the request.

#### `agreementError` - [BasicResponse](/docs/api-reference/responses/basic-response)?

An error that was returned related to the agreementId property sent during the request.

#### `redirectError` - [BasicResponse](/docs/api-reference/responses/basic-response)?

An error that was returned related to the redirect property sent during the request.

#### `socialSecurityNumberError` - [BasicResponse](/docs/api-reference/responses/basic-response)?

An error that was returned related to the socialSecurityNumber property sent during the request.

#### `accountSelectionError` - [BasicResponse](/docs/api-reference/responses/basic-response)?

An error that was returned related to the accountSelection property sent during the request.

#### `institutionIdError` - [BasicResponse](/docs/api-reference/responses/basic-response)?

An error that was returned related to the institutionId property sent during the request.

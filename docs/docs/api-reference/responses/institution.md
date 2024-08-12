---
title: Institution
---

The `Institution` class represents a banking institution as returned by the Nordigen API.

## Properties

### `Id` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

The unique id of the institution.

### `Name` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

The name of the institution.

### `Bic` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

The Business Identifier Code (BIC) of the institution.

### `TransactionTotalDays` - [uint](https://learn.microsoft.com/en-us/dotnet/api/system.uint32)

The days for which the transaction history is available.

### `Countries` - [List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)\<[string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)\>?

The countries the institution operates in.

### `Logo` - [Uri](https://learn.microsoft.com/en-us/dotnet/api/system.uri)

A URI for the logo of the institution.

### `SupportedPayments` - [SupportedPayments](/docs/api-reference/responses/supported-payments)

Supported payment products for this institution. Only populated when calling [`InstitutionsEndpoint.GetInstitution`](/docs/api-reference/endpoints/institutions-endpoint#getinstitution).

### `SupportedFeatures` - [List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)\<[string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)\>?

Supported features for this institution. Only populated when calling [`InstitutionsEndpoint.GetInstitution`](/docs/api-reference/endpoints/institutions-endpoint#getinstitution).

### `IdentificationCodes` - [List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)\<[string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)\>?

Undocumented field returned by the GoCardless API. Only populated when calling [`InstitutionsEndpoint.GetInstitution`](/docs/api-reference/endpoints/institutions-endpoint#getinstitution).

## Constructor

```csharp
public Institution(string id, string name, string bic, uint transactionTotalDays,
      List<string> countries, Uri logo, SupportedPayments? supportedPayments,
      List<string>? supportedFeatures, List<string>? identificationCodes)
```

### Parameters

#### `id` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

The unique id of the institution.

#### `name` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

The name of the institution.

#### `bic` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

The Business Identifier Code (BIC) of the institution.

#### `transactionTotalDays` - [uint](https://learn.microsoft.com/en-us/dotnet/api/system.uint32)

The days for which the transaction history is available.

#### `countries` - [List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)\<[string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)\>?

The countries the institution operates in.

#### `logo` - [Uri](https://learn.microsoft.com/en-us/dotnet/api/system.uri)

A URI for the logo of the institution.

#### `supportedPayments` - [SupportedPayments](/docs/api-reference/responses/supported-payments)

Supported payment products for this institution. Only populated when calling [`InstitutionsEndpoint.GetInstitution`](/docs/api-reference/endpoints/institutions-endpoint#getinstitution).

#### `supportedFeatures` - [List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)\<[string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)\>?

Supported features for this institution. Only populated when calling [`InstitutionsEndpoint.GetInstitution`](/docs/api-reference/endpoints/institutions-endpoint#getinstitution).

#### `identificationCodes` - [List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)\<[string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)\>?

Undocumented field returned by the GoCardless API. Only populated when calling [`InstitutionsEndpoint.GetInstitution`](/docs/api-reference/endpoints/institutions-endpoint#getinstitution).

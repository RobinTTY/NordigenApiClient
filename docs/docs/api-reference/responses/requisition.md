---
title: Requisition
---

A collection of inputs for creating links and retrieving accounts via the Nordigen API.

## Properties

### `Id` - [Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid)

The id of the requisition assigned by the Nordigen API.

### `Created` - [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

### `Status` - [RequisitionStatus](TODO)

The status of the requisition.

### `Accounts` - [List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)\<[Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid)\>

The accounts linked to this requisition.

### `AuthenticationLink` - [Uri](https://learn.microsoft.com/en-us/dotnet/api/system.uri)

The Uri which starts the authentication process.

### `Redirect` - [Uri](https://learn.microsoft.com/en-us/dotnet/api/system.uri)

URI where the end user will be redirected after finishing authentication.

### `InstitutionId` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

The id of the institution this requisition is linked to.

### `AgreementId` - [Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid)?

The agreement this requisition is linked to.

### `Reference` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

A unique ID set by the user of the API for internal referencing.

### `UserLanguage` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

Enforces a language for all end user steps hosted by Nordigen passed as a two-letter country code adhering to [ISO 639-1](https://wikipedia.org/wiki/ISO_639-1).

### `SocialSecurityNumber` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Some European banks allow sending an end-user's SSN to check whether the SSN is valid. For bank availability check: [GoCardless Documentation](https://nordigen.zendesk.com/hc/en-gb/articles/6761166365085-SSN-verification-feature-for-specific-banks)

### `AccountSelection` - [bool](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)

Enables the end user to select which accounts they want to share (like joint accounts, accounts of children, etc.) if set to true. For details see: [GoCardless Documentation](https://nordigen.zendesk.com/hc/en-gb/articles/6760703821725-Account-selection-feature)

### `RedirectImmediate` - [bool](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)

Enables you to redirect end users back to your app immediately after they have given their consent to access the account information data from the bank, instead of waiting for transaction data being processed. Accounts endpoint status will be `PROCESSING` and you have to wait until account status is `READY` before you're able to query the transactions. For details see the [GoCardless Documentation](https://nordigen.zendesk.com/hc/en-gb/articles/6772857816477-Immediate-end-user-redirect-from-bank-after-consent).

## Constructor

```csharp
public Requisition(Guid id, DateTime created, RequisitionStatus status, List<Guid> accounts,
      Uri authenticationLink, Uri redirect, string institutionId, Guid? agreementId, string reference,
      string userLanguage, string? socialSecurityNumber, bool accountSelection, bool redirectImmediate)
```

### Parameters

#### `id` - [Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid)

The id of the requisition assigned by the Nordigen API.

#### `created` - [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

#### `status` - [RequisitionStatus](TODO)

The status of the requisition.

#### `accounts` - [List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)\<[Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid)\>

The accounts linked to this requisition.

#### `authenticationLink` - [Uri](https://learn.microsoft.com/en-us/dotnet/api/system.uri)

The Uri which starts the authentication process.

#### `redirect` - [Uri](https://learn.microsoft.com/en-us/dotnet/api/system.uri)

URI where the end user will be redirected after finishing authentication.

#### `institutionId` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

The id of the institution this requisition is linked to.

#### `agreementId` - [Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid)?

The agreement this requisition is linked to.

#### `reference` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

A unique ID set by the user of the API for internal referencing.

#### `userLanguage` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

Enforces a language for all end user steps hosted by Nordigen passed as a two-letter country code adhering to [ISO 639-1](https://wikipedia.org/wiki/ISO_639-1).

#### `socialSecurityNumber` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Some European banks allow sending an end-user's SSN to check whether the SSN is valid. For bank availability check: [GoCardless Documentation](https://nordigen.zendesk.com/hc/en-gb/articles/6761166365085-SSN-verification-feature-for-specific-banks)

#### `accountSelection` - [bool](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)

Enables the end user to select which accounts they want to share (like joint accounts, accounts of children, etc.) if set to true. For details see: [GoCardless Documentation](https://nordigen.zendesk.com/hc/en-gb/articles/6760703821725-Account-selection-feature)

#### `redirectImmediate` - [bool](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)

Enables you to redirect end users back to your app immediately after they have given their consent to access the account information data from the bank, instead of waiting for transaction data being processed. Accounts endpoint status will be `PROCESSING` and you have to wait until account status is `READY` before you're able to query the transactions. For details see the [GoCardless Documentation](https://nordigen.zendesk.com/hc/en-gb/articles/6772857816477-Immediate-end-user-redirect-from-bank-after-consent).

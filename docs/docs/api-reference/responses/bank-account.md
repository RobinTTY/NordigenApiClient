---
title: BankAccount
---

The `BankAccount` class represents an account at a banking institution. Reference: [GoCardless Documentation](https://developer.gocardless.com/bank-account-data/account-details)

## Properties

### `Id` - [Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid)

The unique id of the account assigned by GoCardless.

### `Iban` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

The IBAN of the account.

### `Created` - [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

The time this account was created.

### `LastAccessed` - [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)?

The time this account was last accessed via the API.

### `InstitutionId` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

The institution id this account belongs to.

### `OwnerName` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Name of the legal account owner. If there is more than one owner, then two names might be noted here.

### `Status` - [BankAccountStatus](TODO)

The status of the account (e.g. user has successfully authenticated and account is discovered).

## Constructor

```csharp
public BankAccount(Guid id, DateTime created, DateTime? lastAccessed, string iban,
      string institutionId, string? ownerName, BankAccountStatus status)
```

### Parameters

#### `id` - [Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid)

The unique id of the account assigned by GoCardless.

#### `iban` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

The IBAN of the account.

#### `created` - [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

The time this account was created.

#### `lastAccessed` - [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)?

The time this account was last accessed via the API.

#### `institutionId` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

The institution id this account belongs to.

#### `ownerName` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Name of the legal account owner. If there is more than one owner, then two names might be noted here.

#### `status` - [BankAccountStatus](TODO)

The status of the account (e.g. user has successfully authenticated and account is discovered).

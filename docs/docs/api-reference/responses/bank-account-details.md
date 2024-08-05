---
title: BankAccountDetails
---

The `BankAccountDetails` class represents detailed information about a `BankAccount`. Reference: [GoCardless documentation](https://developer.gocardless.com/bank-account-data/account-details)

## Properties

### `ResourceId` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Resource id used by the PSD2 interface. For reference see: [Berlin Group PSD2](https://www.berlin-group.org/_files/ugd/c2914b_fec1852ec9c640568f5c0b420acf67d2.pdf)

### `Iban` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

The IBAN of the bank account.

### `Bic` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

The BIC (Business Identifier Code) associated with the account.

### `Bban` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Basic Bank Account Number represents a country-specific bank account number. This data element is used for payment accounts which have no IBAN.

### `Currency` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

The currency the account is denominated in.

### `OwnerName` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Name of the legal account owner. If there is more than one owner, then two names might be noted here.

### `OwnerAddressUnstructured` - [List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)\<[string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)\>?

Address of the legal account owner in unstructured form.

### `OwnerAddressStructured` - [Address](/docs/api-reference/responses/address)?

Address of the legal account owner.

### `Name` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Name of the account, as assigned by the bank, in agreement with the account owner in order to provide an additional means of identification of the account.

### `DisplayName` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Name of the account as defined by the end user within online channels.

### `Product` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Product name of the bank for this account.

### `CashAccountType` - [CashAccountType](TODO)?

Specifies the nature, or use, of the cash account as defined by ISO 20022.

### `Details` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Specifications that might be provided by the financial institution (e.g. characteristics of the account/relevant card).

### `MaskedPan` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Masked primary account number (unique identifier on credit cards, debit cards, and other types of payment cards).

### `LinkedAccounts` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

A financial institution might name a cash account associated with pending card transactions.

### `Msisdn` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

An alias to a payment account via a registered mobile phone number.

### `Status` - [IsoBankAccountStatus](TODO)?

The status of the account.

### `Usage` - [BankAccountUsage](TODO)?

Specifies the usage of the account.

## Constructor

```csharp
public BankAccountDetails(string? resourceId, string? iban, string? bic, string? bban,
      string currency, string? ownerName, List<string>? ownerAddressUnstructured,
      Address? ownerAddressStructured, string? name, string? displayName, string? product,
      CashAccountType? cashAccountType, string? details, string? linkedAccounts,string? msisdn,
      IsoBankAccountStatus? status, BankAccountUsage? usage, string? maskedPan)
```

### Parameters

#### `resourceId` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Resource id used by the PSD2 interface. For reference see: [Berlin Group PSD2](https://www.berlin-group.org/_files/ugd/c2914b_fec1852ec9c640568f5c0b420acf67d2.pdf)

#### `iban` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

The IBAN of the bank account.

#### `bic` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

The BIC (Business Identifier Code) associated with the account.

#### `bban` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Basic Bank Account Number represents a country-specific bank account number. This data element is used for payment accounts which have no IBAN.

#### `currency` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

The currency the account is denominated in.

#### `ownerName` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Name of the legal account owner. If there is more than one owner, then two names might be noted here.

#### `ownerAddressUnstructured` - [List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)\<[string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)\>?

Address of the legal account owner in unstructured form.

#### `ownerAddressStructured` - [Address](/docs/api-reference/responses/address)?

Address of the legal account owner.

#### `name` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Name of the account, as assigned by the bank, in agreement with the account owner in order to provide an additional means of identification of the account.

#### `displayName` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Name of the account as defined by the end user within online channels.

#### `product` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Product name of the bank for this account.

#### `cashAccountType` - [CashAccountType](TODO)?

Specifies the nature, or use, of the cash account as defined by ISO 20022.

#### `details` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Specifications that might be provided by the financial institution (e.g. characteristics of the account/relevant card).

#### `maskedPan` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Masked primary account number (unique identifier on credit cards, debit cards, and other types of payment cards).

#### `linkedAccounts` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

A financial institution might name a cash account associated with pending card transactions.

#### `msisdn` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

An alias to a payment account via a registered mobile phone number.

#### `status` - [IsoBankAccountStatus](TODO)?

The status of the account.

#### `usage` - [BankAccountUsage](TODO)?

Specifies the usage of the account.

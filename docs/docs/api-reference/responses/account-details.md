---
title: AccountDetails
---

The `AccountDetails` class holds account details of a creditor/debtor.

## Properties

### `Iban` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

The IBAN of the bank account.

### `Bban` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Basic Bank Account Number represents a country-specific bank account number. This data element is used for payment accounts which have no IBAN.

### `Pan` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Primary account number (unique identifier on credit cards, debit cards, and other types of payment cards).

### `MaskedPan` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Masked primary account number (unique identifier on credit cards, debit cards, and other types of payment cards).

### `Msisdn` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

An alias to a payment account via a registered mobile phone number.

### `Currency` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

The currency the amount is denominated in.

## Constructor

```csharp
public AccountDetails(string? iban, string? bban, string? pan,
      string? maskedPan, string? msisdn, string currency)
```

### Parameters

#### `iban` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

The IBAN of the bank account.

#### `bban` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Basic Bank Account Number represents a country-specific bank account number. This data element is used for payment accounts which have no IBAN.

#### `pan` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Primary account number (unique identifier on credit cards, debit cards, and other types of payment cards).

#### `maskedPan` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Masked primary account number (unique identifier on credit cards, debit cards, and other types of payment cards).

#### `msisdn` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

An alias to a payment account via a registered mobile phone number.

#### `currency` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

The currency the amount is denominated in.

---
title: Balance
---

The `Balance` class represents a balance of a [BankAccount](TODO).

## Properties

### `BalanceAmount` - [AmountCurrencyPair](/docs/api-reference/responses/amount-currency-pair)

The balance amount including details about the currency the amount is denominated in.

### `BalanceType` - [BalanceType](TODO)

Type of the balance (e.g. [BalanceType.ClosingBooked](TODO)).

### `ReferenceDate` - [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

The effective date of the balance.

### `CreditLimitIncluded` - [bool](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)?

A flag indicating if the credit limit of the corresponding account is included in the calculation of the balance, where applicable.

### `LastChangeDateTime` - [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)?

This data element might be used to indicate e.g. with the expected or booked balance that no action is known on the account, which is not yet booked.

### `LastCommittedTransaction` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Entry reference of the last committed transaction to support the TPP in identifying whether all end users transactions are already known.

## Constructor

```csharp
public Balance(AmountCurrencyPair balanceAmount, BalanceType balanceType, DateTime referenceDate,
      bool? creditLimitIncluded, DateTime? lastChangeDateTime, string? lastCommittedTransaction)
```

### Parameters

#### `balanceAmount` - [AmountCurrencyPair](/docs/api-reference/responses/amount-currency-pair)

The balance amount including details about the currency the amount is denominated in.

#### `balanceType` - [BalanceType](TODO)

Type of the balance (e.g. [BalanceType.ClosingBooked](TODO)).

#### `referenceDate` - [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

The effective date of the balance.

#### `creditLimitIncluded` - [bool](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)?

A flag indicating if the credit limit of the corresponding account is included in the calculation of the balance, where applicable.

#### `lastChangeDateTime` - [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)?

This data element might be used to indicate e.g. with the expected or booked balance that no action is known on the account, which is not yet booked.

#### `lastCommittedTransaction` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Entry reference of the last committed transaction to support the TPP in identifying whether all end users transactions are already known.

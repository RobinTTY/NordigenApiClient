---
title: CurrencyExchange
---

The `CurrencyExchange` class represents detailed information about a currency exchange.

## Properties

### `InstructedAmount` - [AmountCurrencyPair](/docs/api-reference/responses/amount-currency-pair)?

The instructed amount including details about the currency the amount is denominated in.

### `SourceCurrency` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

Currency from which an amount is to be converted in a currency conversion. ISO 4217 Alpha 3 currency code (e.g. "USD").

### `TargetCurrency` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

Currency into which an amount is to be converted in a currency conversion. ISO 4217 Alpha 3 currency code (e.g. "USD").

### `UnitCurrency` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

Currency in which the rate of exchange is expressed in a currency exchange. In the example 1 EUR = xxx USD, the unit currency is EUR. ISO 4217 Alpha 3 currency code (e.g. "USD").

### `ExchangeRate` - [decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal)

Factor used to convert an amount from one currency into another. This reflects the price at which one currency was bought with another currency.

### `QuotationDate` - [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)?

Date at which an exchange rate is quoted.

### `ContractIdentification` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Unique identification to unambiguously identify the foreign exchange contract.

## Constructor

```csharp
public CurrencyExchange(AmountCurrencyPair? instructedAmount, string sourceCurrency,
      string targetCurrency, string unitCurrency, decimal exchangeRate,
      DateTime? quotationDate, string? contractIdentification)
```

### Parameters

#### `instructedAmount` - [AmountCurrencyPair](/docs/api-reference/responses/amount-currency-pair)?

The instructed amount including details about the currency the amount is denominated in.

#### `sourceCurrency` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

Currency from which an amount is to be converted in a currency conversion. ISO 4217 Alpha 3 currency code (e.g. "USD").

#### `targetCurrency` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

Currency into which an amount is to be converted in a currency conversion. ISO 4217 Alpha 3 currency code (e.g. "USD").

#### `unitCurrency` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

Currency in which the rate of exchange is expressed in a currency exchange. In the example 1 EUR = xxx USD, the unit currency is EUR. ISO 4217 Alpha 3 currency code (e.g. "USD").

#### `exchangeRate` - [decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal)

Factor used to convert an amount from one currency into another. This reflects the price at which one currency was bought with another currency.

#### `quotationDate` - [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)?

Date at which an exchange rate is quoted.

#### `contractIdentification` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Unique identification to unambiguously identify the foreign exchange contract.

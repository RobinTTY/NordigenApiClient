---
title: Transaction
---

The `Transaction` class represents a financial transaction. Reference: [GoCardless Documentation](https://developer.gocardless.com/bank-account-data/transactions)

## Properties

### `TransactionId` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Used as access-ID in the PSD2 interface, where more details on an transaction are offered. If this data attribute is provided this shows that the AIS (Account Information Service) can get access on more details about this transaction.

### `DebtorName` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

The name of the party which owes the money.

### `DebtorAccount` - [AccountDetails](/docs/api-reference/responses/account-details)?

The account of the party which owes the money.

### `DebtorAgent` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

The BIC code allocated to the financial institution servicing an account for the debtor.

### `UltimateDebtor` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Ultimate party that owes an amount of money to the (ultimate) creditor.

### `CreditorName` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

The name of the party which is owed the money.

### `CreditorAccount` - [AccountDetails](/docs/api-reference/responses/account-details)?

The account of the party which is owed the money.

### `CreditorAgent` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

The BIC code allocated to the financial institution servicing an account for the creditor.

### `UltimateCreditor` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Ultimate party that is owed an amount of money by the (ultimate) debtor.

### `CreditorId` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Identification of Creditors, e.g. a SEPA Creditor ID.

### `TransactionAmount` - [AmountCurrencyPair](/docs/api-reference/responses/amount-currency-pair)

The transaction amount including details about the currency the amount is denominated in.

### `BankTransactionCode` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Code consisting of "DomainCode"-"FamilyCode"-"SubFamilyCode". For reference see [ISO20022](https://wikipedia.org/wiki/ISO_20022). Example: `PMNT-RCDT-ESCT` defining a transaction assigned to the PayMeNT domain(PMNT), belonging to the family of ReceivedCreDitTransfer(RCDT) that facilitated the EuropeanSEPACreditTransfer(ESCT).

### `BookingDate` - [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)?

The date when the transaction was posted to the account.

### `BookingDateTime` - [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)?

The date and time when the transaction was posted to the account.

### `ValueDate` - [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)?

Date at which assets become available to the account owner in case of a credit entry, or cease to be available to the account owner in case of a debit entry.

### `ValueDateTime` - [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)?

Date at which assets become available to the account owner in case of a credit entry, or cease to be available to the account owner in case of a debit entry.

### `RemittanceInformationUnstructured` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Unstructured reference issued by the seller used to establish a link between the payment of an invoice and the invoice instance. The reference helps the seller to assign an incoming payment to the invoice by using a reference such as the invoice number or a purchase order number.

**Limited by the PSD2 specification to 140 characters, truncates additional information if necessary.**

### `RemittanceInformationUnstructuredArray` - [List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)\<[string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)\>?

Unstructured reference issued by the seller used to establish a link between the payment of an invoice and the invoice instance. The reference helps the seller to assign an incoming payment to the invoice by using a reference such as the invoice number or a purchase order number.

**Might contain more information than `RemittanceInformationUnstructured` (if contents were truncated).**

### `RemittanceInformationStructured` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Reference issued by the seller used to establish a link between the payment of an invoice and the invoice instance. The reference helps the seller to assign an incoming payment to the invoice by using a reference such as the invoice number or a purchase order number.

### `RemittanceInformationStructuredArray` - [List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)\<[string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)\>?

Reference issued by the seller used to establish a link between the payment of an invoice and the invoice instance. The reference helps the seller to assign an incoming payment to the invoice by using a reference such as the invoice number or a purchase order number.

### `EndToEndId` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Unique identification assigned by the initiating party to unambiguously identify the transaction. This identification is passed on, unchanged, throughout the entire end-to-end chain.

### `MandateId` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Identification of mandates, e.g. a SEPA mandate id.

### `ProprietaryBankTransactionCode` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Proprietary bank transaction code to identify the underlying transaction.

### `PurposeCode` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Underlying reason for the transaction, as published in an external purpose code list. For reference see: [ISO20022 External](https://www.iso20022.org/catalogue-messages/additional-content-messages/external-code-sets)

### `AdditionalInformation` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Used by the financial institution to transport additional transaction related information.

### `AdditionalInformationStructured` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Used if and only if the bookingStatus entry equals "information".

### `BalanceAfterTransaction` - [Balance](/docs/api-reference/responses/balance)?

The balance of the account after this transaction.

### `CheckId` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Identification of a check.

### `CurrencyExchange` - [List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)\<[CurrencyExchange](/docs/api-reference/responses/currency-exchange)\>?

Array of the report exchange rate.

### `EntryReference` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

The identification of the transaction as used for reference by the financial institution.

### `InternalTransactionId` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Transaction identifier given by GoCardless.

### `MerchantCategoryCode` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Merchant category code as defined by the card issuer.

## Constructor

```csharp
public Transaction(string? transactionId, string? debtorName, AccountDetails? debtorAccount,
      string? ultimateDebtor, string? creditorName, AccountDetails? creditorAccount,
      AmountCurrencyPair transactionAmount, string? bankTransactionCode, DateTime? bookingDate,
      DateTime? valueDate, string? remittanceInformationUnstructured,
      List<string>? remittanceInformationUnstructuredArray, string? endToEndId, string? mandateId,
      string? proprietaryBankTransactionCode, string? purposeCode, string? debtorAgent, string? creditorAgent,
      string? ultimateCreditor, string? creditorId, DateTime? valueDateTime,
      string? remittanceInformationStructured, List<string>? remittanceInformationStructuredArray,
      string? additionalInformation, string? additionalInformationStructured, Balance? balanceAfterTransaction,
      string? checkId, List<CurrencyExchange>? currencyExchange, string? entryReference,
      string? internalTransactionId, string? merchantCategoryCode, DateTime? bookingDateTime)
```

### Parameters

#### `transactionId` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Used as access-ID in the PSD2 interface, where more details on an transaction are offered. If this data attribute is provided this shows that the AIS (Account Information Service) can get access on more details about this transaction.

#### `debtorName` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

The name of the party which owes the money.

#### `debtorAccount` - [AccountDetails](/docs/api-reference/responses/account-details)?

The account of the party which owes the money.

#### `debtorAgent` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

The BIC code allocated to the financial institution servicing an account for the debtor.

#### `ultimateDebtor` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Ultimate party that owes an amount of money to the (ultimate) creditor.

#### `creditorName` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

The name of the party which is owed the money.

#### `creditorAccount` - [AccountDetails](/docs/api-reference/responses/account-details)?

The account of the party which is owed the money.

#### `creditorAgent` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

The BIC code allocated to the financial institution servicing an account for the creditor.

#### `ultimateCreditor` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Ultimate party that is owed an amount of money by the (ultimate) debtor.

#### `creditorId` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Identification of Creditors, e.g. a SEPA Creditor ID.

#### `transactionAmount` - [AmountCurrencyPair](/docs/api-reference/responses/amount-currency-pair)

The transaction amount including details about the currency the amount is denominated in.

#### `bankTransactionCode` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Code consisting of "DomainCode"-"FamilyCode"-"SubFamilyCode". For reference see [ISO20022](https://wikipedia.org/wiki/ISO_20022). Example: `PMNT-RCDT-ESCT` defining a transaction assigned to the PayMeNT domain(PMNT), belonging to the family of ReceivedCreDitTransfer(RCDT) that facilitated the EuropeanSEPACreditTransfer(ESCT).

#### `bookingDate` - [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)?

The date when the transaction was posted to the account.

#### `bookingDateTime` - [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)?

The date and time when the transaction was posted to the account.

#### `valueDate` - [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)?

Date at which assets become available to the account owner in case of a credit entry, or cease to be available to the account owner in case of a debit entry.

#### `valueDateTime` - [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)?

Date at which assets become available to the account owner in case of a credit entry, or cease to be available to the account owner in case of a debit entry.

#### `remittanceInformationUnstructured` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Unstructured reference issued by the seller used to establish a link between the payment of an invoice and the invoice instance. The reference helps the seller to assign an incoming payment to the invoice by using a reference such as the invoice number or a purchase order number.

**Limited by the PSD2 specification to 140 characters, truncates additional information if necessary.**

#### `remittanceInformationUnstructuredArray` - [List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)\<[string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)\>?

Unstructured reference issued by the seller used to establish a link between the payment of an invoice and the invoice instance. The reference helps the seller to assign an incoming payment to the invoice by using a reference such as the invoice number or a purchase order number.

**Might contain more information than `RemittanceInformationUnstructured` (if contents were truncated).**

#### `remittanceInformationStructured` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Reference issued by the seller used to establish a link between the payment of an invoice and the invoice instance. The reference helps the seller to assign an incoming payment to the invoice by using a reference such as the invoice number or a purchase order number.

#### `remittanceInformationStructuredArray` - [List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)\<[string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)\>?

Reference issued by the seller used to establish a link between the payment of an invoice and the invoice instance. The reference helps the seller to assign an incoming payment to the invoice by using a reference such as the invoice number or a purchase order number.

#### `endToEndId` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Unique identification assigned by the initiating party to unambiguously identify the transaction. This identification is passed on, unchanged, throughout the entire end-to-end chain.

#### `mandateId` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Identification of mandates, e.g. a SEPA mandate id.

#### `proprietaryBankTransactionCode` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Proprietary bank transaction code to identify the underlying transaction.

#### `purposeCode` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Underlying reason for the transaction, as published in an external purpose code list. For reference see: [ISO20022 External](https://www.iso20022.org/catalogue-messages/additional-content-messages/external-code-sets)

#### `additionalInformation` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Used by the financial institution to transport additional transaction related information.

#### `additionalInformationStructured` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Used if and only if the bookingStatus entry equals "information".

#### `balanceAfterTransaction` - [Balance](/docs/api-reference/responses/balance)?

The balance of the account after this transaction.

#### `checkId` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Identification of a check.

#### `currencyExchange` - [List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)\<[CurrencyExchange](/docs/api-reference/responses/currency-exchange)\>?

Array of the report exchange rate.

#### `entryReference` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

The identification of the transaction as used for reference by the financial institution.

#### `internalTransactionId` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Transaction identifier given by GoCardless.

#### `merchantCategoryCode` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Merchant category code as defined by the card issuer.

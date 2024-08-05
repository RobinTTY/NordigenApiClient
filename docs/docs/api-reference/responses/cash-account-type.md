---
title: CashAccountType Enum
---

Specifies the nature, or use, of a cash account as defined by ISO 20022. Reference: [ISO20022 External Code Sets](https://www.iso20022.org/catalogue-messages/additional-content-messages/external-code-sets)

## Fields

### `Undefined`

An undefined cash account type. Assigned if the type couldn't be matched to any known types.

### `Current`

Account used to post debits and credits when no specific account has been nominated.

### `Card`

Account used for credit card payments.

### `CashPayment`

Account used for the payment of cash.

### `Charges`

Account used for charges if different from the account for payment.

### `CashIncome`

Account used for payment of income if different from the current cash account.

### `Commission`

Account used for commission if different from the account for payment.

### `ClearingParticipantSettlement`

Account used to post settlement debit and credit entries on behalf of a designated Clearing Participant.

### `LimitedLiquiditySavings`

Account used for savings with special interest and withdrawal terms.

### `Loan`

Account used for loans.

### `MarginalLending`

Account used for a marginal lending facility.

### `MoneyMarket`

Account used for money markets if different from the cash account.

### `NonResidentExternal`

Account used for non-resident external.

### `Overdraft`

Account used for overdrafts.

### `OvernightDeposit`

Account used for overnight deposits.

### `Other`

Account not otherwise specified.

### `Settlement`

Account used to post debit and credit entries, as a result of transactions cleared and settled through a specific clearing and settlement system.

### `Salary`

Accounts used for salary payments.

### `Savings`

Account used for savings.

### `Taxes`

Account used for taxes if different from the account for payment.

### `Transacting`

A transacting account is the most basic type of bank account that you can get. The main difference between transaction and check accounts is that you usually do not get a checkbook with your transacting account and neither are you offered an overdraft facility.

### `CashTrading`

Account used for trading if different from the current cash account.

### `Virtual`

Account created virtually to facilitate collection and reconciliation.

### `NonResidentForeignCurrent`

Non-Resident Individual/Entity Foreign Current held domestically.

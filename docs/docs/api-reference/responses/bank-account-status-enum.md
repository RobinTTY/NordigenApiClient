---
title: BankAccountStatus Enum
---

Identifies the status of the bank account in reference to the GoCardless platform. Reference: [Gocardless Documentation](https://developer.gocardless.com/bank-account-data/statuses#:~:text=is%20starting%20status.-,Accounts%20endpoint,-Status%20long)

## Fields

### `Undefined`

An undefined bank account status. Assigned if the status couldn't be matched to any known option.

### `Discovered`

Indicates that the user has successfully authenticated and an account has been discovered.

### `Error`

Indicates that an error was encountered in processing the account.

### `Expired`

Indicates that the access to the account has expired as defined in the end user agreement.

### `Processing`

Indicates that the account is being processed by the institution.

### `Ready`

Indicates that the account has been successfully processed.

### `Suspended`

Indicates that the account has been suspended due to more than 10 consecutive failed attempts to access the account.

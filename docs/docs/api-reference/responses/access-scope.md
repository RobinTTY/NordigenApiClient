---
title: AccessScope Enum
---

Contains the available access scopes for banking institutions. Access scopes can be used to limit the access to the 3 major data blocks the GoCardless API is offering. This feature is not supported by all banks, check [`Institution.SupportedFeatures`](/docs/api-reference/responses/institution#supportedfeatures---liststring) to verify if it is.

## Fields

### `Undefined`

An undefined access scope. Assigned if the scope couldn't be matched to any known types.

### `Balances`

Access scope required to access the balances of an account.

### `Transactions`

Access scope required to access the transactions of an account.

### `Details`

Access scope needed to access account details.

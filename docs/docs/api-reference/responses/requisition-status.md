---
title: RequisitionStatus Enum
---

Indicates the status of a [`Requisition`](/docs/api-reference/responses/requisition). A requisition can assume one of nine statuses. The sequence of statuses is given in stages. Reference: [GoCardless Documentation](https://developer.gocardless.com/bank-account-data/statuses)

## Fields

### Undefined

An undefined requisition status. Assigned if the status couldn't be matched to any known option.

### Created

Indicates that the requisition has been successfully created (stage 1).

### GivingConsent

Indicates that the account holder is currently in the process of giving consent through Nordigen's consent screen (stage 2).

### UndergoingAuthentication

Indicates that the account holder has been redirected to the financial institution for authentication (stage 3).

### Rejected

Indicates that either the SSN verification has failed or the account holder has entered incorrect credentials (stage 4).

### SelectingAccounts

Indicates that the account holder is currently in the process of selecting accounts (stage 5).

### GrantingAccess

Indicates that the end user is currently in the process of granting access to their account information (stage 6).

### Linked

Indicates that an account has been successfully linked to the requisition (stage 7).

### Suspended

Indicates that the requisition is suspended due to numerous consecutive errors that happened while accessing one of the linked accounts (stage 8).

### Expired

Indicates that access to the linked accounts has expired as defined in the end user agreement (stage 9).

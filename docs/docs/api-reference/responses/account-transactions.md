---
title: AccountTransactions
---

The `AccountTransactions` class holds transactions belonging to a bank account.

## Properties

### `BookedTransactions` - List\<Transaction\>

Transactions which were already booked to the bank account.

### `PendingTransactions` - List\<Transaction\>

Transactions which are currently pending and have not been booked yet.

## Constructor

```csharp
public AccountTransactions(List<Transaction> bookedTransactions,
      List<Transaction> pendingTransactions)
```

### Parameters

#### `bookedTransactions` - List\<Transaction\>

Transactions which were already booked to the bank account.

#### `pendingTransactions` - List\<Transaction\>

Transactions which are currently pending and have not been booked yet.

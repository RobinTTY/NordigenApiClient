---
title: AccountTransactions
---

The `AccountTransactions` class holds transactions belonging to a bank account.

## Properties

### `BookedTransactions` - [List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)\<[Transaction](/docs/api-reference/responses/transaction)\>

Transactions which were already booked to the bank account.

### `PendingTransactions` - [List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)\<[Transaction](/docs/api-reference/responses/transaction)\>

Transactions which are currently pending and have not been booked yet.

## Constructor

```csharp
public AccountTransactions(List<Transaction> bookedTransactions,
      List<Transaction> pendingTransactions)
```

### Parameters

#### `bookedTransactions` - [List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)\<[Transaction](/docs/api-reference/responses/transaction)\>

Transactions which were already booked to the bank account.

#### `pendingTransactions` - [List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)\<[Transaction](/docs/api-reference/responses/transaction)\>

Transactions which are currently pending and have not been booked yet.

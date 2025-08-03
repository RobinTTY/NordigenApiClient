---
title: ReconfirmationTimestamps
---

Represents timestamps for the reconfirmation and rejection actions within a reconfirmation process.

## Properties

### `Reconfirmed` - [DateTime?](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

The date and time when the reconfirmation process was completed.

### `Rejected` - [DateTime?](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

The date and time when the reconfirmation process was rejected.

## Constructor

```csharp
public ReconfirmationTimestamps(DateTime? reconfirmed, DateTime? rejected)
```

### Parameters

#### `reconfirmed` - [DateTime?](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

The date and time when the reconfirmation action was performed, if applicable.

#### `rejected` - [DateTime?](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

The date and time when the rejection action was performed, if applicable.

---
title: Agreement
---

The `Agreement` class represents an end user agreement which determines the scope and length of access to data provided by institutions.

## Properties

### `Id` - [Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid)

The id of the agreement assigned by the Nordigen API.

### `Created` - [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

Time when the agreement was created.

### `Accepted` - [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)?

Time when the agreement was accepted.

### `InstitutionId` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

The institution this agreement refers to.

### `AccessScope` - [List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)\<[AccessScope](/docs/api-reference/responses/access-scope)\>

The scope of information that can be accessed.

### `MaxHistoricalDays` - [uint](https://learn.microsoft.com/en-us/dotnet/api/system.uint32)

The length of the transaction history in days.

### `AccessValidForDays` - [uint](https://learn.microsoft.com/en-us/dotnet/api/system.uint32)

The length the access to the account is valid for.

### `ReconfirmationSupported` - [bool](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)

Whether this agreement can be extended. Supported by British banks only.

## Constructor

```csharp
public Agreement(Guid id, DateTime created, DateTime? accepted, string institutionId,
      uint maxHistoricalDays, uint accessValidForDays, List<AccessScope> accessScope, bool reconfirmationSupported = false)
```

### Parameters

#### `id` - [Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid)

The id of the agreement assigned by the Nordigen API.

#### `created` - [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

Time when the agreement was created.

#### `accepted` - [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)?

Time when the agreement was accepted.

#### `institutionId` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

The institution this agreement refers to.

#### `maxHistoricalDays` - [uint](https://learn.microsoft.com/en-us/dotnet/api/system.uint32)

The length of the transaction history in days.

#### `accessValidForDays` - [uint](https://learn.microsoft.com/en-us/dotnet/api/system.uint32)

The length the access to the account is valid for.

#### `accessScope` - [List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)\<[AccessScope](/docs/api-reference/responses/access-scope)\>

The scope of information that can be accessed.

#### `reconfirmationSupported` - [bool](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)

Whether this agreement can be extended. Supported by British banks only. Default is `false`.

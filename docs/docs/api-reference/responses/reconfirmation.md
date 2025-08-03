---
title: Reconfirmation
---

The details of a reconfirmation for an end user agreement.

## Properties

### `ReconfirmationUrl` - [Uri](https://learn.microsoft.com/en-us/dotnet/api/system.uri)

URL for the reconfirmation process of an end user agreement.

### `Created` - [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

The date and time when the reconfirmation was created.

### `UrlValidFrom` - [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

The date and time the reconfirmation URL is valid from.

### `UrlValidTo` - [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

The date and time the reconfirmation URL is valid to.

### `LastAccessed` - [DateTime?](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

The date and time when the reconfirmation was last accessed (not necessarily by the end-user).

### `LastSubmitted` - [DateTime?](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

The date and time when the reconfirmation was last submitted (it can be submitted multiple times).

### `RedirectUrl` - [Uri?](https://learn.microsoft.com/en-us/dotnet/api/system.uri)

Redirect URL for reconfirmation to override requisition's redirect.

### `Accounts` - [Dictionary](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2)\<[string](https://learn.microsoft.com/en-us/dotnet/api/system.string), [ReconfirmationTimestamps](/docs/api-reference/responses/reconfirmation-timestamps)\>

Dictionary of account IDs and their reconfirm and reject timestamps.

## Constructor

```csharp
public Reconfirmation(Uri reconfirmationUrl, DateTime created, DateTime urlValidFrom, DateTime urlValidTo,
        DateTime? lastAccessed, DateTime? lastSubmitted, Uri? redirectUrl,
        Dictionary<string, ReconfirmationTimestamps> accounts)
```

### Parameters

#### `reconfirmationUrl` - [Uri](https://learn.microsoft.com/en-us/dotnet/api/system.uri)

The URL for the reconfirmation process of an end user agreement.

#### `created` - [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

The date and time when the reconfirmation was created.

#### `urlValidFrom` - [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

The date and time the reconfirmation URL is valid from.

#### `urlValidTo` - [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

The date and time the reconfirmation URL is valid to.

#### `lastAccessed` - [DateTime?](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

The date and time when the reconfirmation was last accessed (not necessarily by the end-user).

#### `lastSubmitted` - [DateTime?](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

The date and time when the reconfirmation was last submitted (it can be submitted multiple times).

#### `redirectUrl` - [Uri?](https://learn.microsoft.com/en-us/dotnet/api/system.uri)

The redirect URL for reconfirmation to override requisition's redirect.

#### `accounts` - [Dictionary](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2)\<[string](https://learn.microsoft.com/en-us/dotnet/api/system.string), [ReconfirmationTimestamps](/docs/api-reference/responses/reconfirmation-timestamps)\>

The dictionary of account IDs and their reconfirm and reject timestamps.

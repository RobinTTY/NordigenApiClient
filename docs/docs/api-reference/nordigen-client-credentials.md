---
title: NordigenClientCredentials
---

The `NordigenClientCredentials` class represents user secrets as provided by GoCardless. Used to acquire access-tokens to the API.

## Properties

### `SecretId` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

Secret GoCardless API credential id.

### `SecretKey` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

Secret GoCardless API credential key.

## Constructor

```csharp
public NordigenClientCredentials(string secretId, string secretKey)
```

### Parameters

#### `secretId` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

Secret GoCardless API credential id.

#### `secretKey` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

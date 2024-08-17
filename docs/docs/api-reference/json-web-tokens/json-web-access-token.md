---
title: JsonWebAccessToken
---

The `JsonWebAccessToken` class represents the json web access token as well as the metadata returned by the GoCardless API.

## Properties

### `AccessToken` - [JsonWebToken](https://learn.microsoft.com/en-us/dotnet/api/microsoft.identitymodel.jsonwebtokens.jsonwebtoken)

The JWT access token returned by the GoCardless API.

### `AccessExpires` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)

Indicates the time in seconds after which the access token expires.

## Constructor

```csharp
public JsonWebAccessToken(JsonWebToken accessToken, int accessExpires)
```

### Parameters

#### `accessToken` - [JsonWebToken](https://learn.microsoft.com/en-us/dotnet/api/microsoft.identitymodel.jsonwebtokens.jsonwebtoken)

The JWT access token returned by the GoCardless API.

#### `accessExpires` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)

Indicates the time in seconds after which the access token expires.

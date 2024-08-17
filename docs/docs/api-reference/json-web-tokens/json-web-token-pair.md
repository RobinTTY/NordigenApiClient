---
title: JsonWebTokenPair
---

The `JsonWebTokenPair` class represents the JWT token pair returned by the GoCardless API.

## Properties

### `AccessToken` - [JsonWebToken](https://learn.microsoft.com/en-us/dotnet/api/microsoft.identitymodel.jsonwebtokens.jsonwebtoken)

The JWT access token returned by the GoCardless API.

### `RefreshToken` - [JsonWebToken](https://learn.microsoft.com/en-us/dotnet/api/microsoft.identitymodel.jsonwebtokens.jsonwebtoken)

The JWT refresh token returned by the GoCardless API.

### `AccessExpires` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)

Indicates the time in seconds after which the access token expires.

### `RefreshExpires` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)

Indicates the time in seconds after which the access token expires.

## Constructors

```csharp
public JsonWebTokenPair(JsonWebToken accessToken, JsonWebToken refreshToken,
      int accessExpires, int refreshExpires)
```

### Parameters

#### `accessToken` - [JsonWebToken](https://learn.microsoft.com/en-us/dotnet/api/microsoft.identitymodel.jsonwebtokens.jsonwebtoken)

The JWT access token returned by the GoCardless API.

#### `refreshToken` - [JsonWebToken](https://learn.microsoft.com/en-us/dotnet/api/microsoft.identitymodel.jsonwebtokens.jsonwebtoken)

The JWT refresh token returned by the GoCardless API.

#### `accessExpires` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)

Indicates the time in seconds after which the access token expires.

#### `refreshExpires` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)

Indicates the time in seconds after which the access token expires.

```csharp
public JsonWebTokenPair(string accessToken, string refreshToken)
```

### Parameters

#### `accessToken` - [JsonWebToken](https://learn.microsoft.com/en-us/dotnet/api/microsoft.identitymodel.jsonwebtokens.jsonwebtoken)

The JWT access token returned by the GoCardless API.

#### `refreshToken` - [JsonWebToken](https://learn.microsoft.com/en-us/dotnet/api/microsoft.identitymodel.jsonwebtokens.jsonwebtoken)

The JWT refresh token returned by the GoCardless API.

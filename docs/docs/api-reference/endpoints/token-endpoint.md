---
title: TokenEndpoint
---

The `TokenEndpoint` class provides support for the API operations of the tokens endpoint.

## Methods

### `GetTokenPair`

Obtains a new JWT token pair from the Nordigen API.

```csharp
public async Task<NordigenApiResponse<JsonWebTokenPair, BasicResponse>>
  GetTokenPair(CancellationToken cancellationToken = default)
```

#### Parameters

##### `cancellationToken` - [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)

A token to signal cancellation of the operation.

#### Returns

[Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)\<[NordigenApiResponse](/docs/api-reference/responses/nordigen-api-response)\<[JsonWebTokenPair](/docs/api-reference/json-web-tokens/json-web-token-pair), [BasicResponse](/docs/api-reference/responses/basic-response)\>\>

A `NordigenApiResponse` containing the obtained `JsonWebTokenPair` if the request was successful.

### `RefreshAccessToken`

Refreshes the given JWT access token using a valid refresh token.

```csharp
public async Task<NordigenApiResponse<JsonWebAccessToken, BasicResponse>>
  RefreshAccessToken(JsonWebToken refreshToken, CancellationToken cancellationToken = default)
```

#### Parameters

##### `refreshToken` - [JsonWebToken](https://learn.microsoft.com/en-us/dotnet/api/microsoft.identitymodel.jsonwebtokens.jsonwebtoken)

A valid refresh token that was previously obtained.

##### `cancellationToken` - [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)

A token to signal cancellation of the operation.

#### Returns

[Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)\<[NordigenApiResponse](/docs/api-reference/responses/nordigen-api-response)\<[JsonWebAccessToken](/docs/api-reference/json-web-tokens/json-web-access-token), [BasicResponse](/docs/api-reference/responses/basic-response)>>

A `NordigenApiResponse` containing the refreshed `JsonWebAccessToken` if the request was successful.

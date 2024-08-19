---
title: ApiRateLimits
---

The `ApiRateLimits` class represents the rate limits of the GoCardless API.

## Properties

### `RequestLimit` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)

Indicates the maximum number of allowed requests within the defined time window. Usually populated in every response.

### `RemainingRequests` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)

Indicates the number of remaining requests you can make in the current time window. Usually populated in every response.

### `RemainingSecondsInTimeWindow` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)

Indicates the time remaining in the current time window (in seconds). Usually populated in every response.

### `RequestLimitAccountsEndpoint` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)

Indicates the maximum number of allowed requests to the [AccountsEndpoint](/docs/api-reference/endpoints/accounts-endpoint) within the defined time window. Only populated in responses from the [AccountsEndpoint](/docs/api-reference/endpoints/accounts-endpoint).

### `RemainingRequestsAccountsEndpoint` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)

Indicates the number of remaining requests to the [AccountsEndpoint](/docs/api-reference/endpoints/accounts-endpoint) you can make in the current time window. Only populated in responses from the [AccountsEndpoint](/docs/api-reference/endpoints/accounts-endpoint).

### `RemainingSecondsInTimeWindowAccountsEndpoint` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)

Indicates the time remaining in the current time window (in seconds) for requests to the [AccountsEndpoint](/docs/api-reference/endpoints/accounts-endpoint). Only populated in responses from the [AccountsEndpoint](/docs/api-reference/endpoints/accounts-endpoint).

## Constructor

```csharp
public ApiRateLimits(int requestLimit, int remainingRequests, int remainingTimeInTimeWindow,
      int maxAccountRequests, int remainingAccountRequests, int remainingTimeInAccountTimeWindow)
```

### Parameters

#### `requestLimit` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)?

Indicates the maximum number of allowed requests within the defined time window. Usually populated in every response.

#### `remainingRequests` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)?

Indicates the number of remaining requests you can make in the current time window. Usually populated in every response.

#### `remainingSecondsInTimeWindow` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)?

Indicates the time remaining in the current time window (in seconds). Usually populated in every response.

#### `requestLimitAccountsEndpoint` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)?

Indicates the maximum number of allowed requests to the [AccountsEndpoint](/docs/api-reference/endpoints/accounts-endpoint) within the defined time window. Only populated in responses from the [AccountsEndpoint](/docs/api-reference/endpoints/accounts-endpoint).

#### `remainingRequestsAccountsEndpoint` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)?

Indicates the number of remaining requests to the [AccountsEndpoint](/docs/api-reference/endpoints/accounts-endpoint) you can make in the current time window. Only populated in responses from the [AccountsEndpoint](/docs/api-reference/endpoints/accounts-endpoint).

#### `remainingSecondsInTimeWindowAccountsEndpoint` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)?

Indicates the time remaining in the current time window (in seconds) for requests to the [AccountsEndpoint](/docs/api-reference/endpoints/accounts-endpoint). Only populated in responses from the [AccountsEndpoint](/docs/api-reference/endpoints/accounts-endpoint).

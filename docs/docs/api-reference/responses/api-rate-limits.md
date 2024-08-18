---
title: ApiRateLimits
---

The `ApiRateLimits` class represents the rate limits of the GoCardless API.

## Properties

### `RequestLimit` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)

Indicates the maximum number of allowed requests within the defined time window.

### `RemainingRequests` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)

Indicates the number of remaining requests you can make in the current time window.

### `RemainingSecondsInTimeWindow` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)

Indicates the time remaining in the current time window (in seconds).

### `RequestLimitAccountsEndpoint` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)

Indicates the maximum number of allowed requests to the [AccountsEndpoint](/docs/api-reference/endpoints/accounts-endpoint) within the defined time window.

### `RemainingRequestsAccountsEndpoint` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)

Indicates the number of remaining requests to the [AccountsEndpoint](/docs/api-reference/endpoints/accounts-endpoint) you can make in the current time window.

### `RemainingSecondsInTimeWindowAccountsEndpoint` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)

Indicates the time remaining in the current time window (in seconds) for requests to the [AccountsEndpoint](/docs/api-reference/endpoints/accounts-endpoint).

## Constructor

```csharp
public ApiRateLimits(int requestLimit, int remainingRequests, int remainingTimeInTimeWindow,
      int maxAccountRequests, int remainingAccountRequests, int remainingTimeInAccountTimeWindow)
```

### Parameters

#### `requestLimit` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)

Indicates the maximum number of allowed requests within the defined time window.

#### `remainingRequests` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)

Indicates the number of remaining requests you can make in the current time window.

#### `remainingSecondsInTimeWindow` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)

Indicates the time remaining in the current time window (in seconds).

#### `requestLimitAccountsEndpoint` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)

Indicates the maximum number of allowed requests to the [AccountsEndpoint](/docs/api-reference/endpoints/accounts-endpoint) within the defined time window.

#### `remainingRequestsAccountsEndpoint` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)

Indicates the number of remaining requests to the [AccountsEndpoint](/docs/api-reference/endpoints/accounts-endpoint) you can make in the current time window.

#### `remainingSecondsInTimeWindowAccountsEndpoint` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)

Indicates the time remaining in the current time window (in seconds) for requests to the [AccountsEndpoint](/docs/api-reference/endpoints/accounts-endpoint).

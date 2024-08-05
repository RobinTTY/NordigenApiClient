---
title: NordigenApiResponse
---

The `NordigenApiResponse` class is the common type for all responses returned from the GoCardless API. Through its `Result` and `Error` properties you can access the result of a request.

## Properties

### `statusCode` - [HttpStatusCode](https://learn.microsoft.com/en-us/dotnet/api/system.net.httpstatuscode)

The status code returned by the API.

### `isSuccess` - [bool](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)

Indicates whether the HTTP response was successful.

### `result` - TResult?

The result returned by the API. Null if the the HTTP response was not successful.

### `apiError` - TError?

The error returned by the API. Null if the HTTP response was successful.

## Constructor

```csharp
public NordigenApiResponse(HttpStatusCode statusCode, bool isSuccess, TResult? result, TError? apiError)
```

### Parameters

#### `StatusCode` - [HttpStatusCode](https://learn.microsoft.com/en-us/dotnet/api/system.net.httpstatuscode)

The status code returned by the API.

#### `IsSuccess` - [bool](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)

Indicates whether the HTTP response was successful.

#### `Result` - TResult?

The result returned by the API. Null if the the HTTP response was not successful.

#### `Error` - TError?

The error returned by the API. Null if the HTTP response was successful.

## Handling the `NordigenApiResponse` type

To learn more about how to best work with the `NordigenApiResponse` type see the [Handling API responses](/docs/handling-api-responses) guide.

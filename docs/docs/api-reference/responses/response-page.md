---
title: ResponsePage<T>
---

The `ResponsePage<T>` class represents a paged response from the GoCardless API.

## Properties

### `Count` - [uint](https://learn.microsoft.com/en-us/dotnet/api/system.uint32)

The total number of items that can be accessed via the paged responses (not necessarily through the current page).

### `Next` - [Uri](https://learn.microsoft.com/en-us/dotnet/api/system.uri)?

The URI of the next response page.

### `Previous` - [Uri](https://learn.microsoft.com/en-us/dotnet/api/system.uri)?

The URI of the last response page.

### `Results` - [List\<T\>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)

The results that were fetched with this page.

## Constructor

```csharp
public ResponsePage(uint count, Uri? next, Uri? previous, List<T> results)
```

### Parameters

#### `count` - [uint](https://learn.microsoft.com/en-us/dotnet/api/system.uint32)

The total number of items that can be accessed via the paged responses (not necessarily through the current page).

#### `next` - [Uri](https://learn.microsoft.com/en-us/dotnet/api/system.uri)?

The URI of the next response page.

#### `previous` - [Uri](https://learn.microsoft.com/en-us/dotnet/api/system.uri)?

The URI of the last response page.

#### `results` - [List\<T\>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)

## Methods

### `GetNextPage`

Gets the next `ResponsePage<T>`, linked to the current one.

```csharp
public async Task<NordigenApiResponse<ResponsePage<T>, BasicResponse>?>
      GetNextPage(NordigenClient nordigenClient, CancellationToken cancellationToken = default)
```

#### Parameters

##### `nordigenClient` - [NordigenClient](/docs/api-reference/nordigen-client)

The client to use to retrieve the page.

##### `cancellationToken` - [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)

A token to signal cancellation of the operation.

#### Returns

[Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)\<[NordigenApiResponse](/docs/api-reference/responses/nordigen-api-response)\<[ResponsePage\<T\>](/docs/api-reference/responses/response-page), [BasicResponse](/docs/api-reference/responses/basic-response)>?\>

A `NordigenApiResponse` containing either the next `ResponsePage<T>` or null if there is no next page to retrieve (if the request is successful).

### `GetPreviousPage`

Gets the previous `ResponsePage<T>`, linked to the current one.

```csharp
public async Task<NordigenApiResponse<ResponsePage<T>, BasicResponse>?>
      GetPreviousPage(NordigenClient nordigenClient, CancellationToken cancellationToken = default)
```

#### Parameters

##### `nordigenClient` - [NordigenClient](/docs/api-reference/nordigen-client)

The client to use to retrieve the page.

##### `cancellationToken` - [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)

A token to signal cancellation of the operation.

#### Returns

[Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)\<[NordigenApiResponse](/docs/api-reference/responses/nordigen-api-response)\<[ResponsePage\<T\>](/docs/api-reference/responses/response-page), [BasicResponse](/docs/api-reference/responses/basic-response)>?\>

A `NordigenApiResponse` containing either the previous `ResponsePage<T>` or null if there is no previous page to retrieve (if the request is successful).

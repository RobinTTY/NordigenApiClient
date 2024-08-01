---
title: AgreementsEndpoint
---

The `AgreementsEndpoint` class provides support for the API operations of the agreements endpoint.

## Methods

### `GetAgreements`

Gets a `ResponsePage` containing a given number of end user agreements.

```csharp
public async Task<NordigenApiResponse<ResponsePage<Agreement>, BasicResponse>>
  GetAgreements(int limit, int offset, CancellationToken cancellationToken = default)
```

#### Parameters

##### `limit` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)

Number of results to return per page.

##### `offset` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)

The initial index from which to return the results.

##### `cancellationToken` - [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)

A token to signal cancellation of the operation.

#### Returns

`Task<NordigenApiResponse<ResponsePage<Agreement>, BasicResponse>>`

A `NordigenApiResponse` containing the `ResponsePage` which in turn contains the end user agreement(s) if the request was successful.

### `GetAgreement`

Gets the end user agreement with the given id.

```csharp
public async Task<NordigenApiResponse<Agreement, BasicResponse>>
  GetAgreement(Guid id, CancellationToken cancellationToken = default)
```

Overloaded `id` parameter using the `string` type:

```csharp
public async Task<NordigenApiResponse<Agreement, BasicResponse>>
  GetAgreement(string id, CancellationToken cancellationToken = default)
```

#### Parameters

##### `id` - [Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid) | [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

The id of the agreement to retrieve.

##### `cancellationToken` - [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)

A token to signal cancellation of the operation.

#### Returns

`Task<NordigenApiResponse<Agreement, BasicResponse>>`

A `NordigenApiResponse` containing the end user agreement if the request was successful.

### `CreateAgreement`

Creates a new end user agreement which determines the scope and length of access to data provided by institutions.

```csharp
public async Task<NordigenApiResponse<Agreement, CreateAgreementError>>
  CreateAgreement(string institutionId, uint accessValidForDays = 90, uint maxHistoricalDays = 90,
        List<AccessScope>? accessScope = null, CancellationToken cancellationToken = default)
```

#### Parameters

##### `institutionId` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

The institution this agreement will refer to.

##### `accessValidForDays` - [uint](https://learn.microsoft.com/en-us/dotnet/api/system.uint32)

The length the access to the account will be valid for to request.

##### `maxHistoricalDays` - [uint](https://learn.microsoft.com/en-us/dotnet/api/system.uint32)

The length of the transaction history in days to request.

##### `accessScope` - List\<AccessScope\>?

The scope of information that will be available for access to request. By default all access scopes (balances, transactions and details) will be requested.

##### `cancellationToken` - [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)

A token to signal cancellation of the operation.

#### Returns

`Task<NordigenApiResponse<Agreement, CreateAgreementError>>`

A `NordigenApiResponse` containing the create end user agreement if the request was successful.

### `DeleteAgreement`

Deletes the end user agreement with the given id.

```csharp
public async Task<NordigenApiResponse<BasicResponse, BasicResponse>>
  DeleteAgreement(Guid id, CancellationToken cancellationToken = default)
```

Overloaded `id` parameter using the `string` type:

```csharp
public async Task<NordigenApiResponse<BasicResponse, BasicResponse>>
  DeleteAgreement(string id, CancellationToken cancellationToken = default)
```

#### Parameters

##### `id` - [Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid) | [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

The id of the agreement to delete.

##### `cancellationToken` - [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)

A token to signal cancellation of the operation.

#### Returns

`Task<NordigenApiResponse<BasicResponse, BasicResponse>>`

A `NordigenApiResponse` containing a confirmation of the deletion if the request was successful.

### `AcceptAgreement`

Accepts an end user agreement.

```csharp
public async Task<NordigenApiResponse<Agreement, BasicResponse>>
  AcceptAgreement(Guid id, string userAgent, string ipAddress,
        CancellationToken cancellationToken = default)
```

Overloaded `id` parameter using the `string` type:

```csharp
public async Task<NordigenApiResponse<Agreement, BasicResponse>>
  AcceptAgreement(string id, string userAgent, string ipAddress,
        CancellationToken cancellationToken = default)
```

:::danger Information
This functionality is only available to customers with an enterprise contract at GoCardless.
:::

#### Parameters

##### `id` - [Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid) | [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

The id of the end user agreement to accept.

##### `userAgent` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

User agent of the client that accepts the request.

##### `ipAddress` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

IP address of the client that accepts the request.

##### `cancellationToken` - [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)

A token to signal cancellation of the operation.

#### Returns

`Task<NordigenApiResponse<Agreement, BasicResponse>>`

A `NordigenApiResponse` containing the accepted end user agreement if the request was successful.

---
title: RequisitionsEndpoint
---

The `RequisitionsEndpoint` class provides support for the API operations of the requisitions endpoint.

## Methods

### `GetRequisitions`

Gets all requisitions belonging to your GoCardless account.

```csharp
public async Task<NordigenApiResponse<ResponsePage<Requisition>, BasicResponse>>
  GetRequisitions(int limit, int offset, CancellationToken cancellationToken = default)
```

#### Parameters

##### `limit` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)

Number of results to return per page.

##### `offset` - [int](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-int32)

The initial index from which to return the results.

##### `cancellationToken` - [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)

A token to signal cancellation of the operation.

#### Returns

[Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)\<[NordigenApiResponse](/docs/api-reference/responses/nordigen-api-response)\<[ResponsePage](/docs/api-reference/responses/response-page)\<[Requisition](/docs/api-reference/responses/requisition)>, [BasicResponse](/docs/api-reference/responses/basic-response)>>

A `NordigenApiResponse` containing a `ResponsePage` which contains contains a list of requisitions if the request was successful.

### `GetRequisition`

Gets the requisition with the given id.

```csharp
public async Task<NordigenApiResponse<Requisition, BasicResponse>>
  GetRequisition(Guid id, CancellationToken cancellationToken = default)
```

Overloaded `id` parameter using the `string` type:

```csharp
public async Task<NordigenApiResponse<Requisition, BasicResponse>>
  GetRequisition(string id, CancellationToken cancellationToken = default)
```

#### Parameters

##### `id` - [Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid) | [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

The id of the requisition to retrieve.

##### `cancellationToken` - [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)

A token to signal cancellation of the operation.

#### Returns

[Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)\<[NordigenApiResponse](/docs/api-reference/responses/nordigen-api-response)\<[Requisition](/docs/api-reference/responses/requisition), [BasicResponse](/docs/api-reference/responses/basic-response)\>\>

A `NordigenApiResponse` which contains the specified requisition if the request was successful.

### `CreateRequisition`

Creates a new requisition which is a collection of inputs for creating links and retrieving accounts.

```csharp
public async Task<NordigenApiResponse<Requisition, CreateRequisitionError>>
  CreateRequisition(string institutionId, Uri redirect,
  Guid? agreementId = null, string? reference = null, string userLanguage = "EN",
  string? socialSecurityNumber = null, bool accountSelection = false, bool redirectImmediate = false,
  CancellationToken cancellationToken = default);
```

#### Parameters

##### `institutionId` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

The id of the institution this requisition will be linked to.

##### `redirect` - [Uri](https://learn.microsoft.com/en-us/dotnet/api/system.uri)

URI where the end user will be redirected after finishing authentication.

##### `agreementId` - [Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid)?

The agreement this requisition will be linked to.

##### `reference` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

A unique ID which can be used for internal referencing. By default, set to a random GUID.

##### `userLanguage` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

Enforces a language for all end user steps hosted by GoCardless. Passed as a two-letter country code adhering to [ISO 639-1](https://wikipedia.org/wiki/ISO_639-1). For a list of all possible languages see the [GoCardless documentation](https://bankaccountdata.zendesk.com/hc/en-gb/articles/11529165730332-Is-it-possible-to-change-language-for-GoCardless-consent-step).

##### `socialSecurityNumber` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)?

Some European banks allow sending an end-user's SSN to check whether the SSN is valid. For bank availability see the [GoCardless Documentation](https://nordigen.zendesk.com/hc/en-gb/articles/6761166365085-SSN-verification-feature-for-specific-banks).

##### `accountSelection` - [bool](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)

Enables the end user to select which accounts they want to share (like joint accounts, accounts of children, etc.) if set to `true`. For details see the [GoCardless Documentation](https://nordigen.zendesk.com/hc/en-gb/articles/6760703821725-Account-selection-feature).

##### `redirectImmediate` - [bool](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)

Enables you to redirect end users back to your app immediately after they have given their consent to access the account information data from the bank, instead of waiting for transaction data being processed. Accounts endpoint status will be `PROCESSING` and you have to wait until account status is `READY` before you're able to query the transactions. For details see the [GoCardless Documentation](https://nordigen.zendesk.com/hc/en-gb/articles/6772857816477-Immediate-end-user-redirect-from-bank-after-consent).

##### `cancellationToken` - [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)

A token to signal cancellation of the operation.

#### Returns

[Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)\<[NordigenApiResponse](/docs/api-reference/responses/nordigen-api-response)\<[Requisition](/docs/api-reference/responses/requisition), [CreateRequisitionError](/docs/api-reference/errors/create-requisition-error)\>\>

A `NordigenApiResponse` which contains the created requisition if the request was successful.

### `DeleteRequisition`

Deletes the requisition with the given id.

```csharp
public async Task<NordigenApiResponse<BasicResponse, BasicResponse>>
  DeleteRequisition(Guid id, CancellationToken cancellationToken = default)
```

Overloaded `id` parameter using the `string` type:

```csharp
public async Task<NordigenApiResponse<BasicResponse, BasicResponse>>
  DeleteRequisition(string id, CancellationToken cancellationToken = default)
```

#### Parameters

##### `id` - [Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid) | [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

The id of the requisition to delete.

##### `cancellationToken` - [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)

A token to signal cancellation of the operation.

#### Returns

[Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)\<[NordigenApiResponse](/docs/api-reference/responses/nordigen-api-response)\<[BasicResponse](/docs/api-reference/responses/basic-response), [BasicResponse](/docs/api-reference/responses/basic-response)>>

A `NordigenApiResponse` containing a confirmation of the deletion if the request was successful.

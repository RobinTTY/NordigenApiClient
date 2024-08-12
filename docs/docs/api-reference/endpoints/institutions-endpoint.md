---
title: InstitutionsEndpoint
---

The `InstitutionsEndpoint` class provides support for the API operations of the institutions endpoint.

## Methods

### `GetInstitutions`

Gets a list of institutions supported by the Nordigen API. The list can be filtered by country and supported features. If multiple filters are applied, they are additive.

```csharp
public async Task<NordigenApiResponse<List<Institution>, BasicResponse>>
  GetInstitutions(
        string? country = null, bool? accessScopesSupported = null,
        bool? accountSelectionSupported = null, bool? businessAccountsSupported = null,
        bool? cardAccountsSupported = null, bool? corporateAccountsSupported = null,
        bool? privateAccountsSupported = null, bool? readRefundAccountSupported = null,
        bool? paymentsEnabled = null, bool? paymentSubmissionSupported = null,
        bool? pendingTransactionsSupported = null, bool? ssnVerificationSupported = null,
        CancellationToken cancellationToken = default)
```

Overloaded `country` parameter using the `SupportedCountry` type:

```csharp
public async Task<NordigenApiResponse<List<Institution>, BasicResponse>>
  GetInstitutions(
        SupportedCountry country, bool? accessScopesSupported = null,
        bool? accountSelectionSupported = null, bool? businessAccountsSupported = null,
        bool? cardAccountsSupported = null, bool? corporateAccountsSupported = null,
        bool? privateAccountsSupported = null, bool? readRefundAccountSupported = null,
        bool? paymentsEnabled = null, bool? paymentSubmissionSupported = null,
        bool? pendingTransactionsSupported = null, bool? ssnVerificationSupported = null,
        CancellationToken cancellationToken = default)
```

#### Parameters

##### `country` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)? | SupportedCountry

If set to `true` filters institutions by the country in which they operate. The country has to be specified by the two-letter country code following [ISO 3166](https://wikipedia.org/wiki/ISO_3166-1).

##### `accessScopesSupported` - [bool](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)

If set to `true` filters institutions by whether or not access scopes are supported.

##### `accountSelectionSupported` - [bool](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)

If set to `true` filters institutions by whether or not account selection is supported.

##### `businessAccountsSupported` - [bool](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)

If set to `true` filters institutions by whether or not business accounts are supported.

##### `cardAccountsSupported` - [bool](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)

If set to `true` filters institutions by whether or not card accounts are supported by this institution.

##### `corporateAccountsSupported` - [bool](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)

If set to `true` filters institutions by whether or not corporate accounts are supported.

##### `privateAccountsSupported` - [bool](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)

If set to `true` filters institutions by whether or not private accounts is supported.

##### `readRefundAccountSupported` - [bool](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)

If set to `true` filters filters institutions by whether or not read refund account is supported.

##### `readDebtorAccountSupported` - [bool](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)

If set to `true` filters institutions by whether or not the debtor account can be read before submitting payment.

##### `paymentsEnabled` - [bool](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)

If set to `true` filters institutions by whether or not payments are supported.

##### `paymentSubmissionSupported` - [bool](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)

If set to `true` filters institutions by whether or not payment submission is supported.

##### `pendingTransactionsSupported` - [bool](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)

If set to `true` filters institutions by whether or not pending transactions are supported.

##### `ssnVerificationSupported` - [bool](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)

If set to `true` filters institutions by whether or not SSN verification is supported.

##### `cancellationToken` - [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)

A token to signal cancellation of the operation.

#### Returns

[Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)\<[NordigenApiResponse](/docs/api-reference/responses/nordigen-api-response)\<[List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)\<[Institution](/docs/api-reference/responses/institution)\>, [BasicResponse](/docs/api-reference/responses/basic-response)\>\>

A `NordigenApiResponse` containing a list of supported institutions if the request was successful.

### `GetInstitution`

Gets a specific institution by id.

```csharp
public async Task<NordigenApiResponse<Institution, BasicResponse>>
  GetInstitution(string id, CancellationToken cancellationToken = default)
```

#### Parameters

##### `id` - [string](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type)

The id of the institution to retrieve (can be retrieved via the [GetInstitutions](#getinstitutions) method).

##### `cancellationToken` - [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)

A token to signal cancellation of the operation.

#### Returns

[Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task)\<[NordigenApiResponse](/docs/api-reference/responses/nordigen-api-response)\<[Institution](/docs/api-reference/responses/institution), [BasicResponse](/docs/api-reference/responses/basic-response)\>\>

A `NordigenApiResponse` containing the `Institution` matching the id if the request was successful.

---
title: NordigenClient
---

The `NordigenClient` class exposes the endpoints of the GoCardless API through its properties. It is used to execute all possible requests and retrieve the results. It also internally manages the JWT tokens used to authenticate with the API.

## Properties

#### `JsonWebTokenPair` - [JsonWebTokenPair](/docs/api-reference/json-web-tokens/json-web-token-pair)?

The JWT pair consisting of access and refresh token used to authenticate with the GoCardless API. This property can be used to set the token pair that is used when retrieving a new access/refresh token through the `TokenEndpoint`.

#### `TokenEndpoint` - [ITokenEndpoint](/docs/api-reference/endpoints/token-endpoint)

Provides support for the API operations of the tokens endpoint.

#### `InstitutionsEndpoint` - [IInstitutionsEndpoint](/docs/api-reference/endpoints/institutions-endpoint)

Provides support for the API operations of the institutions endpoint.

#### `AgreementsEndpoint` - [IAgreementsEndpoint](/docs/api-reference/endpoints/agreements-endpoint)

Provides support for the API operations of the agreements endpoint.

#### `RequisitionsEndpoint` - [IRequisitionsEndpoint](/docs/api-reference/endpoints/requisitions-endpoint)

Provides support for the API operations of the requisitions endpoint.

#### `AccountsEndpoint` - [IAccountsEndpoint](/docs/api-reference/endpoints/accounts-endpoint)

Provides support for the API operations of the accounts endpoint.

## Events

#### `TokenPairUpdated` - [EventHandler](https://learn.microsoft.com/en-us/dotnet/api/system.eventhandler)\<[TokenPairUpdatedEventArgs](/docs/api-reference/events/token-pair-updated-event-args)\>?

Raised whenever the `JsonWebTokenPair` property is successfully updated.
When the token is manually updated to be null, this event will not be raised.
For more information see [Handling Authentication Tokens](/docs/handling-authentication-tokens).

## Constructor

```csharp
public NordigenClient(HttpClient httpClient, NordigenClientCredentials credentials,
        JsonWebTokenPair? jsonWebTokenPair = null)
```

### Parameters

##### `httpClient` - [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)

The `HttpClient` instance that should be used to send all requests made by the `NordigenClient`. You can adjust the `BaseAddress` of the `HttpClient` as needed, for details see: [Using a different Base Address](/docs/using-a-different-base-address).

##### `credentials` - [NordigenClientCredentials](/docs/api-reference/nordigen-client-credentials)

The credentials you get from the [GoCardless Bank Account Data portal](https://bankaccountdata.gocardless.com/login/) (User secrets).

##### `jsonWebTokenPair` - [JsonWebTokenPair](/docs/api-reference/json-web-tokens/json-web-token-pair)?

An optional `JsonWebTokenPair` to reuse from an preceding successful authentication. These may for instance be retrieved from your database.

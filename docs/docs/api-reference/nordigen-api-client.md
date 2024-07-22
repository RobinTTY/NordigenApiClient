---
title: NordigenClient
---

The `NordigenClient` class exposes the endpoints of the GoCardless API through its properties. It is used to execute all possible requests and retrieve the results. It also internally manages the JWT tokens used to authenticate with the API.

## Constructor

```csharp
public NordigenClient(HttpClient httpClient, NordigenClientCredentials credentials,
        JsonWebTokenPair? jsonWebTokenPair = null)
```

### Arguments

##### `httpClient` - [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-8.0)

##### `credentials` - NordigenClientCredentials

##### `jsonWebTokenPair` - JsonWebTokenPair?

## Properties

```csharp
public JsonWebTokenPair? JsonWebTokenPair
```

```csharp
public ITokenEndpoint TokenEndpoint
```

```csharp
public IInstitutionsEndpoint InstitutionsEndpoint
```

```csharp
public IAgreementsEndpoint AgreementsEndpoint
```

```csharp
public IRequisitionsEndpoint RequisitionsEndpoint
```

```csharp
public IAccountsEndpoint AccountsEndpoint
```

```csharp
public event EventHandler<TokenPairUpdatedEventArgs>? TokenPairUpdated
```

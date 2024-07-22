---
title: Handling Authentication Tokens
---

The [`NordigenClient`](api-reference/nordigen-api-client) class manages the authentication tokens used to access most of the endpoints for you. It acquires the access and refresh token initially and refreshes the access token when needed.

You can manage certain aspects of the token handling yourself. These aspects are described in the following sections.

## Using the Token Endpoint

Access and refresh tokens for the GoCardless API are automatically acquired through the [`TokenEndpoint`](api-reference/token-endpoint) by the client. You can use it to manually acquire them as well:

```csharp
var response = await client.TokenEndpoint.GetTokenPair();
if (response.IsSuccess)
{
    Console.WriteLine($"Access token: {response.Result.AccessToken.EncodedToken}");
    Console.WriteLine($"Refresh token: {response.Result.RefreshToken.EncodedToken}");
}
```

The client can then be instructed to use these tokens as described in the next section.

## Using specific Tokens

The tokens which are used by the client can either be set on the constructor or via the `JsonWebTokenPair` property.

```csharp
// During construction of NordigenClient
using var httpClient = new HttpClient();
var credentials = new NordigenClientCredentials("my-secret-id", "my-secret-key");
JsonWebTokenPair tokenPair;   // You could for example have this saved in your database
var client = new NordigenClient(httpClient, credentials, tokenPair);

// via the JsonWebTokenPair property
var response = await client.TokenEndpoint.GetTokenPair();
client.JsonWebTokenPair = response.Result;
```

## Getting notified on refresh

To get notified whenever the token pair is updated you can subscribe to the `TokenPairUpdated` event:

```csharp
client.TokenPairUpdated += OnTokenPairUpdated;

void OnTokenPairUpdated(object? sender, TokenPairUpdatedEventArgs e)
{
    Console.WriteLine("Updated token pair:");
    Console.WriteLine($"Access Token: {e.JsonWebTokenPair.AccessToken.EncodedToken}");
    Console.WriteLine($"Refresh Token: {e.JsonWebTokenPair.RefreshToken.EncodedToken}");
}
```

:::warning
This event is only raised on successful updates of the token (by you or automatically by the client itself). When an update fails or the token is manually set to `null` no event will be raised.
:::

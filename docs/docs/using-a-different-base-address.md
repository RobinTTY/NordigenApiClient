---
title: Using a different Base Address
---

The API client uses the URL `https://bankaccountdata.gocardless.com/api/v2/` by default as the base address for the underlying `HttpClient` used to make all requests. There are some cases (e.g. [this issue](https://github.com/RobinTTY/NordigenApiClient/pull/12)) where you might want to change this URL.

You can change the base address very easily on the used HTTP client:

```csharp
var httpClient = new HttpClient {BaseAddress = new Uri("https://ob.gocardless.com/api/v2/")};
var credentials = new NordigenClientCredentials("...", "...");
var client = new NordigenClient(httpClient, credentials);
```

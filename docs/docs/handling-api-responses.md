---
title: Handling API responses
---

Every request you make using the [`NordigenClient`](/docs/api-reference/nordigen-client) will return a [`NordigenApiResponse`](/docs/api-reference/responses/nordigen-api-response). This type is following the [result pattern](https://www.milanjovanovic.tech/blog/functional-error-handling-in-dotnet-with-the-result-pattern) which is quite common in the .NET ecosystem. That means you can use it to determine if the request was successful through the `IsSuccess` property:

- If a request was successful (`IsSuccess` is `true`), the `Result` property will contain the response returned by the GoCardless API.
- If something went wrong (`IsSuccess` is `false`) the `Error` property will contain the reason the request failed as returned by the API.

Going further, if the request was successful and the `Result` property is populated with the response, the `Error` property will be `null` and vice versa. Therefore the recommended way to handle the `NordigenApiResponse` type is to always handle both possible cases by inspecting the `IsSuccess` property:

```csharp
var institutions = await client.InstitutionsEndpoint.GetInstitutions(SupportedCountry.UnitedKingdom);

if (response.IsSuccess)
{
  var institutions = response.Result;
   institutions.ForEach(institution => Console.WriteLine(institution.Name));
}
else
{
   Console.WriteLine(response.Error.Summary);
}
```

Since we know in which case the `Result` and `Error` property is null we don't need the conditional access operator. The possibility of either of those properties being null will be indicated correctly by the static analysis of your compiler.

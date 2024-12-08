---
title: Handling Rate Limits
---

The GoCardless API has [rate limits](https://bankaccountdata.zendesk.com/hc/en-gb/articles/11529637772188-Bank-Account-Data-API-Rate-Limits) depending on the endpoint you are using. With most endpoints you shouldn't run into problems since these limits are usually high enough for most uses.

The [Accounts endpoint](/docs/api-reference/endpoints/accounts-endpoint) has very tight limitations though. It currently has a limit of 10 requests a day per access scope. That means 10 requests to each of the [details](/docs/api-reference/endpoints/accounts-endpoint#getaccountdetails), [balances](/docs/api-reference/endpoints/accounts-endpoint#getbalances) and [transactions](/docs/api-reference/endpoints/accounts-endpoint#gettransactions) endpoints. In the future this limit will be lowered to 4 per day (no date on this as of now).

Unsuccessful requests to the API will count towards the general rate limits but not the more stringent limits of the [Accounts endpoint](/docs/api-reference/endpoints/accounts-endpoint). Only successful requests will count towards those.

## Checking API rate limits

You can check the rate limits as well as remaining requests with each request you make to the API. The property [`NordigenApiResponse.RateLimits`](/docs/api-reference/responses/nordigen-api-response#ratelimits---apiratelimits) will hold the returned information about the current API limits.

You can check the limits as follows:

```csharp
// Execute the request you want to make:
var bankAccountDetailsResponse = await client.AccountsEndpoint.GetAccountDetails(accountId);

Console.WriteLine(bankAccountDetailsResponse.RateLimits.RequestLimit);
Console.WriteLine(bankAccountDetailsResponse.RateLimits.RemainingRequests);
Console.WriteLine(bankAccountDetailsResponse.RateLimits.RemainingSecondsInTimeWindow);
Console.WriteLine(bankAccountDetailsResponse.RateLimits.RequestLimitAccountsEndpoint);
Console.WriteLine(bankAccountDetailsResponse.RateLimits.RemainingRequestsAccountsEndpoint);
Console.WriteLine(bankAccountDetailsResponse.RateLimits.RemainingSecondsInTimeWindowAccountsEndpoint);
```

It's important to handle these limits so your applications user experience isn't degraded. Refreshing data from bank accounts should be handled consciously, so you don't use up all your requests in a short time frame and aren't able to update for the rest of the day.

If you are a company with a contract with GoCardless you can probably get in contact with their team about increasing these limits.

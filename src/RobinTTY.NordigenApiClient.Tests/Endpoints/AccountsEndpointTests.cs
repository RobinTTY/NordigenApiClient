using System.Net;
using RobinTTY.NordigenApiClient.Models.Requests;

namespace RobinTTY.NordigenApiClient.Tests.Endpoints;

/// <summary>
/// Provides support for the API operations of the accounts endpoint.
/// <para>Reference: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/accounts"/></para>
/// </summary>
internal class AccountsEndpointTests
{
    private NordigenClient _apiClient = null!;

    [OneTimeSetUp]
    public void Setup()
    {
        _apiClient = TestExtensions.GetConfiguredClient();
    }

    [Test]
    public async Task GetAccount()
    {
        // Get existing requisition for sandbox account
        var requisitionResponse = await _apiClient.RequisitionsEndpoint.GetRequisition("26566a68-ccfa-4dfc-9e00-40b3978f0c3e");
        TestExtensions.AssertNordigenApiResponseIsSuccessful(requisitionResponse, HttpStatusCode.OK);

        var accountId = requisitionResponse.Result!.Accounts.SingleOrDefault(account => account == Guid.Parse("7e944232-bda9-40bc-b784-660c7ab5fe78"));
        Assert.That(accountId, Is.Not.EqualTo(default));

        // Test account retrieval
        var accountResponse = await _apiClient.AccountsEndpoint.GetAccount(accountId);
        TestExtensions.AssertNordigenApiResponseIsSuccessful(accountResponse, HttpStatusCode.OK);
        var account = accountResponse.Result!;
        Assert.That(account.InstitutionId, Is.EqualTo("SANDBOXFINANCE_SFIN0000"));
        Assert.That(account.Iban, Is.EqualTo("GL3343697694912188"));

        // Test balances retrieval
        var balancesResponse = await _apiClient.AccountsEndpoint.GetBalances(accountId);
        TestExtensions.AssertNordigenApiResponseIsSuccessful(balancesResponse, HttpStatusCode.OK);
        var balances = balancesResponse.Result!;
        Assert.That(balances, Has.Count.EqualTo(2));
        Assert.That(balances.Any(balance => balance.BalanceAmount.AmountParsed == (decimal)1913.12), Is.True);
        Assert.That(balances.Any(balance => balance.BalanceAmount.Currency == "EUR"), Is.True);

        // Test account details retrieval
        var detailsResponse = await _apiClient.AccountsEndpoint.GetAccountDetails(accountId);
        TestExtensions.AssertNordigenApiResponseIsSuccessful(detailsResponse, HttpStatusCode.OK);
        var details = detailsResponse.Result!;
        Assert.That(details.Iban, Is.EqualTo("GL3343697694912188"));
        Assert.That(details.CashAccountType, Is.EqualTo("CACC"));
        Assert.That(details.Name, Is.EqualTo("Main Account"));
        Assert.That(details.OwnerName, Is.EqualTo("John Doe"));

        // Test transaction retrieval
        var transactionsResponse = await _apiClient.AccountsEndpoint.GetTransactions(accountId);
        TestExtensions.AssertNordigenApiResponseIsSuccessful(transactionsResponse, HttpStatusCode.OK);
        var transactions = transactionsResponse.Result!;
        Assert.That(transactions.BookedTransactions.Any(t =>
        {
            var matchesAll = true;
            matchesAll &= t.BankTransactionCode == "PMNT";
            matchesAll &= t.DebtorAccount?.Iban == "GL3343697694912188";
            matchesAll &= t.DebtorName == "MON MOTHMA";
            matchesAll &= t.RemittanceInformationUnstructured == "For the support of Restoration of the Republic foundation";
            matchesAll &= t.TransactionAmount.Amount == "45.00";
            matchesAll &= t.TransactionAmount.AmountParsed == (decimal)45.00;
            matchesAll &= t.TransactionAmount.Currency == "EUR";
            matchesAll &= t.TransactionId == "2022080701927904-1";
            return matchesAll;
        }));
        Assert.That(transactions.PendingTransactions, Has.Count.EqualTo(1));
    }
}

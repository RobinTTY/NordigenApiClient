using System.Net;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Tests.Endpoints;

/// <summary>
/// Provides support for the API operations of the accounts endpoint.
/// <para>Reference: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/accounts"/></para>
/// </summary>
internal class AccountsEndpointTests
{
    private NordigenClient _apiClient = null!;
    private readonly Guid _accountId = Guid.Parse("7e944232-bda9-40bc-b784-660c7ab5fe78");

    [OneTimeSetUp]
    public void Setup()
    {
        _apiClient = TestExtensions.GetConfiguredClient();
    }

    /// <summary>
    /// Tests the retrieval of an account.
    /// Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/accounts/retrieve%20account%20metadata"/>
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task GetAccount()
    {
        var accountResponse = await _apiClient.AccountsEndpoint.GetAccount(_accountId);
        TestExtensions.AssertNordigenApiResponseIsSuccessful(accountResponse, HttpStatusCode.OK);
        var account = accountResponse.Result!;
        Assert.That(account.InstitutionId, Is.EqualTo("SANDBOXFINANCE_SFIN0000"));
        Assert.That(account.Iban, Is.EqualTo("GL3343697694912188"));
        Assert.That(account.Status, Is.EqualTo(BankAccountStatus.Ready));
    }

    /// <summary>
    /// Tests the retrieval of account balances.
    /// Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/accounts/accounts_balances_retrieve"/>
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task GetBalances()
    {
        var balancesResponse = await _apiClient.AccountsEndpoint.GetBalances(_accountId);
        TestExtensions.AssertNordigenApiResponseIsSuccessful(balancesResponse, HttpStatusCode.OK);
        var balances = balancesResponse.Result!;
        Assert.That(balances, Has.Count.EqualTo(2));
        Assert.That(balances.Any(balance => balance.BalanceAmount.AmountParsed == (decimal)1913.12), Is.True);
        Assert.That(balances.Any(balance => balance.BalanceAmount.Currency == "EUR"), Is.True);
        Assert.That(balances.All(balance => balance.BalanceType != BalanceType.Undefined));
    }

    /// <summary>
    /// Tests the retrieval of account details.
    /// Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/accounts/accounts_details_retrieve"/>
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task GetAccountDetails()
    {
        var detailsResponse = await _apiClient.AccountsEndpoint.GetAccountDetails(_accountId);
        TestExtensions.AssertNordigenApiResponseIsSuccessful(detailsResponse, HttpStatusCode.OK);
        var details = detailsResponse.Result!;
        Assert.That(details.Iban, Is.EqualTo("GL3343697694912188"));
        Assert.That(details.CashAccountType, Is.EqualTo("CACC"));
        Assert.That(details.Name, Is.EqualTo("Main Account"));
        Assert.That(details.OwnerName, Is.EqualTo("John Doe"));
    }

    /// <summary>
    /// Tests the retrieval of transactions.
    /// Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/accounts/accounts_transactions_retrieve"/>
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task GetTransactions()
    {
        var transactionsResponse = await _apiClient.AccountsEndpoint.GetTransactions(_accountId);
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
            return matchesAll;
        }));
        Assert.That(transactions.PendingTransactions, Has.Count.EqualTo(1));
    }

    /// <summary>
    /// Tests the retrieval of transactions within a specific time frame.
    /// Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/accounts/accounts_transactions_retrieve"/>
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task GetTransactionRange()
    {
        var startDate = new DateOnly(2022, 08, 04);
        var balancesResponse = await _apiClient.AccountsEndpoint.GetTransactions(_accountId, startDate, DateOnly.FromDateTime(DateTime.Now.Subtract(TimeSpan.FromMinutes(1))));
        TestExtensions.AssertNordigenApiResponseIsSuccessful(balancesResponse, HttpStatusCode.OK);
        Assert.That(balancesResponse.Result!.BookedTransactions, Has.Count.AtLeast(10));
    }

    /// <summary>
    /// Tests the retrieval of transactions within a specific time frame in the future. This should return an error.
    /// Route: <see href="https://nordigen.com/en/docs/account-information/integration/parameters-and-responses/#/accounts/accounts_transactions_retrieve"/>
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task GetTransactionRangeInFuture()
    {
        var dateInFuture = DateTime.Now.AddDays(1);
        var balancesResponse = await _apiClient.AccountsEndpoint.GetTransactions(_accountId, DateOnly.FromDateTime(dateInFuture), DateOnly.FromDateTime(dateInFuture.AddDays(1)));
        TestExtensions.AssertNordigenApiResponseIsUnsuccessful(balancesResponse, HttpStatusCode.BadRequest);
        Assert.Multiple(() =>
        {
            Assert.That(balancesResponse.Error!.StartDateError, Is.Not.Null);
            Assert.That(balancesResponse.Error!.EndDateError, Is.Not.Null);
        });
    }
}

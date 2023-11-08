using System.Net;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Tests.Endpoints;

internal class AccountsEndpointTests
{
    private readonly string[] _secrets = File.ReadAllLines("secrets.txt");
    private Guid _accountId;
    private NordigenClient _apiClient = null!;

    [OneTimeSetUp]
    public void Setup()
    {
        _accountId = Guid.Parse(_secrets[9]);
        _apiClient = TestExtensions.GetConfiguredClient();
    }

    /// <summary>
    /// Tests the retrieval of an account.
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task GetAccount()
    {
        var accountResponse = await _apiClient.AccountsEndpoint.GetAccount(_accountId);
        TestExtensions.AssertNordigenApiResponseIsSuccessful(accountResponse, HttpStatusCode.OK);
        var account = accountResponse.Result!;
        Assert.Multiple(() =>
        {
            Assert.That(account.InstitutionId, Is.EqualTo("SANDBOXFINANCE_SFIN0000"));
            Assert.That(account.Iban, Is.EqualTo("GL2010440000010445"));
            Assert.That(account.Status, Is.EqualTo(BankAccountStatus.Ready));
        });
    }

    /// <summary>
    /// Tests the retrieval of account balances.
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task GetBalances()
    {
        var balancesResponse = await _apiClient.AccountsEndpoint.GetBalances(_accountId);
        TestExtensions.AssertNordigenApiResponseIsSuccessful(balancesResponse, HttpStatusCode.OK);
        var balances = balancesResponse.Result!;
        Assert.Multiple(() =>
        {
            Assert.That(balances, Has.Count.EqualTo(2));
            Assert.That(balances.Any(balance => balance.BalanceAmount.Amount == (decimal) 1913.12), Is.True);
            Assert.That(balances.Any(balance => balance.BalanceAmount.Currency == "EUR"), Is.True);
            Assert.That(balances.All(balance => balance.BalanceType != BalanceType.Undefined));
        });
    }

    /// <summary>
    /// Tests the retrieval of account details.
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task GetAccountDetails()
    {
        var detailsResponse = await _apiClient.AccountsEndpoint.GetAccountDetails(_accountId);
        TestExtensions.AssertNordigenApiResponseIsSuccessful(detailsResponse, HttpStatusCode.OK);
        var details = detailsResponse.Result!;
        Assert.Multiple(() =>
        {
            Assert.That(details.Iban, Is.EqualTo("GL2010440000010445"));
            Assert.That(details.Name, Is.EqualTo("Main Account"));
            Assert.That(details.OwnerName, Is.EqualTo("Jane Doe"));
            Assert.That(details.CashAccountType, Is.EqualTo(CashAccountType.Current));
        });
    }

    /// <summary>
    /// Tests the retrieval of transactions.
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task GetTransactions()
    {
        var transactionsResponse = await _apiClient.AccountsEndpoint.GetTransactions(_accountId);
        TestExtensions.AssertNordigenApiResponseIsSuccessful(transactionsResponse, HttpStatusCode.OK);
        var transactions = transactionsResponse.Result!;
        Assert.Multiple(() =>
        {
            Assert.That(transactions.BookedTransactions.Any(t =>
            {
                var matchesAll = true;
                matchesAll &= t.BankTransactionCode == "PMNT";
                matchesAll &= t.DebtorAccount?.Iban == "GL2010440000010445";
                matchesAll &= t.DebtorName == "MON MOTHMA";
                matchesAll &= t.RemittanceInformationUnstructured ==
                              "For the support of Restoration of the Republic foundation";
                matchesAll &= t.TransactionAmount.Amount == (decimal) 45.00;
                matchesAll &= t.TransactionAmount.Currency == "EUR";
                return matchesAll;
            }));
            Assert.That(transactions.PendingTransactions, Has.Count.EqualTo(1));
        });
    }

    /// <summary>
    /// Tests the retrieval of transactions within a specific time frame.
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task GetTransactionRange()
    {
#if NET6_0_OR_GREATER
        var startDate = new DateOnly(2022, 08, 04);
        var balancesResponse =
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  await _apiClient.AccountsEndpoint.GetTransactions(_accountId, startDate, DateOnly.FromDateTime(DateTime.Now.Subtract(TimeSpan.FromHours(24))));
#else
        var startDate = new DateTime(2022, 08, 04);
        var balancesResponse = await _apiClient.AccountsEndpoint.GetTransactions(_accountId, startDate,
            DateTime.Now.Subtract(TimeSpan.FromMinutes(1)));
#endif

        TestExtensions.AssertNordigenApiResponseIsSuccessful(balancesResponse, HttpStatusCode.OK);
        Assert.That(balancesResponse.Result!.BookedTransactions, Has.Count.AtLeast(6));
    }

    /// <summary>
    /// Tests the retrieval of transactions within a specific time frame in the future. This should return an error.
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task GetTransactionRangeInFuture()
    {
        var dateInFuture = DateTime.Now.AddDays(1);
#if NET6_0_OR_GREATER
        var balancesResponse =
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   await _apiClient.AccountsEndpoint.GetTransactions(_accountId, DateOnly.FromDateTime(dateInFuture), DateOnly.FromDateTime(dateInFuture.AddDays(1)));
#else
        var balancesResponse =
            await _apiClient.AccountsEndpoint.GetTransactions(_accountId, dateInFuture, dateInFuture.AddDays(1));
#endif
        TestExtensions.AssertNordigenApiResponseIsUnsuccessful(balancesResponse, HttpStatusCode.BadRequest);
        Assert.Multiple(() =>
        {
            Assert.That(balancesResponse.Error!.StartDateError, Is.Not.Null);
            Assert.That(balancesResponse.Error!.EndDateError, Is.Not.Null);
        });
    }
}

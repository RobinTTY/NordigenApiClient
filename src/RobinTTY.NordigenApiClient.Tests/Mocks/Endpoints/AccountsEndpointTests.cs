using System.Net;
using FakeItEasy;
using RobinTTY.NordigenApiClient.Models.Responses;
using RobinTTY.NordigenApiClient.Tests.Shared;

namespace RobinTTY.NordigenApiClient.Tests.Mocks.Endpoints;

public class AccountsEndpointTests
{
    /// <summary>
    /// Tests the retrieval of an account.
    /// </summary>
    [Test]
    public async Task GetAccount()
    {
        var apiClient = TestHelpers.GetMockClient(TestHelpers.MockData.AccountsEndpointMockData.GetAccount, HttpStatusCode.OK);
        
        var accountResponse = await apiClient.AccountsEndpoint.GetAccount(A.Dummy<Guid>());
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(accountResponse, HttpStatusCode.OK);
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
    [Test]
    public async Task GetBalances()
    {
        var apiClient = TestHelpers.GetMockClient(TestHelpers.MockData.AccountsEndpointMockData.GetBalances, HttpStatusCode.OK);
        
        var balancesResponse = await apiClient.AccountsEndpoint.GetBalances(A.Dummy<Guid>());
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(balancesResponse, HttpStatusCode.OK);
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
    [Test]
    public async Task GetAccountDetails()
    {
        var apiClient = TestHelpers.GetMockClient(TestHelpers.MockData.AccountsEndpointMockData.GetAccountDetails, HttpStatusCode.OK);
        
        var detailsResponse = await apiClient.AccountsEndpoint.GetAccountDetails(A.Dummy<Guid>());
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(detailsResponse, HttpStatusCode.OK);
        var details = detailsResponse.Result!;

        Assert.Multiple(() =>
        {
            Assert.That(details.Iban, Is.EqualTo("GL2010440000010445"));
            Assert.That(details.Name, Is.EqualTo("Main Account"));
            Assert.That(details.Product, Is.EqualTo("Credit Card"));
            Assert.That(details.OwnerName, Is.EqualTo("Jane Doe"));
            Assert.That(details.ResourceId, Is.EqualTo("abc"));
            Assert.That(details.Currency, Is.EqualTo("EUR"));
            Assert.That(details.CashAccountType, Is.EqualTo(CashAccountType.Current));
        });
    }

    /// <summary>
    /// Tests the retrieval of transactions.
    /// </summary>
    [Test]
    public async Task GetTransactions()
    {
        var apiClient = TestHelpers.GetMockClient(TestHelpers.MockData.AccountsEndpointMockData.GetTransactions, HttpStatusCode.OK);

        var transactionsResponse = await apiClient.AccountsEndpoint.GetTransactions(A.Dummy<Guid>());
        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(transactionsResponse, HttpStatusCode.OK);
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
            Assert.That(transactions.PendingTransactions, Has.Count.GreaterThanOrEqualTo(1));
        });
    }

    /// <summary>
    /// Tests the retrieval of transactions within a specific time frame.
    /// </summary>
    [Test]
    public async Task GetTransactionRange()
    {
        var apiClient = TestHelpers.GetMockClient(TestHelpers.MockData.AccountsEndpointMockData.GetTransactionRange, HttpStatusCode.OK);

#if NET6_0_OR_GREATER
        var startDate = new DateOnly(2022, 08, 04);
        var balancesResponse =
            await apiClient.AccountsEndpoint.GetTransactions(A.Dummy<Guid>(), startDate,
                DateOnly.FromDateTime(DateTime.Now.Subtract(TimeSpan.FromHours(24))));
#else
        var startDate = new DateTime(2022, 08, 04);
        var balancesResponse = await apiClient.AccountsEndpoint.GetTransactions(A.Dummy<Guid>(), startDate,
            DateTime.Now.Subtract(TimeSpan.FromDays(1)));
#endif

        AssertionHelpers.AssertNordigenApiResponseIsSuccessful(balancesResponse, HttpStatusCode.OK);
        Assert.That(balancesResponse.Result!.BookedTransactions, Has.Count.EqualTo(2));
    }
    
    /// <summary>
    /// Tests the retrieval of transactions within a specific time frame in the future. This should return an error.
    /// </summary>
    [Test]
    public async Task GetTransactionRangeInFuture()
    {
        var apiClient = TestHelpers.GetMockClient(TestHelpers.MockData.AccountsEndpointMockData.GetTransactionRangeInFuture, HttpStatusCode.BadRequest);

        var dateInFuture = DateTime.Now.AddDays(1);
#if NET6_0_OR_GREATER
        var balancesResponse =
            await apiClient.AccountsEndpoint.GetTransactions(A.Dummy<Guid>(), DateOnly.FromDateTime(dateInFuture),
                DateOnly.FromDateTime(dateInFuture.AddDays(1)));
#else
        var balancesResponse =
            await apiClient.AccountsEndpoint.GetTransactions(A.Dummy<Guid>(), dateInFuture, dateInFuture.AddDays(1));
#endif
        
        AssertionHelpers.AssertNordigenApiResponseIsUnsuccessful(balancesResponse, HttpStatusCode.BadRequest);
        Assert.Multiple(() =>
        {
            Assert.That(balancesResponse.Error!.StartDateError, Is.Not.Null);
            Assert.That(balancesResponse.Error!.EndDateError, Is.Not.Null);
        });
    }
}

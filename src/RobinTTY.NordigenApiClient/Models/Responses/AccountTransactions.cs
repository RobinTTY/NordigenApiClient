using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// Holds transactions belonging to a bank account.
/// </summary>
public class AccountTransactions
{
    /// <summary>
    /// Transactions which were already booked to the bank account.
    /// </summary>
    [JsonPropertyName("booked")]
    public List<Transaction> BookedTransactions { get; }

    /// <summary>
    /// Transactions which are currently pending and have not been booked yet.
    /// </summary>
    [JsonPropertyName("pending")]
    public List<Transaction> PendingTransactions { get; }

    /// <summary>
    /// Creates a new instance of <see cref="AccountTransactions" />.
    /// </summary>
    /// <param name="bookedTransactions">Transactions which were already booked to the bank account.</param>
    /// <param name="pendingTransactions">Transactions which are currently pending and have not been booked yet.</param>
    [JsonConstructor]
    public AccountTransactions(List<Transaction> bookedTransactions, List<Transaction> pendingTransactions)
    {
        BookedTransactions = bookedTransactions;
        PendingTransactions = pendingTransactions;
    }
}

/// <summary>
/// Only used for deserialization purposes (to deal with returned JSON structure).
/// </summary>
internal class AccountTransactionsWrapper
{
    /// <summary>
    /// A list of transactions.
    /// </summary>
    [JsonPropertyName("transactions")]
    public AccountTransactions Transactions { get; }

    /// <summary>
    /// Creates a new instance of <see cref="AccountTransactionsWrapper" />.
    /// </summary>
    /// <param name="transactions">A list of transactions.</param>
    [JsonConstructor]
    public AccountTransactionsWrapper(AccountTransactions transactions) => Transactions = transactions;
}
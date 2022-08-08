using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// Detailed information on a <see cref="BankAccount"/>.
/// </summary>
public class BankAccountDetails
{
    /// <summary>
    /// Resource id used by the PSD2 interface.
    /// <para>For reference see: <see href="https://www.berlin-group.org/_files/ugd/c2914b_fec1852ec9c640568f5c0b420acf67d2.pdf"/></para>
    /// </summary>
    [JsonPropertyName("resourceId")]
    public string ResourceId { get; }
    /// <summary>
    /// The IBAN of the bank account.
    /// </summary>
    [JsonPropertyName("iban")]
    public string Iban { get; }
    /// <summary>
    /// The currency the account is denominated in.
    /// </summary>
    [JsonPropertyName("currency")]
    public string Currency { get; }
    /// <summary>
    /// Name of the legal account owner. If there is more than one owner, then two names might be noted here.
    /// </summary>
    [JsonPropertyName("ownerName")]
    public string OwnerName { get; }
    /// <summary>
    /// Name of the account, as assigned by the bank, in agreement with the account owner in
    /// order to provide an additional means of identification of the account.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; }
    /// <summary>
    /// Product name of the bank for this account.
    /// </summary>
    [JsonPropertyName("product")]
    public string Product { get; }
    /// <summary>
    /// External cash account type 1 code as defined by ISO 20022.
    /// </summary>
    [JsonPropertyName("cashAccountType")]
    public string CashAccountType { get; }

    /// <summary>
    /// Creates a new instance of <see cref="BankAccountDetails"/>.
    /// </summary>
    /// <param name="resourceId">Resource id used by the PSD2 interface.</param>
    /// <param name="iban">The IBAN of the bank account.</param>
    /// <param name="currency">The currency the account is denominated in.</param>
    /// <param name="ownerName">Name of the legal account owner. If there is more than one owner, then two names might be noted here.</param>
    /// <param name="name">Name of the account, as assigned by the bank, in agreement with the account owner in order to provide an additional
    /// means of identification of the account.</param>
    /// <param name="product">Product name of the bank for this account.</param>
    /// <param name="cashAccountType">External cash account type 1 code as defined by ISO 20022.</param>
    [JsonConstructor]
    public BankAccountDetails(string resourceId, string iban, string currency, string ownerName, string name, string product, string cashAccountType)
    {
        ResourceId = resourceId;
        Iban = iban;
        Currency = currency;
        OwnerName = ownerName;
        Name = name;
        Product = product;
        CashAccountType = cashAccountType;
    }
}

/// <summary>
/// Only used for deserialization purposes (to deal with returned JSON structure).
/// </summary>
internal class BankAccountDetailsWrapper
{
    /// <summary>
    /// Detailed information about a bank account.
    /// </summary>
    [JsonPropertyName("account")]
    public BankAccountDetails Account { get; set; }

    /// <summary>
    /// Creates a new instance of <see cref="BankAccountDetailsWrapper"/>.
    /// </summary>
    /// <param name="account">Detailed information about a bank account.</param>
    [JsonConstructor]
    public BankAccountDetailsWrapper(BankAccountDetails account)
    {
        Account = account;
    }
}

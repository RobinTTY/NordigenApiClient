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
    /// The BIC (Business Identifier Code) associated with the account.
    /// </summary>
    public string? Bic { get; }
    /// <summary>
    /// Basic Bank Account Number represents a country-specific bank account number.
    /// This data element is used for payment accounts which have no IBAN.
    /// </summary>
    [JsonPropertyName("bban")]
    public string? Bban { get; }
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
    /// Address of the legal account owner.
    /// </summary>
    [JsonPropertyName("ownerAddressUnstructured")]
    public string? OwnerAddressUnstructured { get; }
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
    /// Specifications that might be provided by the financial institution (e.g. characteristics of the account/relevant card).
    /// </summary>
    [JsonPropertyName("details")]
    public string? Details { get; }
    /// <summary>
    /// A financial institution might name a cash account associated with pending card transactions.
    /// </summary>
    [JsonPropertyName("linkedAccounts")]
    public string? LinkedAccounts { get; }
    /// <summary>
    /// An alias to a payment account via a registered mobile phone number.
    /// </summary>
    [JsonPropertyName("msisdn")]
    public string? Msisdn { get; }
    /// <summary>
    /// The account status:
    /// <list type="bullet">
    /// <item><description>"enabled": account is available</description></item>
    /// <item><description>"deleted": account is terminated</description></item>
    /// <item><description>"blocked": account is blocked e.g. for legal reasons</description></item>
    /// </list>
    /// If this field is not used, then the account is available in the sense of this specification.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; }
    /// <summary>
    /// Specifies the usage of the account:
    /// <list type="bullet">
    /// <item><description>PRIV: private personal account</description></item>
    /// <item><description>ORGA: professional account</description></item>
    /// </list>
    /// </summary>
    [JsonPropertyName("usage")]
    public string? Usage { get; }

    /// <summary>
    /// Creates a new instance of <see cref="BankAccountDetails"/>.
    /// </summary>
    /// <param name="resourceId">Resource id used by the PSD2 interface.</param>
    /// <param name="iban">The IBAN of the bank account.</param>
    /// <param name="bban">Basic Bank Account Number represents a country-specific bank account number.</param>
    /// <param name="currency">The currency the account is denominated in.</param>
    /// <param name="ownerName">Name of the legal account owner. If there is more than one owner, then two names might be noted here.</param>
    /// <param name="ownerAddressUnstructured">Address of the legal account owner.</param>
    /// <param name="name">Name of the account, as assigned by the bank, in agreement with the account owner in order to provide an additional
    /// means of identification of the account.</param>
    /// <param name="product">Product name of the bank for this account.</param>
    /// <param name="cashAccountType">External cash account type 1 code as defined by ISO 20022.</param>
    /// <param name="bic">The BIC (Business Identifier Code) associated with the account.</param>
    /// <param name="details">Specifications that might be provided by the financial institution (e.g. characteristics of the account/relevant card).</param>
    /// <param name="linkedAccounts">A financial institution might name a cash account associated with pending card transactions.</param>
    /// <param name="msisdn">An alias to a payment account via a registered mobile phone number.</param>
    /// <param name="status">The account status.</param>
    /// <param name="usage">Specifies whether the account is used by an institution or a private individual.</param>
    [JsonConstructor]
    public BankAccountDetails(string resourceId, string iban, string? bic, string? bban, string currency, string ownerName, string? ownerAddressUnstructured, string name, string product, string cashAccountType, string? details, string? linkedAccounts, string? msisdn, string? status, string? usage)
    {
        ResourceId = resourceId;
        Iban = iban;
        Bic = bic;
        Bban = bban;
        Currency = currency;
        OwnerName = ownerName;
        OwnerAddressUnstructured = ownerAddressUnstructured;
        Name = name;
        Product = product;
        CashAccountType = cashAccountType;
        Details = details;
        LinkedAccounts = linkedAccounts;
        Msisdn = msisdn;
        Status = status;
        Usage = usage;
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

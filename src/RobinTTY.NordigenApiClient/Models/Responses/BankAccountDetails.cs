﻿using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// Detailed information on a <see cref="BankAccount" />.
/// <para>
/// Reference:
/// <a href="https://developer.gocardless.com/bank-account-data/account-details">GoCardless documentation</a>
/// </para>
/// </summary>
public class BankAccountDetails
{
    /// <summary>
    /// Resource id used by the PSD2 interface.
    /// <para>
    /// For reference see:
    /// <a href="https://www.berlin-group.org/_files/ugd/c2914b_fec1852ec9c640568f5c0b420acf67d2.pdf">Berlin Group PSD2</a>
    /// </para>
    /// </summary>
    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; }

    /// <summary>
    /// The IBAN of the bank account.
    /// </summary>
    [JsonPropertyName("iban")]
    public string? Iban { get; }

    /// <summary>
    /// The BIC (Business Identifier Code) associated with the account.
    /// </summary>
    [JsonPropertyName("bic")]
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
    public string? OwnerName { get; }

    /// <summary>
    /// Address of the legal account owner in unstructured form.
    /// </summary>
    [JsonPropertyName("ownerAddressUnstructured")]
    public List<string>? OwnerAddressUnstructured { get; }

    /// <summary>
    /// Address of the legal account owner.
    /// </summary>
    [JsonPropertyName("ownerAddressStructured")]
    public Address? OwnerAddressStructured { get; }

    /// <summary>
    /// Name of the account, as assigned by the bank, in agreement with the account owner in
    /// order to provide an additional means of identification of the account.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; }

    /// <summary>
    /// Name of the account as defined by the end user within online channels.
    /// </summary>
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; }

    /// <summary>
    /// Product name of the bank for this account.
    /// </summary>
    [JsonPropertyName("product")]
    public string? Product { get; }

    /// <summary>
    /// Specifies the nature, or use, of the cash account as defined by ISO 20022.
    /// </summary>
    [JsonPropertyName("cashAccountType")]
    public CashAccountType? CashAccountType { get; }

    /// <summary>
    /// Specifications that might be provided by the financial institution (e.g. characteristics of the account/relevant
    /// card).
    /// </summary>
    [JsonPropertyName("details")]
    public string? Details { get; }

    /// <summary>
    /// Masked primary account number (unique identifier on credit cards, debit cards, and other types of payment cards).
    /// </summary>
    [JsonPropertyName("maskedPan")]
    public string? MaskedPan { get; }

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
    /// The status of the account.
    /// </summary>
    [JsonPropertyName("status")]
    public IsoBankAccountStatus? Status { get; }

    /// <summary>
    /// Specifies the usage of the account.
    /// </summary>
    [JsonPropertyName("usage")]
    public BankAccountUsage? Usage { get; }

    /// <summary>
    /// Creates a new instance of <see cref="BankAccountDetails" />.
    /// </summary>
    /// <param name="resourceId">Resource id used by the PSD2 interface.</param>
    /// <param name="iban">The IBAN of the bank account.</param>
    /// <param name="bban">Basic Bank Account Number represents a country-specific bank account number.</param>
    /// <param name="currency">The currency the account is denominated in.</param>
    /// <param name="ownerName">
    /// Name of the legal account owner. If there is more than one owner, then two names might be noted
    /// here.
    /// </param>
    /// <param name="ownerAddressUnstructured">Address of the legal account owner in unstructured form.</param>
    /// <param name="ownerAddressStructured">Address of the legal account owner.</param>
    /// <param name="name">
    /// Name of the account, as assigned by the bank, in agreement with the account owner in order to provide an additional
    /// means of identification of the account.
    /// </param>
    /// <param name="displayName">Name of the account as defined by the end user within online channels.</param>
    /// <param name="product">Product name of the bank for this account.</param>
    /// <param name="cashAccountType">External cash account type as defined by ISO 20022.</param>
    /// <param name="bic">The BIC (Business Identifier Code) associated with the account.</param>
    /// <param name="details">
    /// Specifications that might be provided by the financial institution (e.g. characteristics of the
    /// account/relevant card).
    /// </param>
    /// <param name="linkedAccounts">
    /// A financial institution might name a cash account associated with pending card
    /// transactions.
    /// </param>
    /// <param name="msisdn">An alias to a payment account via a registered mobile phone number.</param>
    /// <param name="status">The account status.</param>
    /// <param name="usage">Specifies whether the account is used by an institution or a private individual.</param>
    /// <param name="maskedPan">
    /// Masked primary account number (unique identifier on credit cards, debit cards, and other types
    /// of payment cards).
    /// </param>
    [JsonConstructor]
    public BankAccountDetails(string? resourceId, string? iban, string? bic, string? bban, string currency,
        string? ownerName, List<string>? ownerAddressUnstructured, Address? ownerAddressStructured, string? name,
        string? displayName, string? product, CashAccountType? cashAccountType, string? details, string? linkedAccounts,
        string? msisdn, IsoBankAccountStatus? status, BankAccountUsage? usage, string? maskedPan)
    {
        ResourceId = resourceId;
        Iban = iban;
        Bic = bic;
        Bban = bban;
        Currency = currency;
        OwnerName = ownerName;
        OwnerAddressUnstructured = ownerAddressUnstructured;
        Name = name;
        DisplayName = displayName;
        Product = product;
        CashAccountType = cashAccountType;
        Details = details;
        LinkedAccounts = linkedAccounts;
        Msisdn = msisdn;
        Status = status;
        Usage = usage;
        MaskedPan = maskedPan;
        OwnerAddressStructured = ownerAddressStructured;
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
    public BankAccountDetails Account { get; }

    /// <summary>
    /// Creates a new instance of <see cref="BankAccountDetailsWrapper" />.
    /// </summary>
    /// <param name="account">Detailed information about a bank account.</param>
    [JsonConstructor]
    public BankAccountDetailsWrapper(BankAccountDetails account) => Account = account;
}
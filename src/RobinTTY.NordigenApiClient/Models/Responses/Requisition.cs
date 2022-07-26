﻿using System.Text.Json.Serialization;
using RobinTTY.NordigenApiClient.Models.Requests;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// A collection of inputs for creating links and retrieving accounts via the Nordigen API.
/// </summary>
public class Requisition : CreateRequisitionRequest
{
    /// <summary>
    /// The id of the requisition assigned by the Nordigen API.
    /// </summary>
    [JsonPropertyName("id")]
    public Guid Id { get; }
    /// <summary>
    /// The time this requisition was created.
    /// </summary>
    [JsonPropertyName("created")]
    public DateTime Created { get; }
    /// <summary>
    /// The status of the requisition.
    /// </summary>
    [JsonPropertyName("status")]
    public RequisitionStatus Status { get; }
    /// <summary>
    /// The accounts linked to this requisition.
    /// </summary>
    [JsonPropertyName("accounts")]
    public List<Guid> Accounts { get; }
    /// <summary>
    /// The Uri which starts the authentication process.
    /// </summary>
    [JsonPropertyName("link")]
    public Uri AuthenticationLink { get; }

    /// <summary>
    /// Creates a new instance of <see cref="Requisition"/>.
    /// </summary>
    /// <param name="id">The id of the requisition assigned by the Nordigen API.</param>
    /// <param name="created">The time this requisition was created.</param>
    /// <param name="status">The status of the requisition.</param>
    /// <param name="accounts">The accounts linked to this requisition.</param>
    /// <param name="authenticationLink">The Uri which starts the authentication process.</param>
    /// <param name="redirect">URI where the end user will be redirected after finishing authentication.</param>
    /// <param name="institutionId">The id of the institution this requisition is linked to.</param>
    /// <param name="agreementId">The agreement this requisition is linked to.</param>
    /// <param name="reference">A unique ID set by the user of the API for internal referencing.</param>
    /// <param name="userLanguage">Enforces a language for all end user steps hosted by Nordigen passed as a two-letter country code <see href="https://wikipedia.org/wiki/ISO_639-1">(ISO 639-1)</see>.</param>
    /// <param name="socialSecurityNumber">Some European banks allow sending an end-user's SSN to check whether the SSN is valid.
    /// <para>For bank availability check: <see href="https://nordigen.com/en/blog/new-feature-ssn-verification-using-open-banking/"/>.</para></param>
    /// <param name="accountSelection">Enables the end user to select which accounts they want to share (like joint accounts, accounts of children, etc.) if set to true.
    /// <para>For details see: <see href="https://ob.helpscoutdocs.com/article/142-account-selection-feature"/>.</para></param>
    /// <param name="redirectImmediate">Enables you to redirect end users back to your app immediately after they have given their consent to access the account information data from the bank,
    /// instead of waiting for transaction data being processed. Accounts endpoint status will be PROCESSING and you have to wait until account status is READY
    /// before you're able to query the transactions.
    /// <para>For details see: <see href="https://ob.helpscoutdocs.com/article/145-immediate-end-user-redirect-from-bank-after-consent"/>.</para></param>
    [JsonConstructor]
    public Requisition(Uri redirect, string institutionId, Guid? agreementId, string reference, string userLanguage, string? socialSecurityNumber, bool accountSelection, bool redirectImmediate, Guid id, DateTime created, RequisitionStatus status, List<Guid> accounts, Uri authenticationLink) : base(redirect, institutionId, reference, userLanguage, agreementId, socialSecurityNumber, accountSelection, redirectImmediate)
    {
        Id = id;
        Created = created;
        Status = status;
        Accounts = accounts;
        AuthenticationLink = authenticationLink;
    }
}

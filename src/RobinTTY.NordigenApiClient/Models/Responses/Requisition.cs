using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// A collection of inputs for creating links and retrieving accounts via the Nordigen API.
/// </summary>
public class Requisition
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
    /// URI where the end user will be redirected after finishing authentication.
    /// </summary>
    [JsonPropertyName("redirect")]
    public Uri Redirect { get; set; }

    /// <summary>
    /// The id of the institution this requisition is linked to.
    /// </summary>
    [JsonPropertyName("institution_id")]
    public string InstitutionId { get; set; }

    /// <summary>
    /// The agreement this requisition is linked to.
    /// </summary>
    [JsonPropertyName("agreement")]
    public Guid? AgreementId { get; set; }

    /// <summary>
    /// A unique ID set by the user of the API for internal referencing.
    /// </summary>
    [JsonPropertyName("reference")]
    public string Reference { get; set; }

    /// <summary>
    /// Enforces a language for all end user steps hosted by Nordigen passed as a two-letter country code
    /// <a href="https://wikipedia.org/wiki/ISO_639-1">(ISO 639-1)</a>.
    /// </summary>
    [JsonPropertyName("user_language")]
    public string UserLanguage { get; set; }

    /// <summary>
    /// Some European banks allow sending an end-user's SSN to check whether the SSN is valid.
    /// <para>
    /// For bank availability check:
    /// <a
    ///     href="https://nordigen.zendesk.com/hc/en-gb/articles/6761166365085-SSN-verification-feature-for-specific-banks">
    /// GoCardless
    /// Documentation
    /// </a>
    /// .
    /// </para>
    /// </summary>
    [JsonPropertyName("ssn")]
    public string? SocialSecurityNumber { get; set; }

    /// <summary>
    /// Enables the end user to select which accounts they want to share (like joint accounts, accounts of children, etc.)
    /// if set to true.
    /// <para>
    /// For details see:
    /// <a href="https://nordigen.zendesk.com/hc/en-gb/articles/6760703821725-Account-selection-feature">
    /// GoCardless
    /// Documentation
    /// </a>
    /// .
    /// </para>
    /// </summary>
    [JsonPropertyName("account_selection")]
    public bool AccountSelection { get; set; }

    /// <summary>
    /// Enables you to redirect end users back to your app immediately after they have given their consent to access the
    /// account information data from the bank,
    /// instead of waiting for transaction data being processed. Accounts endpoint status will be PROCESSING and you have
    /// to wait until account status is READY
    /// before you're able to query the transactions.
    /// <para>
    /// For details see:
    /// <a
    ///     href="https://nordigen.zendesk.com/hc/en-gb/articles/6772857816477-Immediate-end-user-redirect-from-bank-after-consent">
    /// GoCardless
    /// Documentation
    /// </a>
    /// .
    /// </para>
    /// </summary>
    [JsonPropertyName("redirect_immediate")]
    public bool RedirectImmediate { get; set; }

    /// <summary>
    /// Creates a new instance of <see cref="Requisition" />.
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
    /// <param name="userLanguage">
    /// Enforces a language for all end user steps hosted by Nordigen passed as a two-letter country
    /// code <a href="https://wikipedia.org/wiki/ISO_639-1">(ISO 639-1)</a>.
    /// </param>
    /// <param name="socialSecurityNumber">
    /// Some European banks allow sending an end-user's SSN to check whether the SSN is valid.
    /// <para>
    /// For bank availability check:
    /// <a
    ///     href="https://nordigen.zendesk.com/hc/en-gb/articles/6761166365085-SSN-verification-feature-for-specific-banks">
    /// GoCardless
    /// Documentation
    /// </a>
    /// .
    /// </para>
    /// </param>
    /// <param name="accountSelection">
    /// Enables the end user to select which accounts they want to share (like joint accounts, accounts of children, etc.)
    /// if set to true.
    /// <para>
    /// For details see:
    /// <a href="https://nordigen.zendesk.com/hc/en-gb/articles/6760703821725-Account-selection-feature">
    /// GoCardless
    /// Documentation
    /// </a>
    /// .
    /// </para>
    /// </param>
    /// <param name="redirectImmediate">
    /// Enables you to redirect end users back to your app immediately after they have given their consent to access the
    /// account information data from the bank,
    /// instead of waiting for transaction data being processed. Accounts endpoint status will be PROCESSING and you have
    /// to wait until account status is READY
    /// before you're able to query the transactions.
    /// <para>
    /// For details see:
    /// <see
    ///     href="https://nordigen.zendesk.com/hc/en-gb/articles/6772857816477-Immediate-end-user-redirect-from-bank-after-consent" />
    /// .
    /// </para>
    /// </param>
    [JsonConstructor]
    public Requisition(Guid id, DateTime created, RequisitionStatus status, List<Guid> accounts, Uri authenticationLink,
        Uri redirect, string institutionId, Guid? agreementId, string reference, string userLanguage,
        string? socialSecurityNumber, bool accountSelection, bool redirectImmediate)
    {
        Id = id;
        Created = created;
        Status = status;
        Accounts = accounts;
        AuthenticationLink = authenticationLink;
        Redirect = redirect;
        InstitutionId = institutionId;
        AgreementId = agreementId;
        Reference = reference;
        UserLanguage = userLanguage;
        SocialSecurityNumber = socialSecurityNumber;
        AccountSelection = accountSelection;
        RedirectImmediate = redirectImmediate;
    }
}
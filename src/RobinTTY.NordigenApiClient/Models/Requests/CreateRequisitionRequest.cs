using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Requests;

/// <summary>
/// The parts of a requisition that are necessary to create it via the Nordigen API.
/// </summary>
public class CreateRequisitionRequest
{
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
    public Guid AgreementId { get; set; }
    /// <summary>
    /// A unique ID set by the user of the API for internal referencing.
    /// </summary>
    [JsonPropertyName("reference")]
    public string Reference { get; set; }
    /// <summary>
    /// Enforces a language for all end user steps hosted by Nordigen passed as a two-letter country code <see href="https://wikipedia.org/wiki/ISO_639-1">(ISO 639-1)</see>.
    /// </summary>
    [JsonPropertyName("user_language")]
    public string UserLanguage { get; set; }
    /// <summary>
    /// Some European banks allow sending an end-user's SSN to check whether the SSN is valid.
    /// <para>For bank availability check: <see href="https://nordigen.com/en/blog/new-feature-ssn-verification-using-open-banking/"/>.</para>
    /// </summary>
    [JsonPropertyName("ssn")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SocialSecurityNumber { get; set; }
    /// <summary>
    /// Enables the end user to select which accounts they want to share (like joint accounts, accounts of children, etc.) if set to true.
    /// <para>For details see: <see href="https://ob.helpscoutdocs.com/article/142-account-selection-feature"/>.</para>
    /// </summary>
    [JsonPropertyName("account_selection")]
    public bool AccountSelection { get; set; }
    /// <summary>
    /// Enables you to redirect end users back to your app immediately after they have given their consent to access the account information data from the bank,
    /// instead of waiting for transaction data being processed. Accounts endpoint status will be PROCESSING and you have to wait until account status is READY
    /// before you're able to query the transactions.
    /// <para>For details see: <see href="https://ob.helpscoutdocs.com/article/145-immediate-end-user-redirect-from-bank-after-consent"/>.</para>
    /// </summary>
    [JsonPropertyName("redirect_immediate")]
    public bool RedirectImmediate { get; set; }

    /// <summary>
    /// Creates a new instance of <see cref="CreateRequisitionRequest"/>.
    /// </summary>
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
    public CreateRequisitionRequest(Uri redirect, string institutionId, Guid agreementId, string reference, string userLanguage, string? socialSecurityNumber, bool accountSelection, bool redirectImmediate)
    {
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

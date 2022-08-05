namespace RobinTTY.NordigenApiClient.Models.Requests;

/// <summary>
/// The parts of a requisition that are necessary to create it via the Nordigen API.
/// </summary>
public class CreateRequisitionRequest
{
    /// <summary>
    /// URI where the end user will be redirected after finishing authentication.
    /// </summary>
    public Uri Redirect { get; }
    /// <summary>
    /// The id of the institution this requisition is linked to.
    /// </summary>
    public string InstitutionId { get; }
    /// <summary>
    /// The agreement this requisition is linked to.
    /// </summary>
    public Guid AgreementId { get; }
    /// <summary>
    /// A unique ID set by the user of the API for internal referencing.
    /// </summary>
    public string Reference { get; }
    /// <summary>
    /// Enforces a language for all end user steps hosted by Nordigen passed as a two-letter country code <see href="https://wikipedia.org/wiki/ISO_639-1">(ISO 639-1)</see>.
    /// </summary>
    public string UserLanguage { get; }
    /// <summary>
    /// Some European banks allow sending an end-user's SSN to check whether the SSN is valid.
    /// <para>For bank availability check: <see href="https://nordigen.com/en/blog/new-feature-ssn-verification-using-open-banking/"/>.</para>
    /// </summary>
    public string SocialSecurityNumber { get; }
    /// <summary>
    /// Enables the end user to select which accounts they want to share (like joint accounts, accounts of children, etc.) if set to true.
    /// <para>For details see: <see href="https://ob.helpscoutdocs.com/article/142-account-selection-feature"/>.</para>
    /// </summary>
    public bool AccountSelection { get; }
    /// <summary>
    /// Enables you to redirect end users back to your app immediately after they have given their consent to access the account information data from the bank,
    /// instead of waiting for transaction data being processed. Accounts endpoint status will be PROCESSING and you have to wait until account status is READY
    /// before you're able to query the transactions.
    /// <para>For details see: <see href="https://ob.helpscoutdocs.com/article/145-immediate-end-user-redirect-from-bank-after-consent"/>.</para>
    /// </summary>
    public bool RedirectImmediate { get; }
}

using RobinTTY.NordigenApiClient.Models.Jwt;

namespace RobinTTY.NordigenApiClient.Contracts;

/// <summary>
/// Client used to access the Nordigen API endpoints.
/// </summary>
public interface INordigenClient
{
    /// <summary>
    /// A pair consisting of access/refresh token used to authenticate with the Nordigen API.
    /// </summary>
    JsonWebTokenPair? JsonWebTokenPair { get; set; }

    /// <summary>
    /// Provides support for the API operations of the tokens endpoint.
    /// <para>
    /// Reference: <a href="https://developer.gocardless.com/bank-account-data/endpoints">GoCardless Documentation</a>
    /// </para>
    /// </summary>
    ITokenEndpoint TokenEndpoint { get; }

    /// <summary>
    /// Provides support for the API operations of the institutions endpoint.
    /// <para>
    /// Reference: <a href="https://developer.gocardless.com/bank-account-data/endpoints">GoCardless Documentation</a>
    /// </para>
    /// </summary>
    IInstitutionsEndpoint InstitutionsEndpoint { get; }

    /// <summary>
    /// Provides support for the API operations of the agreements endpoint.
    /// <para>
    /// Reference: <a href="https://developer.gocardless.com/bank-account-data/endpoints">GoCardless Documentation</a>
    /// </para>
    /// </summary>
    IAgreementsEndpoint AgreementsEndpoint { get; }

    /// <summary>
    /// Provides support for the API operations of the requisitions endpoint.
    /// <para>
    /// Reference: <a href="https://developer.gocardless.com/bank-account-data/endpoints">GoCardless Documentation</a>
    /// </para>
    /// </summary>
    IRequisitionsEndpoint RequisitionsEndpoint { get; }

    /// <summary>
    /// Provides support for the API operations of the accounts endpoint.
    /// <para>
    /// Reference: <a href="https://developer.gocardless.com/bank-account-data/endpoints">GoCardless Documentation</a>
    /// </para>
    /// </summary>
    IAccountsEndpoint AccountsEndpoint { get; }

    /// <summary>
    /// Occurs whenever the <see cref="NordigenClient.JsonWebTokenPair" /> is successfully updated.
    /// When the token is manually updated to be null, this event will not be raised.
    /// </summary>
    event EventHandler<TokenPairUpdatedEventArgs>? TokenPairUpdated;
}

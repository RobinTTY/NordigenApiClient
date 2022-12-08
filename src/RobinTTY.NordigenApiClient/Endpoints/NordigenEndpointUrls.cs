namespace RobinTTY.NordigenApiClient.Endpoints;

internal static class NordigenEndpointUrls
{
    private const string Base = "https://ob.nordigen.com/api/v2/";
    internal const string TokensEndpoint = Base + "token/";
    internal const string AccountsEndpoint = Base + "accounts/";
    internal const string AgreementsEndpoint = Base + "agreements/enduser/";
    internal const string InstitutionsEndpoint = Base + "institutions/";
    internal const string RequisitionsEndpoint = Base + "requisitions/";
}

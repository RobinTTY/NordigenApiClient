namespace RobinTTY.NordigenApiClient.Endpoints;
internal class NordigenEndpointUrls
{
    private const string Base = "https://ob.nordigen.com/api/v2/";
    internal static readonly string TokensEndpoint = Base + "token/";
    internal static readonly string AccountsEndpoint = Base + "agreements/enduser/";
    internal static readonly string InstitutionsEndpoint = Base + "insitutions/";
    internal static readonly string RequisitionsEndpoint = Base + "requisitions/";
}

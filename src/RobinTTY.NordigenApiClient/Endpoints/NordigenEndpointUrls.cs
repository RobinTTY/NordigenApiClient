namespace RobinTTY.NordigenApiClient.Endpoints;

internal static class NordigenEndpointUrls
{
    private const string DefaultBase = "https://bankaccountdata.gocardless.com/api/v2/";

    internal static string TokensEndpoint(string? baseUrl = null)
    {
        return (baseUrl ?? DefaultBase) + "token/";
    }

    internal static string AccountsEndpoint(string? baseUrl = null)
    {
        return (baseUrl ?? DefaultBase) + "accounts/";
    }

    internal static string AgreementsEndpoint(string? baseUrl = null)
    {
        return (baseUrl ?? DefaultBase) + "agreements/enduser/";
    }

    internal static string InstitutionsEndpoint(string? baseUrl = null)
    {
        return (baseUrl ?? DefaultBase) + "institutions/";
    }

    internal static string RequisitionsEndpoint(string? baseUrl = null)
    {
        return (baseUrl ?? DefaultBase) + "requisitions/";
    }
}
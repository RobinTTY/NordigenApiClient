using RobinTTY.NordigenApiClient.Endpoints;
using RobinTTY.NordigenApiClient.Models;
using RobinTTY.NordigenApiClient.Models.Jwt;
using RobinTTY.NordigenApiClient.Utility;

namespace RobinTTY.NordigenApiClient;

public class NordigenClient
{
    internal HttpClient HttpClient;
    internal NordigenClientCredentials Credentials;
    private JsonWebTokenPair? _jwtTokenPair;
    
    public ITokenEndpoint TokenEndpoint { get; }
    public IInstitutionsEndpoint InstitutionsEndpoint { get; }

    public NordigenClient(HttpClient httpClient, NordigenClientCredentials credentials)
    {
        HttpClient = httpClient;
        Credentials = credentials;
        _jwtTokenPair = null;

        TokenEndpoint = new TokenEndpoint(this);
        InstitutionsEndpoint = new InstitutionsEndpoint(this);
    }

    /// <summary>
    /// Tries to retrieve a valid <see cref="JsonWebTokenPair"/>.
    /// </summary>
    /// <param name="cancellationToken">An optional token to signal cancellation of the operation.</param>
    /// <returns>A valid <see cref="JsonWebTokenPair"/> if the operation was successful.
    /// Otherwise returns null.</returns>
    public async Task<JsonWebTokenPair?> TryGetValidTokenPair(CancellationToken cancellationToken = default)
    {
        // Request a new token if it is null or the refresh token is expired
        if (_jwtTokenPair == null || _jwtTokenPair.RefreshToken.IsExpired(TimeSpan.FromMinutes(1)))
        {
            var response = await TokenEndpoint.GetToken(cancellationToken);
            return response.IsSuccess ? response.Result : null;
        }

        // Refresh the current access token if it's expired (or valid for less than a minute)
        if (_jwtTokenPair.AccessToken.IsExpired(TimeSpan.FromMinutes(1)))
        {
            var response = await TokenEndpoint.RefreshToken(_jwtTokenPair.RefreshToken, cancellationToken);
            if (!response.IsSuccess) return null;
            
            // Update the token pair with the response
            _jwtTokenPair.AccessToken = response.Result!.AccessToken;
            _jwtTokenPair.AccessExpires = response.Result!.AccessExpires;
            return _jwtTokenPair;
        }

        // Token pair is still valid and can be returned
        return _jwtTokenPair;
    }
}

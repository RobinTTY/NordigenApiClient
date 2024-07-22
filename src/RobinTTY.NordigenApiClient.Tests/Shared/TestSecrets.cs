namespace RobinTTY.NordigenApiClient.Tests.Shared;

public class TestSecrets(
    string validSecretId,
    string validSecretKey,
    string expiredJwtAccessToken,
    string validJwtRefreshToken,
    string validAccountId,
    string validSecretIdWithWhitelist,
    string validSecretKeyWithWhitelist,
    string unauthorizedJwtToken)
{
    public string ValidSecretId { get; init; } = validSecretId;
    public string ValidSecretKey { get; init; } = validSecretKey;
    public string ExpiredJwtAccessToken { get; init; } = expiredJwtAccessToken;
    public string ValidJwtRefreshToken { get; init; } = validJwtRefreshToken;
    public string ValidAccountId { get; init; } = validAccountId;
    public string ValidSecretIdWithWhitelist { get; init; } = validSecretIdWithWhitelist;
    public string ValidSecretKeyWithWhitelist { get; init; } = validSecretKeyWithWhitelist;
    public string UnauthorizedJwtToken { get; init; } = unauthorizedJwtToken;
}

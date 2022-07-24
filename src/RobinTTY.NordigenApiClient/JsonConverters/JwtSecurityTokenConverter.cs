using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.JsonConverters;

public class JwtSecurityTokenConverter : JsonConverter<JwtSecurityToken>
{
    private static readonly JwtSecurityTokenHandler JwtTokenHandler = new();
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
    public override JwtSecurityToken? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return JwtTokenHandler.ReadJwtToken(reader.GetString());
    }

    public override void Write(Utf8JsonWriter writer, JwtSecurityToken value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}

using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.IdentityModel.JsonWebTokens;

namespace RobinTTY.NordigenApiClient.JsonConverters;

internal class JsonWebTokenConverter : JsonConverter<JsonWebToken>
{
    private static readonly JsonWebTokenHandler JwtTokenHandler = new();
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
    public override JsonWebToken? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return JwtTokenHandler.ReadJsonWebToken(reader.GetString());
    }

    public override void Write(Utf8JsonWriter writer, JsonWebToken value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.EncodedToken);
    }
}

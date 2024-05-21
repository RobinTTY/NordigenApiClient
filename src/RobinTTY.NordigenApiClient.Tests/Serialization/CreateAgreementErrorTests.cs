using System.Text.Json;
using RobinTTY.NordigenApiClient.JsonConverters;
using RobinTTY.NordigenApiClient.Models.Errors;

namespace RobinTTY.NordigenApiClient.Tests.Serialization;

public class CreateAgreementErrorTests
{
    /// <summary>
    /// Tests the correct deserialization of <see cref="CreateAgreementError" />.
    /// </summary>
    [Test]
    public void DeserializeTransactionWithSingleCurrencyExchange()
    {
        const string json =
            "{\n  \"summary\": [\n    \"Institution access scope dependencies error\",\n    \"Some Other Error Summary\"\n  ],\n  \"detail\": [\n    \"For this institution the following scopes are required together: [\\u0027details\\u0027, \\u0027balances\\u0027]\",\n    \"Some Other Error Detail\"\n  ],\n  \"status_code\": 400\n}\n";

        var options = new JsonSerializerOptions
        {
            Converters = {new StringArrayMergeConverter()}
        };
        var createAgreementError = JsonSerializer.Deserialize<CreateAgreementError>(json, options);

        Assert.Multiple(() =>
        {
            Assert.That(createAgreementError!.Summary, Is.Not.Null);
            Assert.That(createAgreementError.Detail, Is.Not.Null);
            Assert.That(createAgreementError.Summary,
                Is.EqualTo("Institution access scope dependencies error; Some Other Error Summary"));
            Assert.That(createAgreementError.Detail,
                Is.EqualTo(
                    "For this institution the following scopes are required together: ['details', 'balances']; Some Other Error Detail"));
        });
    }
}

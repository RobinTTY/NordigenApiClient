using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Responses;
public class MinimalBankAccount
{
    /// <summary>
    /// The IBAN of the account.
    /// </summary>
    [JsonPropertyName("iban")]
    public string Iban { get; }

    /// <summary>
    /// Creates a new instance of <see cref="MinimalBankAccount"/>.
    /// </summary>
    /// <param name="iban">The IBAN of the account.</param>
    public MinimalBankAccount(string iban)
    {
        Iban = iban;
    }
}

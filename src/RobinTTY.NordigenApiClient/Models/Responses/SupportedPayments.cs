using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// The payment products supported by an institution.
/// </summary>
public class SupportedPayments
{
    /// <summary>
    /// Supported payment products in the single-payment category.
    /// </summary>
    [JsonPropertyName("single-payment")]
    public List<PaymentProduct> SinglePayment { get; }

    /// <summary>
    /// Creates a new instance of <see cref="SupportedPayments" />
    /// </summary>
    /// <param name="singlePayment">Supported payment products in the single-payment category.</param>
    public SupportedPayments(List<PaymentProduct> singlePayment) => SinglePayment = singlePayment;
}

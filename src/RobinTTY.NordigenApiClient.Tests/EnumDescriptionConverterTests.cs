using System.Text.Json;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Tests;

internal class EnumDescriptionConverterTests
{
    /// <summary>
    /// Tests the serialization of enum values to the correct descriptor.
    /// </summary>
    /// <typeparam name="T">The enum type to serialize.</typeparam>
    /// <param name="enumValue">The enum value to serialize.</param>
    /// <param name="expectedSerializedValue">The expected descriptor value.</param>
    [Test]
    [TestCase(RequisitionStatus.GivingConsent, "GC")]
    [TestCase(RequisitionStatus.Expired, "EX")]
    [TestCase(RequisitionStatus.Suspended, "SU")]
    [TestCase(BalanceType.ClosingBooked, "closingBooked")]
    [TestCase(BalanceType.ForwardAvailable, "forwardAvailable")]
    [TestCase(BalanceType.Expected, "expected")]
    public void SerializeEnum<T>(T enumValue, string expectedSerializedValue)
    {
        var json = JsonSerializer.Serialize(enumValue);
        Assert.That(json, Is.EqualTo($"\"{expectedSerializedValue}\""));
    }

    /// <summary>
    /// Tests the deserialization of descriptors to the correct enum value.
    /// </summary>
    /// <typeparam name="T">The enum type to deserialize.</typeparam>
    /// <param name="descriptor">The input descriptor which to deserialize.</param>
    /// <param name="expectedDeserializedValue">The expected enum value.</param>
    [Test]
    [TestCase("GC", RequisitionStatus.GivingConsent)]
    [TestCase("EX", RequisitionStatus.Expired)]
    [TestCase("SU", RequisitionStatus.Suspended)]
    [TestCase("closingBooked", BalanceType.ClosingBooked)]
    [TestCase("forwardAvailable", BalanceType.ForwardAvailable)]
    [TestCase("expected", BalanceType.Expected)]
    public void DeserializeEnum<T>(string descriptor, T expectedDeserializedValue)
    {
        var enumValue = JsonSerializer.Deserialize<T>($"\"{descriptor}\"");
        Assert.That(enumValue, Is.EqualTo(expectedDeserializedValue));
    }
}

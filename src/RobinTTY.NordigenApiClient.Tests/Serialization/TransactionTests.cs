using System.Runtime.Serialization;
using System.Text.Json;
using RobinTTY.NordigenApiClient.JsonConverters;
using RobinTTY.NordigenApiClient.Models.Errors;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Tests.Serialization;

internal class TransactionTests
{
    /// <summary>
    /// Tests the correct deserialization of transactions with a single embedded currency exchange object.
    /// </summary>
    [Test]
    public void DeserializeTransactionWithSingleCurrencyExchange()
    {
        const string json =
            "{ \"transactionId\": \"AB123456789\", \"entryReference\": \"123456789\", \"bookingDate\": \"2023-03-20\", \"bookingDateTime\": \"2023-03-20T00:00:00+00:00\", \"transactionAmount\": { \"amount\": \"-33.06\", \"currency\": \"GBP\" }, \"currencyExchange\": { \"sourceCurrency\": \"USD\", \"exchangeRate\": \"1.20961887\", \"unitCurrency\": \"USD\", \"targetCurrency\": \"GBP\", \"instructedAmount\": { \"amount\": \"-33.06\", \"currency\": \"GBP\" } }, \"remittanceInformationUnstructured\": \"my reference here\", \"additionalInformation\": \"123456789\", \"proprietaryBankTransactionCode\": \"OTHER_PURCHASE\", \"merchantCategoryCode\": \"5045\", \"internalTransactionId\": \"abcdef\" }";

        var options = new JsonSerializerOptions
        {
            Converters = {new CultureSpecificDecimalConverter()}
        };
        var transaction = JsonSerializer.Deserialize<Transaction>(json, options);

        Assert.Multiple(() =>
        {
            Assert.That(transaction!.CurrencyExchange, Is.Not.Null);
            Assert.That(transaction.CurrencyExchange!.First().ExchangeRate, Is.EqualTo(1.20961887));
            Assert.That(transaction.CurrencyExchange!.First().InstructedAmount!.Amount, Is.EqualTo(-33.06));
            Assert.That(transaction.CurrencyExchange!.First().InstructedAmount!.Currency, Is.EqualTo("GBP"));
            Assert.That(transaction.CurrencyExchange!.First().SourceCurrency, Is.EqualTo("USD"));
            Assert.That(transaction.CurrencyExchange!.First().TargetCurrency, Is.EqualTo("GBP"));
            Assert.That(transaction.CurrencyExchange!.First().UnitCurrency, Is.EqualTo("USD"));
            Assert.That(transaction.CurrencyExchange!.First().QuotationDate, Is.Null);
        });
    }

    /// <summary>
    /// Tests the correct deserialization of transactions with multiple embedded currency exchange objects.
    /// </summary>
    [Test]
    public void DeserializeTransactionWithMultipleCurrencyExchange()
    {
        const string json =
            "{ \"transactionId\": \"AB123456789\", \"entryReference\": \"123456789\", \"bookingDate\": \"2023-03-20\", \"bookingDateTime\": \"2023-03-20T00:00:00+00:00\", \"transactionAmount\": { \"amount\": \"-33.06\", \"currency\": \"GBP\" }, \"currencyExchange\":[{\"sourceCurrency\":\"USD\",\"exchangeRate\":\"1.20961887\",\"unitCurrency\":\"USD\",\"targetCurrency\":\"GBP\"}], \"remittanceInformationUnstructured\": \"my reference here\", \"additionalInformation\": \"123456789\", \"proprietaryBankTransactionCode\": \"OTHER_PURCHASE\", \"merchantCategoryCode\": \"5045\", \"internalTransactionId\": \"abcdef\" }";

        var options = new JsonSerializerOptions
        {
            Converters = {new CultureSpecificDecimalConverter()}
        };
        var transaction = JsonSerializer.Deserialize<Transaction>(json, options);

        Assert.Multiple(() =>
        {
            Assert.That(transaction!.CurrencyExchange, Is.Not.Null);
            Assert.That(transaction.CurrencyExchange!.First().ExchangeRate, Is.EqualTo(1.20961887));
            Assert.That(transaction.CurrencyExchange!.First().SourceCurrency, Is.EqualTo("USD"));
            Assert.That(transaction.CurrencyExchange!.First().TargetCurrency, Is.EqualTo("GBP"));
            Assert.That(transaction.CurrencyExchange!.First().UnitCurrency, Is.EqualTo("USD"));
            Assert.That(transaction.CurrencyExchange!.First().QuotationDate, Is.Null);
        });
    }

    /// <summary>
    /// Tests that a malformed json throws a human readable error containing the raw json content of the API response.
    /// </summary>
    [Test]
    public async Task DeserializeWithException()
    {
        const string malformedJson =
            "{ \"transactionId\": \"AB123456789\", \"entryReference\": \"123456789\", \"bookingDate\": \"2023-03-20\", \"bookingDateTime\": \"2023-03-20T00:00:00+00:00\", \"transactionAmount\": { \"amount\": \"-33.06\", \"currency\": \"GBP\" }, \"currencyExchange\": [{ \"sourceCurrency\": \"USD\", \"exchangeRate\": \"1.20961887\", \"unitCurrency\": \"GBP\", \"targetCurrency\": \"GBP\" }], \"remittanceInformationUnstructured\": \"my reference here\", \"additionalInformation\": \"123456789\", \"proprietaryBankTransactionCode\": \"OTHER_PURCHASE\", \"merchantCategoryCode\": \"5045\", \"internalTransactionId\": \"abcdef\" }";
        var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(malformedJson)
        };

        try
        {
            await NordigenApiResponse<Transaction, AccountsError>.FromHttpResponse(httpResponse);
        }
        catch (SerializationException exception)
        {
            Assert.That(exception, Is.Not.Null);
            Assert.That(exception, Has.InnerException);
            Assert.That(exception.Message,
                Contains.Substring("Deserialization failed, please report this issue to the library author:"));
            Assert.That(exception.Message,
                Contains.Substring(
                    "The following JSON content caused the problem: { \"transactionId\": \"AB123456789\", \"entryReference\": \"123456789\", \"bookingDate\": \"2023-03-20\", \"bookingDateTime\":"));
        }
    }
}

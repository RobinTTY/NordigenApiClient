using System.Text.Json;
using RobinTTY.NordigenApiClient.Models.Responses;

namespace RobinTTY.NordigenApiClient.Tests.Serialization;

internal class TransactionTests
{
    [Test]
    public void DeserializeTransaction()
    {
        const string json = "{ \"transactionId\": \"AB123456789\", \"entryReference\": \"123456789\", \"bookingDate\": \"2023-03-20\", \"bookingDateTime\": \"2023-03-20T00:00:00+00:00\", \"transactionAmount\": { \"amount\": \"-33.06\", \"currency\": \"GBP\" }, \"currencyExchange\": { \"sourceCurrency\": \"USD\", \"exchangeRate\": \"1.20961887\", \"unitCurrency\": \"GBP\", \"targetCurrency\": \"GBP\" }, \"remittanceInformationUnstructured\": \"my reference here\", \"additionalInformation\": \"123456789\", \"proprietaryBankTransactionCode\": \"OTHER_PURCHASE\", \"merchantCategoryCode\": \"5045\", \"internalTransactionId\": \"abcdef\" }";
        var transaction = JsonSerializer.Deserialize<Transaction>(json);
        Assert.Multiple(() =>
        {
            Assert.That(transaction!.CurrencyExchange, Is.Not.Null);
            Assert.That(transaction!.CurrencyExchange!.ExchangeRate, Is.EqualTo("1.20961887"));
            Assert.That(transaction!.CurrencyExchange!.ExchangeRateParsed, Is.EqualTo(1.20961887));
            Assert.That(transaction!.CurrencyExchange!.SourceCurrency, Is.EqualTo("USD"));
            Assert.That(transaction!.CurrencyExchange!.TargetCurrency, Is.EqualTo("GBP"));
            Assert.That(transaction!.CurrencyExchange!.UnitCurrency, Is.EqualTo("GBP"));
            Assert.That(transaction!.CurrencyExchange!.QuotationDate, Is.Null);
        });
    }
}

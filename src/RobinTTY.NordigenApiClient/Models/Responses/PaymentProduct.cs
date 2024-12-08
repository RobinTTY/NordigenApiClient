using System.ComponentModel;
using System.Text.Json.Serialization;
using RobinTTY.NordigenApiClient.JsonConverters;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// A payment product offered by an institution.
/// </summary>
[JsonConverter(typeof(EnumDescriptionConverter<PaymentProduct>))]
public enum PaymentProduct
{
    /// <summary>
    /// An undefined payment product type. Assigned if the type couldn't be matched to any known types.
    /// </summary>
    Undefined,

    /// <summary>
    /// TARGET2 is the real-time gross settlement (RTGS) system owned and operated by the Eurosystem.
    /// </summary>
    [Description("T2P")]
    Target2Payments,

    /// <summary>
    /// SEPA Credit Transfer, more commonly abbreviated as SCT, is a payment processing scheme used for making one-time,
    /// euro-denominated fund transfers between banks and payment service providers (PSPs) in the SEPA area.
    /// </summary>
    [Description("SCT")]
    SepaCreditTransfers,

    /// <summary>
    /// Instant SEPA Credit Transfer supports money transfers of up to €100,000 between participating banks or PSPs in the
    /// SEPA area in real or near-real time.
    /// </summary>
    [Description("ISCT")]
    InstantSepaCreditTransfer,

    /// <summary>
    /// Cross-border payments are transactions sent from one country and received in a different country.
    /// </summary>
    [Description("CBCT")]
    CrossBorderCreditTransfers,

    /// <summary>
    /// Bacs Payment Schemes Limited (Bacs), previously known as Bankers' Automated Clearing System, is responsible for the
    /// clearing and settlement of UK automated direct debit and Bacs Direct Credit and the provision of third-party
    /// services.
    /// </summary>
    [Description("BACS")]
    BacsPaymentSchemesLimited,

    /// <summary>
    /// The Clearing House Automated Payment System (CHAPS) is a real-time gross settlement payment system used for
    /// sterling transactions in the United Kingdom.
    /// </summary>
    [Description("CHAPS")]
    ClearingHouseAutomatedPaymentSystem,

    /// <summary>
    /// The Faster Payments Service (FPS) is a United Kingdom banking initiative to reduce payment times between different
    /// banks' customer accounts to typically a few seconds, from the three working days that transfers usually take using
    /// the long-established BACS system.
    /// </summary>
    [Description("FPS")]
    FasterPaymentScheme,

    /// <summary>
    /// SWIFT payments are international electronic transactions facilitated by an intermediary bank.
    /// </summary>
    [Description("SWIFT")]
    SwiftPaymentService,

    /// <summary>
    /// A balance transfer is the transfer of the balance in an account to another account, often held at another
    /// institution. It is most commonly used when describing a credit card balance transfer.
    /// </summary>
    [Description("BT")]
    BalanceTransfer,

    /// <summary>
    /// Money transfer generally refers to one of several cashless modes of payment or payment systems.
    /// </summary>
    [Description("MT")]
    MoneyTransfer,

    /// <summary>
    /// A domestic transfer is a transfer completed between accounts that are held in the same country.
    /// </summary>
    [Description("DCT")]
    DomesticCreditTransfer,

    /// <summary>
    /// An instant domestic transfer is a transfer completed between accounts that are held in the same country in
    /// real-time.
    /// </summary>
    [Description("IDCT")]
    InstantDomesticCreditTransfer
}
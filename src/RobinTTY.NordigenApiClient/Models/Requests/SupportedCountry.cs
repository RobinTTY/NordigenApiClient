using System.ComponentModel;
using System.Text.Json.Serialization;
using RobinTTY.NordigenApiClient.JsonConverters;

namespace RobinTTY.NordigenApiClient.Models.Requests;

/// <summary>
/// Countries which are supported by the GoCardless API.
/// </summary>
[JsonConverter(typeof(EnumDescriptionConverter<SupportedCountry>))]
public enum SupportedCountry
{
    /// <summary>
    /// The country of Austria.
    /// </summary>
    [Description("AT")]
    Austria,

    /// <summary>
    /// The country of Belgium.
    /// </summary>
    [Description("BE")]
    Belgium,

    /// <summary>
    /// The country of Bulgaria.
    /// </summary>
    [Description("BG")]
    Bulgaria,

    /// <summary>
    /// The country of Croatia.
    /// </summary>
    [Description("HR")]
    Croatia,

    /// <summary>
    /// The country of Cyprus.
    /// </summary>
    [Description("CY")]
    Cyprus,

    /// <summary>
    /// The country of Czechia.
    /// </summary>
    [Description("CZ")]
    Czechia,

    /// <summary>
    /// The country of Germany.
    /// </summary>
    [Description("DE")]
    Germany,

    /// <summary>
    /// The country of Denmark.
    /// </summary>
    [Description("DK")]
    Denmark,

    /// <summary>
    /// The country of Estonia.
    /// </summary>
    [Description("EE")]
    Estonia,

    /// <summary>
    /// The country of Spain.
    /// </summary>
    [Description("ES")]
    Spain,

    /// <summary>
    /// The country of Finland.
    /// </summary>
    [Description("FI")]
    Finland,

    /// <summary>
    /// The country of France.
    /// </summary>
    [Description("FR")]
    France,

    /// <summary>
    /// The country of the United Kingdom.
    /// </summary>
    [Description("GB")]
    UnitedKingdom,

    /// <summary>
    /// The country of Greece.
    /// </summary>
    [Description("GR")]
    Greece,

    /// <summary>
    /// The country of Hungary.
    /// </summary>
    [Description("HU")]
    Hungary,

    /// <summary>
    /// The country of Iceland.
    /// </summary>
    [Description("IS")]
    Iceland,

    /// <summary>
    /// The country of Ireland.
    /// </summary>
    [Description("IE")]
    Ireland,

    /// <summary>
    /// The country of Italy.
    /// </summary>
    [Description("IT")]
    Italy,

    /// <summary>
    /// The country of Latvia.
    /// </summary>
    [Description("LV")]
    Latvia,

    /// <summary>
    /// The country of Liechtenstein.
    /// </summary>
    [Description("LI")]
    Liechtenstein,

    /// <summary>
    /// The country of Lithuania.
    /// </summary>
    [Description("LT")]
    Lithuania,

    /// <summary>
    /// The country of Luxembourg.
    /// </summary>
    [Description("LU")]
    Luxembourg,

    /// <summary>
    /// The country of Malta.
    /// </summary>
    [Description("MT")]
    Malta,

    /// <summary>
    /// The country of Netherlands.
    /// </summary>
    [Description("NL")]
    Netherlands,

    /// <summary>
    /// The country of Norway.
    /// </summary>
    [Description("NO")]
    Norway,

    /// <summary>
    /// The country of Poland.
    /// </summary>
    [Description("PL")]
    Poland,

    /// <summary>
    /// The country of Portugal.
    /// </summary>
    [Description("PT")]
    Portugal,

    /// <summary>
    /// The country of Romania.
    /// </summary>
    [Description("RO")]
    Romania,

    /// <summary>
    /// The country of Sweden.
    /// </summary>
    [Description("SE")]
    Sweden,

    /// <summary>
    /// The country of Slovakia.
    /// </summary>
    [Description("SK")]
    Slovakia,

    /// <summary>
    /// The country of Slovenia.
    /// </summary>
    [Description("SI")]
    Slovenia
}

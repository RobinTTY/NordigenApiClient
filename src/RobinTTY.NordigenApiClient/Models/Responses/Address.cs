using System.Text.Json.Serialization;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// The particulars of the place where someone lives or an organization is situated.
/// </summary>
public class Address
{
    /// <summary>
    /// The name of the street.
    /// </summary>
    [JsonPropertyName("streetName")]
    public string? StreetName { get; }
    
    /// <summary>
    /// The number of the building.
    /// </summary>
    [JsonPropertyName("buildingNumber")]
    public string? BuildingNumber { get; }
    
    /// <summary>
    /// The postcode of the town.
    /// </summary>
    [JsonPropertyName("postCode")]
    public string? PostCode { get; }
    
    /// <summary>
    /// The name of the town.
    /// </summary>
    [JsonPropertyName("townName")]
    public string? TownName { get; }
    
    /// <summary>
    /// The name of the country.
    /// </summary>
    [JsonPropertyName("country")]
    public string? Country { get; }
}

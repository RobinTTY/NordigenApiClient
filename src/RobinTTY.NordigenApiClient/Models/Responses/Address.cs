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

    /// <summary>
    /// Creates a new instance of <see cref="Address" />.
    /// </summary>
    /// <param name="streetName">The name of the street.</param>
    /// <param name="buildingNumber">The number of the building.</param>
    /// <param name="postCode">The postcode of the town.</param>
    /// <param name="townName">The name of the town.</param>
    /// <param name="country">The name of the country.</param>
    [JsonConstructor]
    public Address(string? streetName, string? buildingNumber, string? postCode, string? townName, string? country)
    {
        StreetName = streetName;
        BuildingNumber = buildingNumber;
        PostCode = postCode;
        TownName = townName;
        Country = country;
    }
}
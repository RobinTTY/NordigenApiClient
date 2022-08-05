using RobinTTY.NordigenApiClient.Models.Requests;

namespace RobinTTY.NordigenApiClient.Models.Responses;

/// <summary>
/// A collection of inputs for creating links and retrieving accounts via the Nordigen API.
/// </summary>
public class Requisition : CreateRequisitionRequest
{
    /// <summary>
    /// The id of the requisition assigned by the Nordigen API.
    /// </summary>
    public Guid Id { get; }
    /// <summary>
    /// The time this requisition was created.
    /// </summary>
    public DateTime Created { get; }
    /// <summary>
    /// The status of the requisition.
    /// </summary>
    public RequisitionStatus Status { get; }
    /// <summary>
    /// The accounts linked to this requisition.
    /// </summary>
    public List<Guid> Accounts { get; }
    /// <summary>
    /// The Uri which starts the authentication process.
    /// </summary>
    public Uri AuthenticationLink { get; }
}

/// <summary>
/// The status of the requisition.
/// </summary>
public class RequisitionStatus
{
    /// <summary>
    /// Abbreviation of the requisition status.
    /// </summary>
    public string Short { get; }
    /// <summary>
    /// The requisition status.
    /// </summary>
    public string Long { get; }
    /// <summary>
    /// Description of the requisition status.
    /// </summary>
    public string Description { get; }
}

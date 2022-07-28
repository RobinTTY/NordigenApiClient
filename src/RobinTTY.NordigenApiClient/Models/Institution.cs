namespace RobinTTY.NordigenApiClient.Models;

public class Institution
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Bic { get; set; }
    public string TransactionTotalDays { get; set; }
    public List<string> Countries { get; set; }
    public Uri Logo { get; set; }
}

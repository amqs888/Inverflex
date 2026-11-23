namespace Inverflex.Model;

public sealed class AdvisorAssignment
{
    public int Id { get; set; }
    public string AdvisorId { get; set; } = "";
    public string ClientId { get; set; } = "";
}

namespace Inverflex.Model;

public sealed class PriceAlert
{
    public int Id { get; set; }
    public string ClientId { get; set; } = "";
    public string InstrumentId { get; set; } = "";
    public AlertDirection Direction { get; set; }
    public decimal BaselinePrice { get; set; }
    public decimal PercentChange { get; set; }
    public bool IsTriggered { get; set; }
    public DateTimeOffset? TriggeredAt { get; set; }
}

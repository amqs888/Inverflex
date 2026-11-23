namespace Inverflex.Model;

public sealed class ClientNotification
{
    public long Id { get; set; }
    public string ClientId { get; set; } = "";
    public string Message { get; set; } = "";
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}

using Inverflex.Model;

namespace Inverflex.DTOs;

public sealed record AlertCreateRequestDto(string InstrumentId, AlertDirection Direction, decimal PercentChange, string? ClientId = null);
public sealed record AlertResponseDto(int Id, string ClientId, string InstrumentId, AlertDirection Direction, decimal BaselinePrice, decimal PercentChange, bool IsTriggered, DateTimeOffset? TriggeredAt);

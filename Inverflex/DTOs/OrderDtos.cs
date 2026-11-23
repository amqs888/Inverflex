using Inverflex.Model;

namespace Inverflex.DTOs;

public sealed record OrderCreateRequestDto(string InstrumentId, OrderSide Side, decimal Quantity, string? ClientId = null);
public sealed record OrderResponseDto(
    string Id,
    string ClientId,
    string InstrumentId,
    string Side,
    decimal Quantity,
    decimal UnitPrice,
    decimal TotalAmount,
    string Status,
    DateTimeOffset CreatedAt,
    DateTimeOffset? CompletedAt,
    string? ApprovedBy,
    int Version
);
public sealed record OrderListDto(
    string Id,
    string ClientId,
    string InstrumentId,
    string Side,
    decimal Quantity,
    decimal UnitPrice,
    decimal TotalAmount,
    string Status,
    DateTimeOffset CreatedAt,
    DateTimeOffset? CompletedAt,
    string? ApprovedBy,
    int Version
);

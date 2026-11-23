namespace Inverflex.DTOs;

public sealed record NotificationResponseDto(long Id, string ClientId, string Message, DateTimeOffset CreatedAt);

using Inverflex.Model;

namespace Inverflex.DTOs;

public sealed record AssignmentRequestDto(string AdvisorId, string ClientId);
public sealed record AssignmentResponseDto(int Id, string AdvisorId, string ClientId);

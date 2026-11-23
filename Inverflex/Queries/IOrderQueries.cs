using Inverflex.Model;

namespace Inverflex.Queries;

public interface IOrderQueries
{
    Task<int> CountHistoryAsync(string? clientId, string? instrumentId, OrderStatus? status, DateTimeOffset? from, DateTimeOffset? to, CancellationToken ct = default);

    Task<IReadOnlyList<InvestmentOrder>> GetHistoryAsync(string? clientId, string? instrumentId, OrderStatus? status, DateTimeOffset? from, DateTimeOffset? to, int page, int pageSize, CancellationToken ct = default);

    Task<IReadOnlyList<InvestmentOrder>> GetPendingByClientsAsync(IReadOnlyCollection<string> clientIds, CancellationToken ct = default);

    Task<IReadOnlyList<InvestmentOrder>> GetExecutedByClientsAsync(IReadOnlyCollection<string> clientIds, DateTimeOffset from, DateTimeOffset to, CancellationToken ct = default);
}

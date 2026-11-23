using Inverflex.Data;
using Inverflex.Model;
using Microsoft.EntityFrameworkCore;

namespace Inverflex.Queries;

public sealed class OrderQueries(InvestmentDbContext db) : IOrderQueries
{
    public Task<int> CountHistoryAsync(string? clientId, string? instrumentId, OrderStatus? status, DateTimeOffset? from, DateTimeOffset? to, CancellationToken ct = default)
    {
        var query = FilterHistory(db.Orders.AsNoTracking(), clientId, instrumentId, status, from, to);
        return query.CountAsync(ct);
    }

    public async Task<IReadOnlyList<InvestmentOrder>> GetHistoryAsync(string? clientId, string? instrumentId, OrderStatus? status, DateTimeOffset? from, DateTimeOffset? to, int page, int pageSize, CancellationToken ct = default)
    {
        var query = FilterHistory(db.Orders.AsNoTracking(), clientId, instrumentId, status, from, to);
        return await query.OrderByDescending(x => x.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public async Task<IReadOnlyList<InvestmentOrder>> GetPendingByClientsAsync(IReadOnlyCollection<string> clientIds, CancellationToken ct = default) =>
        await db.Orders.AsNoTracking()
            .Where(x => x.Status == OrderStatus.PendienteAprobacion && clientIds.Contains(x.ClientId))
            .OrderBy(x => x.CreatedAt)
            .ToListAsync(ct);

    public async Task<IReadOnlyList<InvestmentOrder>> GetExecutedByClientsAsync(IReadOnlyCollection<string> clientIds, DateTimeOffset from, DateTimeOffset to, CancellationToken ct = default) =>
        await db.Orders.AsNoTracking()
            .Where(x => x.Status == OrderStatus.Ejecutada
                && clientIds.Contains(x.ClientId)
                && x.CompletedAt >= from
                && x.CompletedAt <= to)
            .ToListAsync(ct);

    private static IQueryable<InvestmentOrder> FilterHistory(IQueryable<InvestmentOrder> query, string? clientId, string? instrumentId, OrderStatus? status, DateTimeOffset? from, DateTimeOffset? to)
    {
        if (!string.IsNullOrWhiteSpace(clientId)) query = query.Where(x => x.ClientId == clientId);
        if (!string.IsNullOrWhiteSpace(instrumentId)) query = query.Where(x => x.InstrumentId == instrumentId);
        if (status.HasValue) query = query.Where(x => x.Status == status);
        if (from.HasValue) query = query.Where(x => x.CreatedAt >= from);
        if (to.HasValue) query = query.Where(x => x.CreatedAt <= to);
        return query;
    }
}

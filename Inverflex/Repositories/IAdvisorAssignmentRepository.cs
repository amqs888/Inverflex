using Inverflex.Model;

namespace Inverflex.Repositories;

public interface IAdvisorAssignmentRepository
{
    Task<AdvisorAssignment?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<List<AdvisorAssignment>> GetAllAsync(CancellationToken ct = default);
    Task<List<AdvisorAssignment>> GetByAdvisorIdAsync(string advisorId, CancellationToken ct = default);
    Task<List<AdvisorAssignment>> GetByClientIdAsync(string clientId, CancellationToken ct = default);
    Task<bool> ExistsAsync(string advisorId, string clientId, CancellationToken ct = default);
    Task AddAsync(AdvisorAssignment assignment, CancellationToken ct = default);
    Task DeleteAsync(int id, CancellationToken ct = default);
    Task SaveChangesAsync(CancellationToken ct = default);
}

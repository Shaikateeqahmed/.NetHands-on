namespace FinanceTracker.Application.Common.Interfaces;

using FinanceTracker.Domain.Entities;

public interface IExpenseRepository
{
    Task<Expenses?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Expenses>> GetAllAsync(CancellationToken cancellationToken = default);
    Task AddAsync(Expenses expense, CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}

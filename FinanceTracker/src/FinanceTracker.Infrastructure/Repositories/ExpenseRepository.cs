using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Infrastructure.Repositories;

public class ExpenseRepository : IExpenseRepository
{
    private readonly AppDbContext _context;

    public ExpenseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Expenses?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Expense.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<IReadOnlyList<Expenses>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Expense.ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Expenses expense, CancellationToken cancellationToken = default)
    {
        await _context.Expense.AddAsync(expense, cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}

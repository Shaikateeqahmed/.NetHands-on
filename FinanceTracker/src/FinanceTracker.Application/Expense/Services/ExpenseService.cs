using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Expense.DTOs;
using FinanceTracker.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FinanceTracker.Application.Expense.Services;



public class ExpenseService
{
    public readonly IExpenseRepository _expenseRepository;

    public ExpenseService   (IExpenseRepository expenseRepository)
    {
        _expenseRepository = expenseRepository;
    }

    public async Task<ExpenseResponse> CreateExpenseAsync(CreateExpenseRequest request, CancellationToken cancellationToken = default)
    {
        var expense = new Expenses
        {
            Title = request.Title,
            Amount = request.Amount,
            Category = request.Category,
            Date = request.DateIncurredUtc
        };
        await _expenseRepository.AddAsync(expense, cancellationToken);
        await _expenseRepository.SaveChangesAsync(cancellationToken);
        return new ExpenseResponse(
            expense.Id,
            expense.Title,
            expense.Amount,
            expense.Category.ToString(),
            expense.Date
         );
    }
}
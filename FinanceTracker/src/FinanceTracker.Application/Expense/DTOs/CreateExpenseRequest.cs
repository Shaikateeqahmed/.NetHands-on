namespace FinanceTracker.Application.Expense.DTOs;

using FinanceTracker.Domain.Enums;

public record CreateExpenseRequest(
    string Title,
    decimal Amount,
    ExpenseCategory Category,
    DateTime DateIncurredUtc
);

public record ExpenseResponse(
    Guid Id,
    string Title,
    decimal Amount,
    string Category,
    DateTime DateIncurredUtc
);
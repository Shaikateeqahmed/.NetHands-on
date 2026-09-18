namespace FinanceTracker.Domain.Entities;

using FinanceTracker.Domain.Enums;
using FinanceTracker.Domain.Common;

public class Expenses : BaseEntity
{
    public string Title
    {
        get; set;
    }
    public decimal Amount
    {
        get; set;
    }
    public ExpenseCategory Category
    {
        get; set;
    }
    public DateTime Date
    {
        get; set;
    }

    public Expenses() { }

    public Expenses(string title, decimal amount, ExpenseCategory category, DateTime date)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title cannot be null or empty.", nameof(title));
        }
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero.", nameof(amount));
        }

        Id = Guid.NewGuid();
        Title = title;
        Amount = amount;
        Category = category;
        Date = date;
    }

    public void updateAmount(decimal newAmount)
    {
        if (newAmount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero.", nameof(newAmount));
        }
        Amount = newAmount;
    }
}


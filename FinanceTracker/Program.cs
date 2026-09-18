using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Expense.DTOs;
using FinanceTracker.Application.Expense.Services;
using FinanceTracker.Application.Expense.DTOs;
using FinanceTracker.Application.Expense.Services;
using FinanceTracker.Infrastructure.Data;
using FinanceTracker.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Configure EF Core with local SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")
                      ?? "Data Source=finance.db"));

// 2. Register Dependencies (IoC Container / DIP)
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
builder.Services.AddScoped<ExpenseService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Auto-run migrations on start (dev only)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 3. Map Endpoints
app.MapPost("/api/expenses", async (CreateExpenseRequest request, ExpenseService service) =>
{
    try
    {
        var result = await service.CreateExpenseAsync(request);
        return Results.Created($"/api/expenses/{result.Id}", result);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
});

app.MapGet("/api/expenses", async (IExpenseRepository repo) =>
{
    var items = await repo.GetAllAsync();
    return Results.Ok(items);
});

app.Run();
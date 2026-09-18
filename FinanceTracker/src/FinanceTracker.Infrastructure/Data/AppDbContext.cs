namespace FinanceTracker.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;
using FinanceTracker.Domain.Entities;
public class AppDbContext : DbContext
{
    public DbSet<Expenses> Expense => Set<Expenses>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Expenses>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired();
            entity.Property(e => e.Amount).IsRequired();
            entity.Property(e => e.Category).IsRequired();
            entity.Property(e => e.Date).IsRequired();
        });
    }

}

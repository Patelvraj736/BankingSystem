using BankingApplication.Application.Interfaces;
using BankingApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankingApplication.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<SavingAccount> SavingsAccounts => Set<SavingAccount>();
    public DbSet<CurrentAccount> CurrentAccounts => Set<CurrentAccount>();
    public DbSet<Loan> Loans => Set<Loan>();
    public DbSet<Transaction> Transactions => Set<Transaction>();

    public override async Task<int> SaveChangesAsync(CancellationToken token = default)
    {
        var entries = ChangeTracker.Entries<AuditEntity>();
        foreach(var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    break;
            }
        }
        return await base.SaveChangesAsync(token);
    }
}

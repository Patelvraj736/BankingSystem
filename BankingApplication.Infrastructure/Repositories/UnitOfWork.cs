using BankingApplication.Application.Interfaces;
using BankingApplication.Infrastructure.Data;

namespace BankingApplication.Infrastructure.Repositories;

public class UnitOfWork(AppDbContext context,IAccountRepository account,ILoanRepository loan,ITransactionRepository transaction,ICustomerRepository customer) : IUnitOfWork
{
    public IAccountRepository Account { get; } = account;
    public ILoanRepository Loan { get; } = loan;
    public ITransactionRepository Transaction { get; } = transaction;
    public ICustomerRepository Customer { get; } = customer;
    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }
}

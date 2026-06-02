using BankingApplication.Application.Interfaces;
using BankingApplication.Domain.Entities;
using BankingApplication.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BankingApplication.Infrastructure.Repositories;

public class AccountRepository(AppDbContext context) : GenericRepository<Account>(context), IAccountRepository
{
    public async Task<Account?> GetByAccountNumber(string accountNo)
    {
        return await context.Accounts.AsNoTracking().FirstOrDefaultAsync(x => x.AccountNo == accountNo);
    }
}

using BankingApplication.Application.Interfaces;
using BankingApplication.Domain.Entities;
using BankingApplication.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BankingApplication.Infrastructure.Repositories;

public class TransactionRepository(AppDbContext context) : GenericRepository<Transaction>(context), ITransactionRepository
{
    public async Task<IEnumerable<Transaction>> GetHistoryAsync(string accountNo)
    {
        return await context.Transactions.AsNoTracking().Include(x => x.Account).Where(x => x.Account.AccountNo == accountNo).OrderByDescending(x => x.CreatedAt).ToListAsync();
    }
}

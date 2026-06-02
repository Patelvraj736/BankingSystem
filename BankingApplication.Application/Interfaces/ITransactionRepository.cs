using BankingApplication.Domain.Entities;

namespace BankingApplication.Application.Interfaces;

public  interface ITransactionRepository : IGenericRepository<Transaction>
{
    Task<IEnumerable<Transaction>> GetHistoryAsync(string accountNo);
}

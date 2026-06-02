using BankingApplication.Domain.Entities;

namespace BankingApplication.Application.Interfaces;

public interface IAccountRepository :  IGenericRepository<Account>
{
    Task<Account?> GetByAccountNumber(string accountNo);
}

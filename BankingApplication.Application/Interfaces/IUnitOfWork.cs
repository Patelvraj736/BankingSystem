namespace BankingApplication.Application.Interfaces;

public interface IUnitOfWork
{
    IAccountRepository Account { get; }
    ILoanRepository Loan { get; }
    ITransactionRepository Transaction { get; }
    ICustomerRepository Customer { get; }
    Task<int> SaveChangesAsync();
}

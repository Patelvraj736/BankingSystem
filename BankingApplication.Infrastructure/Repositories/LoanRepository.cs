using BankingApplication.Application.Interfaces;
using BankingApplication.Domain.Entities;
using BankingApplication.Infrastructure.Data;

namespace BankingApplication.Infrastructure.Repositories;

public class LoanRepository(AppDbContext context) : GenericRepository<Loan>(context),ILoanRepository
{
}

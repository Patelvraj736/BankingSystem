using BankingApplication.Application.Interfaces;
using BankingApplication.Domain.Entities;
using BankingApplication.Infrastructure.Data;

namespace BankingApplication.Infrastructure.Repositories;

public class CustomerRepository(AppDbContext context) : GenericRepository<Customer>(context),ICustomerRepository
{
}

using BankingApplication.Application.Command;
using BankingApplication.Application.Interfaces;
using BankingApplication.Domain.Entities;
using MediatR;

namespace BankingApplication.Application.Handler
{
    public class CreateCustomerHandler(IUnitOfWork uow): IRequestHandler<CreateCustomerCommand, Guid>
    {
        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken token)
        {
            var customer = new Customer
            {
                Name = request.Name,
                Email = request.Email,
                Account = new List<Account>()
            };

            await uow.Customer.AddAsync(customer);
            await uow.SaveChangesAsync();

            return customer.Id;
        }
    }
}

using BankingApplication.Application.Command;
using BankingApplication.Application.Interfaces;
using BankingApplication.Domain.Entities;
using BankingApplication.Domain.Enums;
using MediatR;

namespace BankingApplication.Application.Handler;

public class ApplyLoanHandler(IUnitOfWork uow) : IRequestHandler<ApplyLoanCommand,Guid>
{
    public async Task<Guid> Handle(ApplyLoanCommand request,CancellationToken token)
    {
        var customer = await uow.Customer.GetByIdAsync(request.CustomerId);

        if (customer is null)
        {
            throw new Exception("Customer not found.");
        }

        var loan = new Loan
        {
            CustomerId = request.CustomerId,
            Amount = request.Amount,
            LoanDuration = 5,
            LoanStatus = LoanStatus.Pending
        };
        await uow.Loan.AddAsync(loan);
        await uow.SaveChangesAsync();
        return loan.Id;
    }
}

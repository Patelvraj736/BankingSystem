using BankingApplication.Application.Command;
using BankingApplication.Application.Interfaces;
using BankingApplication.Domain.Entities;
using BankingApplication.Domain.Enums;
using MediatR;

namespace BankingApplication.Application.Handler;

public class WithdrawHandler(IUnitOfWork uow) : IRequestHandler<WithdrawCommand,decimal>
{
    public async Task<decimal> Handle(WithdrawCommand request,CancellationToken token)
    {
        var account = await uow.Account.GetByAccountNumber(request.AccountNo);

        if (account == null)
        {
            throw new Exception($"Account {request.AccountNo} not found");
        }

        account.Withdraw(request.Amount);
        await uow.Transaction.AddAsync(new Transaction
        {
            AccountId = account.Id,
            amount = request.Amount,
            TransactionType = TransactionType.Withdraw
        });

        await uow.SaveChangesAsync();

        return request.Amount;
    }
}

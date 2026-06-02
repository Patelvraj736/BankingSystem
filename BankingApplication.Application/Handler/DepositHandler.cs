using BankingApplication.Application.Command;
using BankingApplication.Application.Interfaces;
using BankingApplication.Domain.Entities;
using BankingApplication.Domain.Enums;
using MediatR;

namespace BankingApplication.Application.Handler;

public class DepositHandler(IUnitOfWork uow) : IRequestHandler<DepositCommand,decimal>
{
    public async Task<decimal> Handle(DepositCommand request,CancellationToken token)
    {
        var account = await uow.Account.GetByAccountNumber(request.AccountNo);
        
        if (account == null)
        {
            throw new Exception($"Account {request.AccountNo} not found.");
        }

        account.Deposit(request.Amount);

        await uow.Transaction.AddAsync(new Transaction
        {
            AccountId = account.Id,
            amount = request.Amount,
            TransactionType = TransactionType.Deposit
        });

        await uow.SaveChangesAsync();
        return account.Balance;
    }
}

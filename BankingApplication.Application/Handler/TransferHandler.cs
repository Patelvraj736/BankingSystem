using BankingApplication.Application.Command;
using BankingApplication.Application.Interfaces;
using BankingApplication.Domain.Entities;
using BankingApplication.Domain.Enums;
using MediatR;

namespace BankingApplication.Application.Handler;

public class TransferHandler(IUnitOfWork uow) : IRequestHandler<TransferCommand,string>
{
    public async Task<string> Handle(TransferCommand request,CancellationToken token)
    {
        var fromAccount = await uow.Account.GetByAccountNumber(request.FromAccountNo);

        var toAccount = await uow.Account.GetByAccountNumber(request.ToAccountNo);

        if(fromAccount==null || toAccount == null)
        {
            throw new Exception("null exception");
        }

        fromAccount.Withdraw(request.Amount);
        toAccount.Deposit(request.Amount);

        await uow.Transaction.AddAsync(new Transaction
        {
            AccountId = fromAccount.Id,
            amount = request.Amount,
            TransactionType = TransactionType.Transfer
        });
        await uow.SaveChangesAsync();
        return "Transfer success";
    }
}

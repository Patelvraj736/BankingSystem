using BankingApplication.Application.Dtos;
using BankingApplication.Application.Interfaces;
using BankingApplication.Application.Query;
using MediatR;

namespace BankingApplication.Application.Handler;

public class GetTransactionHistoryHandler(IUnitOfWork uow) : IRequestHandler<GetTransactionHistoryQuery,List<TransactionResponse>>
{
    public async Task<List<TransactionResponse>> Handle(GetTransactionHistoryQuery request,CancellationToken token)
    {
        var account = await uow.Account.GetByAccountNumber(request.AccountNo);
        if (account == null)
        {
            throw new Exception("account not found");
        }
        return account.Transactions.Select(x => new TransactionResponse
        {
            Amount = x.amount,
            Type = x.TransactionType,
            CreatedAt = x.CreatedAt
        }).ToList();
    }
}

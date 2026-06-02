using BankingApplication.Application.Dtos;
using MediatR;

namespace BankingApplication.Application.Query;

public class GetTransactionHistoryQuery : IRequest<List<TransactionResponse>>
{
    public string AccountNo { get; set; }
}

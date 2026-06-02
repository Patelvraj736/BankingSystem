using MediatR;

namespace BankingApplication.Application.Command;

public class WithdrawCommand : IRequest<decimal>
{
    public string AccountNo { get; set; }
    public decimal Amount { get; set; }
}

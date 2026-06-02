using MediatR;

namespace BankingApplication.Application.Command;

public class TransferCommand : IRequest<string>
{
    public string FromAccountNo { get; set; }
    public string ToAccountNo { get; set; }
    public decimal Amount { get; set; }
}

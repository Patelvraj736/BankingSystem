using MediatR;

namespace BankingApplication.Application.Command;

public class ApplyLoanCommand : IRequest<Guid>
{
    public Guid CustomerId { get; set; }
    public decimal Amount { get; set; }
}

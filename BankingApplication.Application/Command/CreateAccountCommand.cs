using BankingApplication.Domain.Enums;
using MediatR;

namespace BankingApplication.Application.Command;

public class CreateAccountCommand : IRequest<string>
{
    public string AccountNo { get; set; }
    public Guid CustomerId { get; set; }
    public AccountType AccountType { get; set; }
}

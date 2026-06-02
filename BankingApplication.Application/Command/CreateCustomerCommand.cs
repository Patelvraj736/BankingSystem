using MediatR;

namespace BankingApplication.Application.Command;

public class CreateCustomerCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public string Email { get; set; }
}

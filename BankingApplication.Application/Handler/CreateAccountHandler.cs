using BankingApplication.Application.Command;
using BankingApplication.Application.Interfaces;
using BankingApplication.Domain.AccountFactory.Interface;
using MediatR;

namespace BankingApplication.Application.Handler;

public class CreateAccountHandler(IUnitOfWork uow, IAccountFactoryProvider provider) : IRequestHandler<CreateAccountCommand,string>
{
    public async Task<string> Handle(CreateAccountCommand request, CancellationToken token)
    {
        var factory = provider.GetFactory(request.AccountType);
        var account = factory.CreateAccount(request.AccountNo, request.CustomerId);
        await uow.Account.AddAsync(account);
        await uow.SaveChangesAsync();
        return account.AccountNo;
    }
}

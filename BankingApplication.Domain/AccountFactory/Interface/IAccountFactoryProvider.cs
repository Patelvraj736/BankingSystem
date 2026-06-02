using BankingApplication.Domain.Enums;

namespace BankingApplication.Domain.AccountFactory.Interface;

public interface IAccountFactoryProvider
{
    IAccountFactory GetFactory(AccountType accounttype);
}

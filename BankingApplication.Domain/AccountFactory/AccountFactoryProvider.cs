using BankingApplication.Domain.AccountFactory.Interface;
using BankingApplication.Domain.Enums;

namespace BankingApplication.Domain.AccountFactory;

public class AccountFactoryProvider : IAccountFactoryProvider
{
    private readonly Dictionary<AccountType, IAccountFactory> _factories;
    public AccountFactoryProvider(IEnumerable<IAccountFactory> factories)
    {
        _factories = factories.ToDictionary(x => x.GetType() == typeof(SavingAccountFactory) ? AccountType.Savings : AccountType.Current);
    }
    public IAccountFactory GetFactory(AccountType accountType)
    {
        return _factories[accountType];
    }
}

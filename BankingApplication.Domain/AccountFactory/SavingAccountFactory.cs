using BankingApplication.Domain.AccountFactory.Interface;
using BankingApplication.Domain.Entities;
using BankingApplication.Domain.Enums;

namespace BankingApplication.Domain.AccountFactory;

public class SavingAccountFactory : IAccountFactory
{
    public Account CreateAccount(string accountNo, Guid customerId)
    {
        return new SavingAccount
        {
            AccountNo = accountNo,
            CustomerId = customerId,
            AccountType = AccountType.Savings,
            Balance = 0,
            Transactions = new List<Transaction>()
        };
    }
}

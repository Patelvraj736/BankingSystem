using BankingApplication.Domain.AccountFactory.Interface;
using BankingApplication.Domain.Entities;
using BankingApplication.Domain.Enums;


namespace BankingApplication.Domain.AccountFactory;

public class CurrentAccountFactory : IAccountFactory
{
    public Account CreateAccount(string accountNo,Guid customerId)
    {
        return new CurrentAccount
        {
            AccountNo = accountNo,
            AccountType = AccountType.Current,
            Balance = 5000,
            CustomerId = customerId,
            Transactions =new List<Transaction>()
        };
    }
}

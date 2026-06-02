using BankingApplication.Domain.Entities;

namespace BankingApplication.Domain.AccountFactory.Interface;

public interface IAccountFactory
{
    Account CreateAccount(string accountNo,Guid customerId);
}

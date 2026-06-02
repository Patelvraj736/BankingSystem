namespace BankingApplication.Domain.Entities;

public class SavingAccount : Account
{
   
    public override void Withdraw(decimal amount)
    {
        if(Balance < amount)
        {
            throw new InvalidOperationException("Insufficient Balance");
        }
        Balance -= amount;
    }
}

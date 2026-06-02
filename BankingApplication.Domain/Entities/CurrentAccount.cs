namespace BankingApplication.Domain.Entities;

public class CurrentAccount : Account
{
    public decimal OverDraftLimit { get; set; } = 5000;
    public override void Withdraw(decimal amount)
    {
        if(amount > Balance + OverDraftLimit)
        {
            throw new InvalidOperationException("Overdraft limit exceed");
        }
        else
        {
            Balance -= amount;
        }  
    }
}

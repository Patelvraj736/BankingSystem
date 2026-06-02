using BankingApplication.Domain.Enums;

namespace BankingApplication.Domain.Entities;

public abstract class Account : AuditEntity
{
    public required string AccountNo { get; set; }
    public AccountType AccountType { get; set ; }
    public decimal Balance { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
    public List<Transaction> Transactions { get; set; }

    public virtual void Deposit(decimal amount)
    {
        Balance += amount;
    }
    public abstract void Withdraw(decimal amount);
}

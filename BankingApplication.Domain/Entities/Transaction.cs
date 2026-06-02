using BankingApplication.Domain.Enums;

namespace BankingApplication.Domain.Entities;

public class Transaction : AuditEntity
{
    public Guid AccountId { get; set; }
    public Account Account { get; set; }
    public decimal amount { get; set; }
    public TransactionType TransactionType { get; set; }
}

using BankingApplication.Domain.Enums;

namespace BankingApplication.Domain.Entities;

public class Loan : AuditEntity
{
    public decimal Amount { get; set; }
    public int LoanDuration { get; set; }
    public LoanStatus LoanStatus { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
}

namespace BankingApplication.Domain.Entities;

public class Customer : AuditEntity
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public List<Account> Account { get; set; }
}

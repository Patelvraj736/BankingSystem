using BankingApplication.Domain.Enums;

namespace BankingApplication.Application.Dtos;

public class TransactionResponse
{
    public decimal Amount { get; set; }
    public TransactionType Type { get; set; }
    public DateTime CreatedAt { get; set; }
}

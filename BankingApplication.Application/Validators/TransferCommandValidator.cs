using BankingApplication.Application.Command;
using FluentValidation;

namespace BankingApplication.Application.Validators;

public class TransferCommandValidator : AbstractValidator<TransferCommand>
{
    public TransferCommandValidator()
    {
        RuleFor(x => x.FromAccountNo)
            .NotEmpty();

        RuleFor(x => x.ToAccountNo)
            .NotEmpty()
            .NotEqual(x => x.FromAccountNo)
            .WithMessage("Cannot transfer to same account");

        RuleFor(x => x.Amount)
            .GreaterThan(0);
    }
}

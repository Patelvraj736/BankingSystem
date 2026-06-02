using BankingApplication.Application.Command;
using FluentValidation;
namespace BankingApplication.Application.Validators;
public class DepositCommandValidator : AbstractValidator<DepositCommand>
{
    public DepositCommandValidator()
    {
        RuleFor(x => x.AccountNo)
            .NotEmpty();

        RuleFor(x => x.Amount)
            .GreaterThan(0);
    }
}

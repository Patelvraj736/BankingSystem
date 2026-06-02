using BankingApplication.Application.Command;
using FluentValidation;

namespace BankingApplication.Application.Validators;
public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
{
    public CreateAccountCommandValidator()
    {
        RuleFor(x => x.AccountNo)
            .NotEmpty()
            .MinimumLength(5);

        RuleFor(x => x.CustomerId)
            .NotEmpty();

        RuleFor(x => x.AccountType)
            .IsInEnum();
    }
}

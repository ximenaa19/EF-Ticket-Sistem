using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.PersonPhone;

public sealed class CreatePersonPhoneValidator : AbstractValidator<CreatePersonPhoneCommand>
{
    public CreatePersonPhoneValidator()
    {
        RuleFor(command => command.PersonId)
            .NotEmpty();

        RuleFor(command => command.PhoneCodeId)
            .NotEmpty();

        RuleFor(command => command.Number)
            .NotEmpty()
            .MaximumLength(30);
    }
}

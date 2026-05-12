using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.PhoneCode;

public sealed class CreatePhoneCodeValidator : AbstractValidator<CreatePhoneCodeCommand>
{
    public CreatePhoneCodeValidator()
    {
        RuleFor(command => command.CountryId)
            .NotEmpty();

        RuleFor(command => command.Code)
            .NotEmpty()
            .MaximumLength(10);
    }
}

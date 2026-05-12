using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.PhoneCode;

public sealed class UpdatePhoneCodeValidator : AbstractValidator<UpdatePhoneCodeCommand>
{
    public UpdatePhoneCodeValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.CountryId)
            .NotEmpty();

        RuleFor(command => command.Code)
            .NotEmpty()
            .MaximumLength(10);
    }
}

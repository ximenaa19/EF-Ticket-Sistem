using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.PersonPhone;

public sealed class UpdatePersonPhoneValidator : AbstractValidator<UpdatePersonPhoneCommand>
{
    public UpdatePersonPhoneValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.PersonId)
            .NotEmpty();

        RuleFor(command => command.PhoneCodeId)
            .NotEmpty();

        RuleFor(command => command.Number)
            .NotEmpty()
            .MaximumLength(30);
    }
}

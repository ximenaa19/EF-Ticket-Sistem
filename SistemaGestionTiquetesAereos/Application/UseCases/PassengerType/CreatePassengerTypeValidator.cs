using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.PassengerType;

public sealed class CreatePassengerTypeValidator : AbstractValidator<CreatePassengerTypeCommand>
{
    public CreatePassengerTypeValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}

using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.PassengerType;

public sealed class UpdatePassengerTypeValidator : AbstractValidator<UpdatePassengerTypeCommand>
{
    public UpdatePassengerTypeValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}

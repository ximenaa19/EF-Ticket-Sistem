using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.FlightStatusTransition;

public sealed class CreateFlightStatusTransitionValidator : AbstractValidator<CreateFlightStatusTransitionCommand>
{
    public CreateFlightStatusTransitionValidator()
    {
        RuleFor(command => command.FlightId)
            .NotEmpty();

        RuleFor(command => command.FromFlightStatusId)
            .NotEmpty();

        RuleFor(command => command.ToFlightStatusId)
            .NotEmpty();
    }
}

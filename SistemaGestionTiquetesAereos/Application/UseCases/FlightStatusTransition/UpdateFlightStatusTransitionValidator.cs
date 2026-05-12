using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.FlightStatusTransition;

public sealed class UpdateFlightStatusTransitionValidator : AbstractValidator<UpdateFlightStatusTransitionCommand>
{
    public UpdateFlightStatusTransitionValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.FlightId)
            .NotEmpty();

        RuleFor(command => command.FromFlightStatusId)
            .NotEmpty();

        RuleFor(command => command.ToFlightStatusId)
            .NotEmpty();
    }
}

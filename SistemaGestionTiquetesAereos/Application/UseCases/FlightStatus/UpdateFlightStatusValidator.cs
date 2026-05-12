using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.FlightStatus;

public sealed class UpdateFlightStatusValidator : AbstractValidator<UpdateFlightStatusCommand>
{
    public UpdateFlightStatusValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}

using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.FlightStatus;

public sealed class CreateFlightStatusValidator : AbstractValidator<CreateFlightStatusCommand>
{
    public CreateFlightStatusValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}

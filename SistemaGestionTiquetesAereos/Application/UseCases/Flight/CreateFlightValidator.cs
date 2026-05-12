using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Flight;

public sealed class CreateFlightValidator : AbstractValidator<CreateFlightCommand>
{
    public CreateFlightValidator()
    {
        RuleFor(command => command.FlightCode)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(command => command.AirlineId)
            .NotEmpty();

        RuleFor(command => command.RouteId)
            .NotEmpty();

        RuleFor(command => command.AircraftId)
            .NotEmpty();

        RuleFor(command => command.TotalCapacity)
            .GreaterThanOrEqualTo(0);

        RuleFor(command => command.AvailableSeats)
            .GreaterThanOrEqualTo(0);

        RuleFor(command => command.FlightStatusId)
            .NotEmpty();
    }
}

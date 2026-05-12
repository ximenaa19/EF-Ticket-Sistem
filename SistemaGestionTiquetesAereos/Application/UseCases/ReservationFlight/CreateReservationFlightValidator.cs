using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.ReservationFlight;

public sealed class CreateReservationFlightValidator : AbstractValidator<CreateReservationFlightCommand>
{
    public CreateReservationFlightValidator()
    {
        RuleFor(command => command.ReservationId)
            .NotEmpty();

        RuleFor(command => command.FlightId)
            .NotEmpty();
    }
}

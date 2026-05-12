using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.ReservationFlight;

public sealed class UpdateReservationFlightValidator : AbstractValidator<UpdateReservationFlightCommand>
{
    public UpdateReservationFlightValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.ReservationId)
            .NotEmpty();

        RuleFor(command => command.FlightId)
            .NotEmpty();
    }
}

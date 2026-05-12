using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.FlightSeat;

public sealed class UpdateFlightSeatValidator : AbstractValidator<UpdateFlightSeatCommand>
{
    public UpdateFlightSeatValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.FlightId)
            .NotEmpty();

        RuleFor(command => command.SeatNumber)
            .NotEmpty()
            .MaximumLength(10);

        RuleFor(command => command.CabinTypeId)
            .NotEmpty();

        RuleFor(command => command.SeatLocationTypeId)
            .NotEmpty();

        RuleFor(command => command.AvailabilityStatusId)
            .NotEmpty();
    }
}

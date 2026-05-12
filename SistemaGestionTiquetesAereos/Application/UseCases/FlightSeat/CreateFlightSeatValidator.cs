using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.FlightSeat;

public sealed class CreateFlightSeatValidator : AbstractValidator<CreateFlightSeatCommand>
{
    public CreateFlightSeatValidator()
    {
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

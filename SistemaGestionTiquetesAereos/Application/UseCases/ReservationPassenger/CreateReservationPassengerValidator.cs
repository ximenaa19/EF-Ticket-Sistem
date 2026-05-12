using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.ReservationPassenger;

public sealed class CreateReservationPassengerValidator : AbstractValidator<CreateReservationPassengerCommand>
{
    public CreateReservationPassengerValidator()
    {
        RuleFor(command => command.ReservationId)
            .NotEmpty();

        RuleFor(command => command.PassengerId)
            .NotEmpty();
    }
}

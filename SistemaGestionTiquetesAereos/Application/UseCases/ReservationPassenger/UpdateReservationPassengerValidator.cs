using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.ReservationPassenger;

public sealed class UpdateReservationPassengerValidator : AbstractValidator<UpdateReservationPassengerCommand>
{
    public UpdateReservationPassengerValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.ReservationId)
            .NotEmpty();

        RuleFor(command => command.PassengerId)
            .NotEmpty();
    }
}

using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.ReservationStatusTransition;

public sealed class CreateReservationStatusTransitionValidator : AbstractValidator<CreateReservationStatusTransitionCommand>
{
    public CreateReservationStatusTransitionValidator()
    {
        RuleFor(command => command.ReservationId)
            .NotEmpty();

        RuleFor(command => command.FromReservationStatusId)
            .NotEmpty();

        RuleFor(command => command.ToReservationStatusId)
            .NotEmpty();
    }
}

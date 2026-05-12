using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.ReservationStatusTransition;

public sealed class UpdateReservationStatusTransitionValidator : AbstractValidator<UpdateReservationStatusTransitionCommand>
{
    public UpdateReservationStatusTransitionValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.ReservationId)
            .NotEmpty();

        RuleFor(command => command.FromReservationStatusId)
            .NotEmpty();

        RuleFor(command => command.ToReservationStatusId)
            .NotEmpty();
    }
}

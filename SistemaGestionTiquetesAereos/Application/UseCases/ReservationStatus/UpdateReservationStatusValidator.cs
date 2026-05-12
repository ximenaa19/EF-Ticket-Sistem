using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.ReservationStatus;

public sealed class UpdateReservationStatusValidator : AbstractValidator<UpdateReservationStatusCommand>
{
    public UpdateReservationStatusValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}

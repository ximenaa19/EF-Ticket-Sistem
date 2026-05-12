using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.ReservationStatus;

public sealed class CreateReservationStatusValidator : AbstractValidator<CreateReservationStatusCommand>
{
    public CreateReservationStatusValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}

using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Reservation;

public sealed class CreateReservationValidator : AbstractValidator<CreateReservationCommand>
{
    public CreateReservationValidator()
    {
        RuleFor(command => command.ClientId)
            .NotEmpty();

        RuleFor(command => command.ReservationStatusId)
            .NotEmpty();

        RuleFor(command => command.ReservationCode)
            .NotEmpty()
            .MaximumLength(30);

        RuleFor(command => command.TotalAmount)
            .GreaterThanOrEqualTo(0);

        RuleFor(command => command.Currency)
            .NotEmpty()
            .MaximumLength(3);
    }
}

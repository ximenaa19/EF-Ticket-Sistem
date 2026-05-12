using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Ticket;

public sealed class UpdateTicketValidator : AbstractValidator<UpdateTicketCommand>
{
    public UpdateTicketValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.ReservationId)
            .NotEmpty();

        RuleFor(command => command.PassengerId)
            .NotEmpty();

        RuleFor(command => command.FlightId)
            .NotEmpty();

        RuleFor(command => command.TicketStatusId)
            .NotEmpty();

        RuleFor(command => command.TicketNumber)
            .NotEmpty()
            .MaximumLength(40);

        RuleFor(command => command.FareAmount)
            .GreaterThanOrEqualTo(0);

        RuleFor(command => command.Currency)
            .NotEmpty()
            .MaximumLength(3);
    }
}

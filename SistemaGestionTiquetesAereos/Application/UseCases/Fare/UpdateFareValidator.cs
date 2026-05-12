using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Fare;

public sealed class UpdateFareValidator : AbstractValidator<UpdateFareCommand>
{
    public UpdateFareValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.FlightId)
            .NotEmpty();

        RuleFor(command => command.PassengerTypeId)
            .NotEmpty();

        RuleFor(command => command.CabinTypeId)
            .NotEmpty();

        RuleFor(command => command.Amount)
            .GreaterThanOrEqualTo(0);

        RuleFor(command => command.Currency)
            .NotEmpty()
            .MaximumLength(3);
    }
}

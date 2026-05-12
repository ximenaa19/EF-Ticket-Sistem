using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Passenger;

public sealed class CreatePassengerValidator : AbstractValidator<CreatePassengerCommand>
{
    public CreatePassengerValidator()
    {
        RuleFor(command => command.PersonId)
            .NotEmpty();

        RuleFor(command => command.PassengerTypeId)
            .NotEmpty();
    }
}

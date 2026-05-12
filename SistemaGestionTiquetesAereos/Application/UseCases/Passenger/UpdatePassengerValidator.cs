using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Passenger;

public sealed class UpdatePassengerValidator : AbstractValidator<UpdatePassengerCommand>
{
    public UpdatePassengerValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.PersonId)
            .NotEmpty();

        RuleFor(command => command.PassengerTypeId)
            .NotEmpty();
    }
}

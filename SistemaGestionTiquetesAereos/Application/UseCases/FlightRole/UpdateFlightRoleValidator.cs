using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.FlightRole;

public sealed class UpdateFlightRoleValidator : AbstractValidator<UpdateFlightRoleCommand>
{
    public UpdateFlightRoleValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}

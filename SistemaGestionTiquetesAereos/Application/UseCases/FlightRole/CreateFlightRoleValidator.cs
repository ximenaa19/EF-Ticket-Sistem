using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.FlightRole;

public sealed class CreateFlightRoleValidator : AbstractValidator<CreateFlightRoleCommand>
{
    public CreateFlightRoleValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(80);
    }
}

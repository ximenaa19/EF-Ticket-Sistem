using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.FlightAssignment;

public sealed class CreateFlightAssignmentValidator : AbstractValidator<CreateFlightAssignmentCommand>
{
    public CreateFlightAssignmentValidator()
    {
        RuleFor(command => command.FlightId)
            .NotEmpty();

        RuleFor(command => command.StaffId)
            .NotEmpty();

        RuleFor(command => command.FlightRoleId)
            .NotEmpty();
    }
}

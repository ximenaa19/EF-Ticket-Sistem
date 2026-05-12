using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.FlightAssignment;

public sealed class UpdateFlightAssignmentValidator : AbstractValidator<UpdateFlightAssignmentCommand>
{
    public UpdateFlightAssignmentValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.FlightId)
            .NotEmpty();

        RuleFor(command => command.StaffId)
            .NotEmpty();

        RuleFor(command => command.FlightRoleId)
            .NotEmpty();
    }
}

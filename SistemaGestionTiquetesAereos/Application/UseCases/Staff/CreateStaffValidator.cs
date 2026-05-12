using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Staff;

public sealed class CreateStaffValidator : AbstractValidator<CreateStaffCommand>
{
    public CreateStaffValidator()
    {
        RuleFor(command => command.PersonId)
            .NotEmpty();

        RuleFor(command => command.StaffPositionId)
            .NotEmpty();

        RuleFor(command => command.EmployeeCode)
            .NotEmpty()
            .MaximumLength(40);
    }
}

using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Staff;

public sealed class UpdateStaffValidator : AbstractValidator<UpdateStaffCommand>
{
    public UpdateStaffValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.PersonId)
            .NotEmpty();

        RuleFor(command => command.StaffPositionId)
            .NotEmpty();

        RuleFor(command => command.EmployeeCode)
            .NotEmpty()
            .MaximumLength(40);
    }
}

using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.StaffPosition;

public sealed class UpdateStaffPositionValidator : AbstractValidator<UpdateStaffPositionCommand>
{
    public UpdateStaffPositionValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(100);
    }
}

using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.StaffPosition;

public sealed class CreateStaffPositionValidator : AbstractValidator<CreateStaffPositionCommand>
{
    public CreateStaffPositionValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(100);
    }
}

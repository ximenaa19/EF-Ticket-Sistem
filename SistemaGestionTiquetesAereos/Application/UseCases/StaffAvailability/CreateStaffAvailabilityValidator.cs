using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.StaffAvailability;

public sealed class CreateStaffAvailabilityValidator : AbstractValidator<CreateStaffAvailabilityCommand>
{
    public CreateStaffAvailabilityValidator()
    {
        RuleFor(command => command.StaffId)
            .NotEmpty();

        RuleFor(command => command.AvailabilityStatusId)
            .NotEmpty();
    }
}

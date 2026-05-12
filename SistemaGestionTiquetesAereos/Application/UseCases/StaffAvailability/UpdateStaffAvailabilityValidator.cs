using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.StaffAvailability;

public sealed class UpdateStaffAvailabilityValidator : AbstractValidator<UpdateStaffAvailabilityCommand>
{
    public UpdateStaffAvailabilityValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.StaffId)
            .NotEmpty();

        RuleFor(command => command.AvailabilityStatusId)
            .NotEmpty();
    }
}

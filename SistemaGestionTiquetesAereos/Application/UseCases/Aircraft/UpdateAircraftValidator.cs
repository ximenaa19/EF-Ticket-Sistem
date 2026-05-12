using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Aircraft;

public sealed class UpdateAircraftValidator : AbstractValidator<UpdateAircraftCommand>
{
    public UpdateAircraftValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.RegistrationNumber)
            .NotEmpty()
            .MaximumLength(30);

        RuleFor(command => command.AirlineId)
            .NotEmpty();

        RuleFor(command => command.AircraftModelId)
            .NotEmpty();

        RuleFor(command => command.AvailabilityStatusId)
            .NotEmpty();

        RuleFor(command => command.TotalCapacity)
            .GreaterThanOrEqualTo(0);
    }
}

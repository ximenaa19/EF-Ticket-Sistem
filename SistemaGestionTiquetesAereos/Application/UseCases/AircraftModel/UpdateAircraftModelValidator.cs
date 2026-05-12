using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.AircraftModel;

public sealed class UpdateAircraftModelValidator : AbstractValidator<UpdateAircraftModelCommand>
{
    public UpdateAircraftModelValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(120);

        RuleFor(command => command.AircraftManufacturerId)
            .NotEmpty();
    }
}

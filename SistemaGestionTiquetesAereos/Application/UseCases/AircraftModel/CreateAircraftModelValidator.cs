using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.AircraftModel;

public sealed class CreateAircraftModelValidator : AbstractValidator<CreateAircraftModelCommand>
{
    public CreateAircraftModelValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(120);

        RuleFor(command => command.AircraftManufacturerId)
            .NotEmpty();
    }
}

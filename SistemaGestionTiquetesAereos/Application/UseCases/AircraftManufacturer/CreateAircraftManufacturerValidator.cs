using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.AircraftManufacturer;

public sealed class CreateAircraftManufacturerValidator : AbstractValidator<CreateAircraftManufacturerCommand>
{
    public CreateAircraftManufacturerValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(120);
    }
}

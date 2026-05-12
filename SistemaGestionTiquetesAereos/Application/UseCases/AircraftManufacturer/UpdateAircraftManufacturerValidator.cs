using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.AircraftManufacturer;

public sealed class UpdateAircraftManufacturerValidator : AbstractValidator<UpdateAircraftManufacturerCommand>
{
    public UpdateAircraftManufacturerValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(120);
    }
}

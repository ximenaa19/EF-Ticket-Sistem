using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.CabinConfiguration;

public sealed class CreateCabinConfigurationValidator : AbstractValidator<CreateCabinConfigurationCommand>
{
    public CreateCabinConfigurationValidator()
    {
        RuleFor(command => command.AircraftId)
            .NotEmpty();

        RuleFor(command => command.CabinTypeId)
            .NotEmpty();

        RuleFor(command => command.SeatCount)
            .GreaterThanOrEqualTo(0);
    }
}

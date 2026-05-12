using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.CabinConfiguration;

public sealed class UpdateCabinConfigurationValidator : AbstractValidator<UpdateCabinConfigurationCommand>
{
    public UpdateCabinConfigurationValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.AircraftId)
            .NotEmpty();

        RuleFor(command => command.CabinTypeId)
            .NotEmpty();

        RuleFor(command => command.SeatCount)
            .GreaterThanOrEqualTo(0);
    }
}

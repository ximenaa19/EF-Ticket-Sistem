using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Route;

public sealed class CreateRouteValidator : AbstractValidator<CreateRouteCommand>
{
    public CreateRouteValidator()
    {
        RuleFor(command => command.OriginAirportId)
            .NotEmpty();

        RuleFor(command => command.DestinationAirportId)
            .NotEmpty();

        RuleFor(command => command.DistanceKm)
            .GreaterThanOrEqualTo(0);
    }
}

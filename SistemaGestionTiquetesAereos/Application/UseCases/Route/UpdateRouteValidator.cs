using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.Route;

public sealed class UpdateRouteValidator : AbstractValidator<UpdateRouteCommand>
{
    public UpdateRouteValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.OriginAirportId)
            .NotEmpty();

        RuleFor(command => command.DestinationAirportId)
            .NotEmpty();

        RuleFor(command => command.DistanceKm)
            .GreaterThanOrEqualTo(0);
    }
}

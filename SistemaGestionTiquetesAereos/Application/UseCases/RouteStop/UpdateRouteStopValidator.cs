using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.RouteStop;

public sealed class UpdateRouteStopValidator : AbstractValidator<UpdateRouteStopCommand>
{
    public UpdateRouteStopValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();

        RuleFor(command => command.RouteId)
            .NotEmpty();

        RuleFor(command => command.AirportId)
            .NotEmpty();

        RuleFor(command => command.StopOrder)
            .GreaterThanOrEqualTo(0);
    }
}

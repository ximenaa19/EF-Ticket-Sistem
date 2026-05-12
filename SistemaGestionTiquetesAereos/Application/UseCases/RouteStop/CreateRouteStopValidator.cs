using FluentValidation;

namespace AirlineTicketSystem.Application.UseCases.RouteStop;

public sealed class CreateRouteStopValidator : AbstractValidator<CreateRouteStopCommand>
{
    public CreateRouteStopValidator()
    {
        RuleFor(command => command.RouteId)
            .NotEmpty();

        RuleFor(command => command.AirportId)
            .NotEmpty();

        RuleFor(command => command.StopOrder)
            .GreaterThanOrEqualTo(0);
    }
}

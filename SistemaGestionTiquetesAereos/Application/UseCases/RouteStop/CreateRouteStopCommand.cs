using MediatR;

namespace AirlineTicketSystem.Application.UseCases.RouteStop;

public sealed record CreateRouteStopCommand(Guid RouteId,
    Guid AirportId,
    int StopOrder) : IRequest<Guid>;

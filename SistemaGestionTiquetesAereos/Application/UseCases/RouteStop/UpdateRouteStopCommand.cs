using MediatR;

namespace AirlineTicketSystem.Application.UseCases.RouteStop;

public sealed record UpdateRouteStopCommand(Guid Id, Guid RouteId,
    Guid AirportId,
    int StopOrder, bool IsActive) : IRequest;

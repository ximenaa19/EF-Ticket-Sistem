using MediatR;

namespace AirlineTicketSystem.Application.UseCases.RouteStop;

public sealed record DeleteRouteStopCommand(Guid Id) : IRequest;

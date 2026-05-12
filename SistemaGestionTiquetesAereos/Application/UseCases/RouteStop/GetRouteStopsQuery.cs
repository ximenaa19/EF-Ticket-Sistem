using MediatR;

namespace AirlineTicketSystem.Application.UseCases.RouteStop;

public sealed record GetRouteStopsQuery : IRequest<IReadOnlyList<Domain.Entities.RouteStop>>;

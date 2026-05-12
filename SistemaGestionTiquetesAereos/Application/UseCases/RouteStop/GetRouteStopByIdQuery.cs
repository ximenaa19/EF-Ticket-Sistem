using MediatR;

namespace AirlineTicketSystem.Application.UseCases.RouteStop;

public sealed record GetRouteStopByIdQuery(Guid Id) : IRequest<Domain.Entities.RouteStop>;

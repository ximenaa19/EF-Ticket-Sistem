using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Route;

public sealed record CreateRouteCommand(Guid OriginAirportId,
    Guid DestinationAirportId,
    decimal DistanceKm) : IRequest<Guid>;

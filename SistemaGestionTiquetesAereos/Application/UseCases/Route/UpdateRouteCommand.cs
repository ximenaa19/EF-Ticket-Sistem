using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Route;

public sealed record UpdateRouteCommand(Guid Id, Guid OriginAirportId,
    Guid DestinationAirportId,
    decimal DistanceKm, bool IsActive) : IRequest;

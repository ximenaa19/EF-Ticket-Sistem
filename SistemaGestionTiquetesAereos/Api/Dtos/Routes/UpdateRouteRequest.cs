namespace AirlineTicketSystem.Api.Dtos.Routes;

public sealed record UpdateRouteRequest(
    Guid OriginAirportId,
    Guid DestinationAirportId,
    decimal DistanceKm,
    bool IsActive);

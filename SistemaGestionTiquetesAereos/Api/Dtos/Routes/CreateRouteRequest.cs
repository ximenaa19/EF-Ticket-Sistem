namespace AirlineTicketSystem.Api.Dtos.Routes;

public sealed record CreateRouteRequest(
    Guid OriginAirportId,
    Guid DestinationAirportId,
    decimal DistanceKm);

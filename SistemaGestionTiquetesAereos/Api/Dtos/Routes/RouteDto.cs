namespace AirlineTicketSystem.Api.Dtos.Routes;

public sealed record RouteDto(
    Guid Id,
    Guid OriginAirportId,
    Guid DestinationAirportId,
    decimal DistanceKm,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);

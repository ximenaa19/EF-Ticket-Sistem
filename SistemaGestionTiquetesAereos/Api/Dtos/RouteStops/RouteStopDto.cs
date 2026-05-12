namespace AirlineTicketSystem.Api.Dtos.RouteStops;

public sealed record RouteStopDto(
    Guid Id,
    Guid RouteId,
    Guid AirportId,
    int StopOrder,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);

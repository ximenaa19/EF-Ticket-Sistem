namespace AirlineTicketSystem.Api.Dtos.RouteStops;

public sealed record UpdateRouteStopRequest(
    Guid RouteId,
    Guid AirportId,
    int StopOrder,
    bool IsActive);

namespace AirlineTicketSystem.Api.Dtos.RouteStops;

public sealed record CreateRouteStopRequest(
    Guid RouteId,
    Guid AirportId,
    int StopOrder);

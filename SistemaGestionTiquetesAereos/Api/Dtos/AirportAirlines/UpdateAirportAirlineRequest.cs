namespace AirlineTicketSystem.Api.Dtos.AirportAirlines;

public sealed record UpdateAirportAirlineRequest(
    Guid AirportId,
    Guid AirlineId,
    bool IsActive);

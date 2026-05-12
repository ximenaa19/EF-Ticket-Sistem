namespace AirlineTicketSystem.Api.Dtos.AirportAirlines;

public sealed record CreateAirportAirlineRequest(
    Guid AirportId,
    Guid AirlineId);

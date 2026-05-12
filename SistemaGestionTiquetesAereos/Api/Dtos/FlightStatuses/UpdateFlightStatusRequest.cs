namespace AirlineTicketSystem.Api.Dtos.FlightStatuses;

public sealed record UpdateFlightStatusRequest(
    string Name,
    bool IsActive);

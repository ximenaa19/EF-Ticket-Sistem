namespace AirlineTicketSystem.Api.Dtos.FlightRoles;

public sealed record UpdateFlightRoleRequest(
    string Name,
    bool IsActive);

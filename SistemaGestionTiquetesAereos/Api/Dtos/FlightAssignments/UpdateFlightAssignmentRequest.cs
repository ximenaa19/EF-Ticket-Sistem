namespace AirlineTicketSystem.Api.Dtos.FlightAssignments;

public sealed record UpdateFlightAssignmentRequest(
    Guid FlightId,
    Guid StaffId,
    Guid FlightRoleId,
    bool IsActive);

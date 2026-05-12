namespace AirlineTicketSystem.Api.Dtos.FlightAssignments;

public sealed record CreateFlightAssignmentRequest(
    Guid FlightId,
    Guid StaffId,
    Guid FlightRoleId);

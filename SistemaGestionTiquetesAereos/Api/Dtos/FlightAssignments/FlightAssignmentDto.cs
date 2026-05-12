namespace AirlineTicketSystem.Api.Dtos.FlightAssignments;

public sealed record FlightAssignmentDto(
    Guid Id,
    Guid FlightId,
    Guid StaffId,
    Guid FlightRoleId,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);

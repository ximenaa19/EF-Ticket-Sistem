namespace AirlineTicketSystem.Api.Dtos.FlightRoles;

public sealed record FlightRoleDto(
    Guid Id,
    string Name,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);

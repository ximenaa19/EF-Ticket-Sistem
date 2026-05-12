namespace AirlineTicketSystem.Api.Dtos.Roles;

public sealed record RoleDto(
    Guid Id,
    string Name,
    string Code,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);

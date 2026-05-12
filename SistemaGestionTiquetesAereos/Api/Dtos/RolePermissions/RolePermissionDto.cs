namespace AirlineTicketSystem.Api.Dtos.RolePermissions;

public sealed record RolePermissionDto(
    Guid Id,
    Guid RoleId,
    Guid PermissionId,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);

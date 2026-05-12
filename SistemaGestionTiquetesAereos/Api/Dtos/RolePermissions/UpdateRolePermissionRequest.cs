namespace AirlineTicketSystem.Api.Dtos.RolePermissions;

public sealed record UpdateRolePermissionRequest(
    Guid RoleId,
    Guid PermissionId,
    bool IsActive);

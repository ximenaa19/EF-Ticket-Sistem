namespace AirlineTicketSystem.Api.Dtos.RolePermissions;

public sealed record CreateRolePermissionRequest(
    Guid RoleId,
    Guid PermissionId);

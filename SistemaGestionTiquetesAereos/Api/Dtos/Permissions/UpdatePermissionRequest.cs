namespace AirlineTicketSystem.Api.Dtos.Permissions;

public sealed record UpdatePermissionRequest(
    string Name,
    string Code,
    bool IsActive);

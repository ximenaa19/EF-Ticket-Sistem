namespace AirlineTicketSystem.Api.Dtos.Permissions;

public sealed record CreatePermissionRequest(
    string Name,
    string Code);

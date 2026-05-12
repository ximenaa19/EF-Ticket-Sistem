namespace AirlineTicketSystem.Api.Dtos.Roles;

public sealed record UpdateRoleRequest(
    string Name,
    string Code,
    bool IsActive);

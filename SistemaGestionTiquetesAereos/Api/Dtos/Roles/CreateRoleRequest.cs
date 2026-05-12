namespace AirlineTicketSystem.Api.Dtos.Roles;

public sealed record CreateRoleRequest(
    string Name,
    string Code);

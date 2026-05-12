namespace AirlineTicketSystem.Api.Dtos.Permissions;

public sealed record PermissionDto(
    Guid Id,
    string Name,
    string Code,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);

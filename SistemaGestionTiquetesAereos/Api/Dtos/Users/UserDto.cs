namespace AirlineTicketSystem.Api.Dtos.Users;

public sealed record UserDto(
    Guid Id,
    Guid PersonId,
    Guid RoleId,
    string UserName,
    string PasswordHash,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);

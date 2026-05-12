namespace AirlineTicketSystem.Api.Dtos.Users;

public sealed record UpdateUserRequest(
    Guid PersonId,
    Guid RoleId,
    string UserName,
    string PasswordHash,
    bool IsActive);

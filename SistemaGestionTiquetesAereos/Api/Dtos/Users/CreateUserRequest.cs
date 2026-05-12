namespace AirlineTicketSystem.Api.Dtos.Users;

public sealed record CreateUserRequest(
    Guid PersonId,
    Guid RoleId,
    string UserName,
    string PasswordHash);

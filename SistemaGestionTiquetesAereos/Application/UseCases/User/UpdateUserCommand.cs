using MediatR;

namespace AirlineTicketSystem.Application.UseCases.User;

public sealed record UpdateUserCommand(Guid Id, Guid PersonId,
    Guid RoleId,
    string UserName,
    string PasswordHash, bool IsActive) : IRequest;

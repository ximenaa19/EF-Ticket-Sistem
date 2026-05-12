using MediatR;

namespace AirlineTicketSystem.Application.UseCases.User;

public sealed record CreateUserCommand(Guid PersonId,
    Guid RoleId,
    string UserName,
    string PasswordHash) : IRequest<Guid>;

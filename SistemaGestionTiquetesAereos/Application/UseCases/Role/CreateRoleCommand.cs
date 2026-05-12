using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Role;

public sealed record CreateRoleCommand(string Name,
    string Code) : IRequest<Guid>;

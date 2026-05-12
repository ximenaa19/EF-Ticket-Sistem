using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Role;

public sealed record UpdateRoleCommand(Guid Id, string Name,
    string Code, bool IsActive) : IRequest;

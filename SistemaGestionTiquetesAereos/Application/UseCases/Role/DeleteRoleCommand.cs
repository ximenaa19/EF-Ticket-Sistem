using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Role;

public sealed record DeleteRoleCommand(Guid Id) : IRequest;

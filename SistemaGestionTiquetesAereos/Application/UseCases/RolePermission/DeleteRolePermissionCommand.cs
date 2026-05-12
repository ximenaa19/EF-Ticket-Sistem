using MediatR;

namespace AirlineTicketSystem.Application.UseCases.RolePermission;

public sealed record DeleteRolePermissionCommand(Guid Id) : IRequest;

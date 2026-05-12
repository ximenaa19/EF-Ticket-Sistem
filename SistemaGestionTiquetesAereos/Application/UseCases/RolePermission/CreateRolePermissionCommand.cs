using MediatR;

namespace AirlineTicketSystem.Application.UseCases.RolePermission;

public sealed record CreateRolePermissionCommand(Guid RoleId,
    Guid PermissionId) : IRequest<Guid>;

using MediatR;

namespace AirlineTicketSystem.Application.UseCases.RolePermission;

public sealed record UpdateRolePermissionCommand(Guid Id, Guid RoleId,
    Guid PermissionId, bool IsActive) : IRequest;

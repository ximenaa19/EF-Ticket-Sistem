using MediatR;

namespace AirlineTicketSystem.Application.UseCases.RolePermission;

public sealed record GetRolePermissionByIdQuery(Guid Id) : IRequest<Domain.Entities.RolePermission>;

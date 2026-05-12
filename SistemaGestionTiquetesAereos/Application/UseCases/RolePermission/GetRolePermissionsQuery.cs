using MediatR;

namespace AirlineTicketSystem.Application.UseCases.RolePermission;

public sealed record GetRolePermissionsQuery : IRequest<IReadOnlyList<Domain.Entities.RolePermission>>;

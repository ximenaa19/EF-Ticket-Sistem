using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.RolePermission;

public sealed class GetRolePermissionsHandler : IRequestHandler<GetRolePermissionsQuery, IReadOnlyList<Domain.Entities.RolePermission>>
{
    private readonly IRolePermission _rolePermissionRepository;

    public GetRolePermissionsHandler(IRolePermission rolePermissionRepository)
    {
        _rolePermissionRepository = rolePermissionRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.RolePermission>> Handle(GetRolePermissionsQuery request, CancellationToken cancellationToken)
    {
        return _rolePermissionRepository.GetAllAsync(cancellationToken);
    }
}

using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.RolePermission;

public sealed class GetRolePermissionByIdHandler : IRequestHandler<GetRolePermissionByIdQuery, Domain.Entities.RolePermission>
{
    private readonly IRolePermission _rolePermissionRepository;

    public GetRolePermissionByIdHandler(IRolePermission rolePermissionRepository)
    {
        _rolePermissionRepository = rolePermissionRepository;
    }

    public async Task<Domain.Entities.RolePermission> Handle(GetRolePermissionByIdQuery request, CancellationToken cancellationToken)
    {
        return await _rolePermissionRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.RolePermission), request.Id);
    }
}

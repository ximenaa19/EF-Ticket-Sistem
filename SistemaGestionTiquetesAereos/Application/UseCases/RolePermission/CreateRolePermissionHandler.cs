using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.RolePermission;

public sealed class CreateRolePermissionHandler : IRequestHandler<CreateRolePermissionCommand, Guid>
{
    private readonly IRolePermission _rolePermissionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRolePermissionHandler(IRolePermission rolePermissionRepository, IUnitOfWork unitOfWork)
    {
        _rolePermissionRepository = rolePermissionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateRolePermissionCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.RolePermission(request.RoleId, request.PermissionId);

        await _rolePermissionRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}

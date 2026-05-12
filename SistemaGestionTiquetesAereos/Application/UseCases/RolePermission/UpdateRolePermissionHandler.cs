using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.RolePermission;

public sealed class UpdateRolePermissionHandler : IRequestHandler<UpdateRolePermissionCommand>
{
    private readonly IRolePermission _rolePermissionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRolePermissionHandler(IRolePermission rolePermissionRepository, IUnitOfWork unitOfWork)
    {
        _rolePermissionRepository = rolePermissionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateRolePermissionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _rolePermissionRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.RolePermission), request.Id);

        entity.Update(request.RoleId, request.PermissionId, request.IsActive);

        _rolePermissionRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.RolePermission;

public sealed class DeleteRolePermissionHandler : IRequestHandler<DeleteRolePermissionCommand>
{
    private readonly IRolePermission _rolePermissionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRolePermissionHandler(IRolePermission rolePermissionRepository, IUnitOfWork unitOfWork)
    {
        _rolePermissionRepository = rolePermissionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteRolePermissionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _rolePermissionRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.RolePermission), request.Id);

        _rolePermissionRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

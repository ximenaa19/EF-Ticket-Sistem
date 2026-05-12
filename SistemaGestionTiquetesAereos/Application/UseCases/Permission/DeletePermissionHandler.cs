using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Permission;

public sealed class DeletePermissionHandler : IRequestHandler<DeletePermissionCommand>
{
    private readonly IPermission _permissionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePermissionHandler(IPermission permissionRepository, IUnitOfWork unitOfWork)
    {
        _permissionRepository = permissionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _permissionRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Permission), request.Id);

        _permissionRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

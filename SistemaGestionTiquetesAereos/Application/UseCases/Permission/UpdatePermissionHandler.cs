using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Permission;

public sealed class UpdatePermissionHandler : IRequestHandler<UpdatePermissionCommand>
{
    private readonly IPermission _permissionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePermissionHandler(IPermission permissionRepository, IUnitOfWork unitOfWork)
    {
        _permissionRepository = permissionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _permissionRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Permission), request.Id);

        if (await _permissionRepository.ExistsByCodeAsync(request.Code, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("Permission with Code '" + request.Code + "' already exists.");
        }
        entity.Update(request.Name, request.Code, request.IsActive);

        _permissionRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Permission;

public sealed class CreatePermissionHandler : IRequestHandler<CreatePermissionCommand, Guid>
{
    private readonly IPermission _permissionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePermissionHandler(IPermission permissionRepository, IUnitOfWork unitOfWork)
    {
        _permissionRepository = permissionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
    {
        if (await _permissionRepository.ExistsByCodeAsync(request.Code, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("Permission with Code '" + request.Code + "' already exists.");
        }
        var entity = new Domain.Entities.Permission(request.Name, request.Code);

        await _permissionRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}

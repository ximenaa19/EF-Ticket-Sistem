using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Permission;

public sealed class GetPermissionByIdHandler : IRequestHandler<GetPermissionByIdQuery, Domain.Entities.Permission>
{
    private readonly IPermission _permissionRepository;

    public GetPermissionByIdHandler(IPermission permissionRepository)
    {
        _permissionRepository = permissionRepository;
    }

    public async Task<Domain.Entities.Permission> Handle(GetPermissionByIdQuery request, CancellationToken cancellationToken)
    {
        return await _permissionRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Permission), request.Id);
    }
}

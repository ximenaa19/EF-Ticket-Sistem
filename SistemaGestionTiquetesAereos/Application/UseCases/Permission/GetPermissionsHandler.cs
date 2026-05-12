using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Permission;

public sealed class GetPermissionsHandler : IRequestHandler<GetPermissionsQuery, IReadOnlyList<Domain.Entities.Permission>>
{
    private readonly IPermission _permissionRepository;

    public GetPermissionsHandler(IPermission permissionRepository)
    {
        _permissionRepository = permissionRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.Permission>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
    {
        return _permissionRepository.GetAllAsync(cancellationToken);
    }
}

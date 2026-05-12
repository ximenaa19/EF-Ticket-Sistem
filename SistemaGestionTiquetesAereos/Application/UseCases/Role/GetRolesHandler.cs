using AirlineTicketSystem.Application.Abstractions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Role;

public sealed class GetRolesHandler : IRequestHandler<GetRolesQuery, IReadOnlyList<Domain.Entities.Role>>
{
    private readonly IRole _roleRepository;

    public GetRolesHandler(IRole roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public Task<IReadOnlyList<Domain.Entities.Role>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        return _roleRepository.GetAllAsync(cancellationToken);
    }
}

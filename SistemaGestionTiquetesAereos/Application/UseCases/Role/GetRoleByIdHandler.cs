using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Role;

public sealed class GetRoleByIdHandler : IRequestHandler<GetRoleByIdQuery, Domain.Entities.Role>
{
    private readonly IRole _roleRepository;

    public GetRoleByIdHandler(IRole roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<Domain.Entities.Role> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        return await _roleRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Role), request.Id);
    }
}

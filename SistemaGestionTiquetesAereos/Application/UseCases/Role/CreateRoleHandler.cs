using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Role;

public sealed class CreateRoleHandler : IRequestHandler<CreateRoleCommand, Guid>
{
    private readonly IRole _roleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRoleHandler(IRole roleRepository, IUnitOfWork unitOfWork)
    {
        _roleRepository = roleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        if (await _roleRepository.ExistsByCodeAsync(request.Code, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("Role with Code '" + request.Code + "' already exists.");
        }
        var entity = new Domain.Entities.Role(request.Name, request.Code);

        await _roleRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}

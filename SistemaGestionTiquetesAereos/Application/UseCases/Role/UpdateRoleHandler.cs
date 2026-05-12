using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Role;

public sealed class UpdateRoleHandler : IRequestHandler<UpdateRoleCommand>
{
    private readonly IRole _roleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRoleHandler(IRole roleRepository, IUnitOfWork unitOfWork)
    {
        _roleRepository = roleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _roleRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Role), request.Id);

        if (await _roleRepository.ExistsByCodeAsync(request.Code, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("Role with Code '" + request.Code + "' already exists.");
        }
        entity.Update(request.Name, request.Code, request.IsActive);

        _roleRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

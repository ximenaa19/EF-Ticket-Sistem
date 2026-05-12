using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Role;

public sealed class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand>
{
    private readonly IRole _roleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRoleHandler(IRole roleRepository, IUnitOfWork unitOfWork)
    {
        _roleRepository = roleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _roleRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Role), request.Id);

        _roleRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

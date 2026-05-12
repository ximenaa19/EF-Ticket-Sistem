using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CabinType;

public sealed class UpdateCabinTypeHandler : IRequestHandler<UpdateCabinTypeCommand>
{
    private readonly ICabinType _cabinTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCabinTypeHandler(ICabinType cabinTypeRepository, IUnitOfWork unitOfWork)
    {
        _cabinTypeRepository = cabinTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCabinTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _cabinTypeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.CabinType), request.Id);

        if (await _cabinTypeRepository.ExistsByNameAsync(request.Name, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("CabinType with Name '" + request.Name + "' already exists.");
        }
        entity.Update(request.Name, request.IsActive);

        _cabinTypeRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

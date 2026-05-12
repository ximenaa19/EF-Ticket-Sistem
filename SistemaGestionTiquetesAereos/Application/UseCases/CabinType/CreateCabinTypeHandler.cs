using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.CabinType;

public sealed class CreateCabinTypeHandler : IRequestHandler<CreateCabinTypeCommand, Guid>
{
    private readonly ICabinType _cabinTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCabinTypeHandler(ICabinType cabinTypeRepository, IUnitOfWork unitOfWork)
    {
        _cabinTypeRepository = cabinTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateCabinTypeCommand request, CancellationToken cancellationToken)
    {
        if (await _cabinTypeRepository.ExistsByNameAsync(request.Name, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("CabinType with Name '" + request.Name + "' already exists.");
        }
        var entity = new Domain.Entities.CabinType(request.Name);

        await _cabinTypeRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}

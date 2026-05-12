using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.RoadType;

public sealed class CreateRoadTypeHandler : IRequestHandler<CreateRoadTypeCommand, Guid>
{
    private readonly IRoadType _roadTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRoadTypeHandler(IRoadType roadTypeRepository, IUnitOfWork unitOfWork)
    {
        _roadTypeRepository = roadTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateRoadTypeCommand request, CancellationToken cancellationToken)
    {
        if (await _roadTypeRepository.ExistsByNameAsync(request.Name, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("RoadType with Name '" + request.Name + "' already exists.");
        }
        var entity = new Domain.Entities.RoadType(request.Name);

        await _roadTypeRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}

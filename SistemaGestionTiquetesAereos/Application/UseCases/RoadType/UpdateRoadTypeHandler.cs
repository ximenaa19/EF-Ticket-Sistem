using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.RoadType;

public sealed class UpdateRoadTypeHandler : IRequestHandler<UpdateRoadTypeCommand>
{
    private readonly IRoadType _roadTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRoadTypeHandler(IRoadType roadTypeRepository, IUnitOfWork unitOfWork)
    {
        _roadTypeRepository = roadTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateRoadTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _roadTypeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.RoadType), request.Id);

        if (await _roadTypeRepository.ExistsByNameAsync(request.Name, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("RoadType with Name '" + request.Name + "' already exists.");
        }
        entity.Update(request.Name, request.IsActive);

        _roadTypeRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

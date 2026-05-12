using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.RoadType;

public sealed class DeleteRoadTypeHandler : IRequestHandler<DeleteRoadTypeCommand>
{
    private readonly IRoadType _roadTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRoadTypeHandler(IRoadType roadTypeRepository, IUnitOfWork unitOfWork)
    {
        _roadTypeRepository = roadTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteRoadTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _roadTypeRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.RoadType), request.Id);

        _roadTypeRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AircraftModel;

public sealed class DeleteAircraftModelHandler : IRequestHandler<DeleteAircraftModelCommand>
{
    private readonly IAircraftModel _aircraftModelRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAircraftModelHandler(IAircraftModel aircraftModelRepository, IUnitOfWork unitOfWork)
    {
        _aircraftModelRepository = aircraftModelRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteAircraftModelCommand request, CancellationToken cancellationToken)
    {
        var entity = await _aircraftModelRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.AircraftModel), request.Id);

        _aircraftModelRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

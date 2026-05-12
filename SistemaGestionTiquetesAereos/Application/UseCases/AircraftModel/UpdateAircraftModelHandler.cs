using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AircraftModel;

public sealed class UpdateAircraftModelHandler : IRequestHandler<UpdateAircraftModelCommand>
{
    private readonly IAircraftModel _aircraftModelRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAircraftModelHandler(IAircraftModel aircraftModelRepository, IUnitOfWork unitOfWork)
    {
        _aircraftModelRepository = aircraftModelRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateAircraftModelCommand request, CancellationToken cancellationToken)
    {
        var entity = await _aircraftModelRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.AircraftModel), request.Id);

        if (await _aircraftModelRepository.ExistsByNameAsync(request.Name, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("AircraftModel with Name '" + request.Name + "' already exists.");
        }
        entity.Update(request.Name, request.AircraftManufacturerId, request.IsActive);

        _aircraftModelRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

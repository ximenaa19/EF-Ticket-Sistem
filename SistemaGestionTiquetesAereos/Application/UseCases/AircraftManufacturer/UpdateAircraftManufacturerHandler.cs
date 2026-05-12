using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AircraftManufacturer;

public sealed class UpdateAircraftManufacturerHandler : IRequestHandler<UpdateAircraftManufacturerCommand>
{
    private readonly IAircraftManufacturer _aircraftManufacturerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAircraftManufacturerHandler(IAircraftManufacturer aircraftManufacturerRepository, IUnitOfWork unitOfWork)
    {
        _aircraftManufacturerRepository = aircraftManufacturerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateAircraftManufacturerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _aircraftManufacturerRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.AircraftManufacturer), request.Id);

        if (await _aircraftManufacturerRepository.ExistsByNameAsync(request.Name, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("AircraftManufacturer with Name '" + request.Name + "' already exists.");
        }
        entity.Update(request.Name, request.IsActive);

        _aircraftManufacturerRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

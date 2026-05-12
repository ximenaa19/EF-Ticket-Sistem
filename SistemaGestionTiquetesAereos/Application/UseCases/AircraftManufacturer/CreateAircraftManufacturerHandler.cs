using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AircraftManufacturer;

public sealed class CreateAircraftManufacturerHandler : IRequestHandler<CreateAircraftManufacturerCommand, Guid>
{
    private readonly IAircraftManufacturer _aircraftManufacturerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAircraftManufacturerHandler(IAircraftManufacturer aircraftManufacturerRepository, IUnitOfWork unitOfWork)
    {
        _aircraftManufacturerRepository = aircraftManufacturerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateAircraftManufacturerCommand request, CancellationToken cancellationToken)
    {
        if (await _aircraftManufacturerRepository.ExistsByNameAsync(request.Name, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("AircraftManufacturer with Name '" + request.Name + "' already exists.");
        }
        var entity = new Domain.Entities.AircraftManufacturer(request.Name);

        await _aircraftManufacturerRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}

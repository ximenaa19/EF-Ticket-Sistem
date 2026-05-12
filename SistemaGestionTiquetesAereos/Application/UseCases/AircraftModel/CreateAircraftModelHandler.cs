using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.AircraftModel;

public sealed class CreateAircraftModelHandler : IRequestHandler<CreateAircraftModelCommand, Guid>
{
    private readonly IAircraftModel _aircraftModelRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAircraftModelHandler(IAircraftModel aircraftModelRepository, IUnitOfWork unitOfWork)
    {
        _aircraftModelRepository = aircraftModelRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateAircraftModelCommand request, CancellationToken cancellationToken)
    {
        if (await _aircraftModelRepository.ExistsByNameAsync(request.Name, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("AircraftModel with Name '" + request.Name + "' already exists.");
        }
        var entity = new Domain.Entities.AircraftModel(request.Name, request.AircraftManufacturerId);

        await _aircraftModelRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}

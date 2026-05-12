using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Aircraft;

public sealed class CreateAircraftHandler : IRequestHandler<CreateAircraftCommand, Guid>
{
    private readonly IAircraft _aircraftRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAircraftHandler(IAircraft aircraftRepository, IUnitOfWork unitOfWork)
    {
        _aircraftRepository = aircraftRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateAircraftCommand request, CancellationToken cancellationToken)
    {
        if (await _aircraftRepository.ExistsByRegistrationNumberAsync(request.RegistrationNumber, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("Aircraft with RegistrationNumber '" + request.RegistrationNumber + "' already exists.");
        }
        var entity = new Domain.Entities.Aircraft(request.RegistrationNumber, request.AirlineId, request.AircraftModelId, request.AvailabilityStatusId, request.TotalCapacity);

        await _aircraftRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}

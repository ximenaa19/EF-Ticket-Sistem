using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Aircraft;

public sealed class UpdateAircraftHandler : IRequestHandler<UpdateAircraftCommand>
{
    private readonly IAircraft _aircraftRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAircraftHandler(IAircraft aircraftRepository, IUnitOfWork unitOfWork)
    {
        _aircraftRepository = aircraftRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateAircraftCommand request, CancellationToken cancellationToken)
    {
        var entity = await _aircraftRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Aircraft), request.Id);

        if (await _aircraftRepository.ExistsByRegistrationNumberAsync(request.RegistrationNumber, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("Aircraft with RegistrationNumber '" + request.RegistrationNumber + "' already exists.");
        }
        entity.Update(request.RegistrationNumber, request.AirlineId, request.AircraftModelId, request.AvailabilityStatusId, request.TotalCapacity, request.IsActive);

        _aircraftRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

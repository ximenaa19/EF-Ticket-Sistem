using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.FlightStatus;

public sealed class UpdateFlightStatusHandler : IRequestHandler<UpdateFlightStatusCommand>
{
    private readonly IFlightStatus _flightStatusRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFlightStatusHandler(IFlightStatus flightStatusRepository, IUnitOfWork unitOfWork)
    {
        _flightStatusRepository = flightStatusRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateFlightStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _flightStatusRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.FlightStatus), request.Id);

        if (await _flightStatusRepository.ExistsByNameAsync(request.Name, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("FlightStatus with Name '" + request.Name + "' already exists.");
        }
        entity.Update(request.Name, request.IsActive);

        _flightStatusRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

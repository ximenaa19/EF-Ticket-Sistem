using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Flight;

public sealed class UpdateFlightHandler : IRequestHandler<UpdateFlightCommand>
{
    private readonly IFlight _flightRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFlightHandler(IFlight flightRepository, IUnitOfWork unitOfWork)
    {
        _flightRepository = flightRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateFlightCommand request, CancellationToken cancellationToken)
    {
        var entity = await _flightRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Flight), request.Id);

        if (await _flightRepository.ExistsByFlightCodeAsync(request.FlightCode, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("Flight with FlightCode '" + request.FlightCode + "' already exists.");
        }
        entity.Update(request.FlightCode, request.AirlineId, request.RouteId, request.AircraftId, request.DepartureDate, request.EstimatedArrivalDate, request.TotalCapacity, request.AvailableSeats, request.FlightStatusId, request.IsActive);

        _flightRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

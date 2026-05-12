using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Flight;

public sealed class CreateFlightHandler : IRequestHandler<CreateFlightCommand, Guid>
{
    private readonly IFlight _flightRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateFlightHandler(IFlight flightRepository, IUnitOfWork unitOfWork)
    {
        _flightRepository = flightRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
    {
        if (await _flightRepository.ExistsByFlightCodeAsync(request.FlightCode, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("Flight with FlightCode '" + request.FlightCode + "' already exists.");
        }
        var entity = new Domain.Entities.Flight(request.FlightCode, request.AirlineId, request.RouteId, request.AircraftId, request.DepartureDate, request.EstimatedArrivalDate, request.TotalCapacity, request.AvailableSeats, request.FlightStatusId);

        await _flightRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}

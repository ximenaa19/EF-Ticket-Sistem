using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationFlight;

public sealed class CreateReservationFlightHandler : IRequestHandler<CreateReservationFlightCommand, Guid>
{
    private readonly IReservationFlight _reservationFlightRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateReservationFlightHandler(IReservationFlight reservationFlightRepository, IUnitOfWork unitOfWork)
    {
        _reservationFlightRepository = reservationFlightRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateReservationFlightCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.ReservationFlight(request.ReservationId, request.FlightId);

        await _reservationFlightRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}

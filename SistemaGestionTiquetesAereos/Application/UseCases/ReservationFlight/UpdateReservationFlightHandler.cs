using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationFlight;

public sealed class UpdateReservationFlightHandler : IRequestHandler<UpdateReservationFlightCommand>
{
    private readonly IReservationFlight _reservationFlightRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateReservationFlightHandler(IReservationFlight reservationFlightRepository, IUnitOfWork unitOfWork)
    {
        _reservationFlightRepository = reservationFlightRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateReservationFlightCommand request, CancellationToken cancellationToken)
    {
        var entity = await _reservationFlightRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.ReservationFlight), request.Id);

        entity.Update(request.ReservationId, request.FlightId, request.IsActive);

        _reservationFlightRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

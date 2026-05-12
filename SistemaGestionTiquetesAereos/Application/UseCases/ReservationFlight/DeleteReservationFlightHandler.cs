using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationFlight;

public sealed class DeleteReservationFlightHandler : IRequestHandler<DeleteReservationFlightCommand>
{
    private readonly IReservationFlight _reservationFlightRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteReservationFlightHandler(IReservationFlight reservationFlightRepository, IUnitOfWork unitOfWork)
    {
        _reservationFlightRepository = reservationFlightRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteReservationFlightCommand request, CancellationToken cancellationToken)
    {
        var entity = await _reservationFlightRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.ReservationFlight), request.Id);

        _reservationFlightRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

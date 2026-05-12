using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationStatus;

public sealed class DeleteReservationStatusHandler : IRequestHandler<DeleteReservationStatusCommand>
{
    private readonly IReservationStatus _reservationStatusRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteReservationStatusHandler(IReservationStatus reservationStatusRepository, IUnitOfWork unitOfWork)
    {
        _reservationStatusRepository = reservationStatusRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteReservationStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _reservationStatusRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.ReservationStatus), request.Id);

        _reservationStatusRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

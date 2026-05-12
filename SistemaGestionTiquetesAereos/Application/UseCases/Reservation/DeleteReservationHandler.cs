using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Reservation;

public sealed class DeleteReservationHandler : IRequestHandler<DeleteReservationCommand>
{
    private readonly IReservation _reservationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteReservationHandler(IReservation reservationRepository, IUnitOfWork unitOfWork)
    {
        _reservationRepository = reservationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _reservationRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Reservation), request.Id);

        _reservationRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

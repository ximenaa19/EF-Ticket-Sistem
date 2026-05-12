using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationStatusTransition;

public sealed class DeleteReservationStatusTransitionHandler : IRequestHandler<DeleteReservationStatusTransitionCommand>
{
    private readonly IReservationStatusTransition _reservationStatusTransitionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteReservationStatusTransitionHandler(IReservationStatusTransition reservationStatusTransitionRepository, IUnitOfWork unitOfWork)
    {
        _reservationStatusTransitionRepository = reservationStatusTransitionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteReservationStatusTransitionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _reservationStatusTransitionRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.ReservationStatusTransition), request.Id);

        _reservationStatusTransitionRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

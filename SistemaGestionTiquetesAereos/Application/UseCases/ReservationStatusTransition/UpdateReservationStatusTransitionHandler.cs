using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationStatusTransition;

public sealed class UpdateReservationStatusTransitionHandler : IRequestHandler<UpdateReservationStatusTransitionCommand>
{
    private readonly IReservationStatusTransition _reservationStatusTransitionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateReservationStatusTransitionHandler(IReservationStatusTransition reservationStatusTransitionRepository, IUnitOfWork unitOfWork)
    {
        _reservationStatusTransitionRepository = reservationStatusTransitionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateReservationStatusTransitionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _reservationStatusTransitionRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.ReservationStatusTransition), request.Id);

        entity.Update(request.ReservationId, request.FromReservationStatusId, request.ToReservationStatusId, request.ChangedAt, request.IsActive);

        _reservationStatusTransitionRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationStatusTransition;

public sealed class CreateReservationStatusTransitionHandler : IRequestHandler<CreateReservationStatusTransitionCommand, Guid>
{
    private readonly IReservationStatusTransition _reservationStatusTransitionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateReservationStatusTransitionHandler(IReservationStatusTransition reservationStatusTransitionRepository, IUnitOfWork unitOfWork)
    {
        _reservationStatusTransitionRepository = reservationStatusTransitionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateReservationStatusTransitionCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.ReservationStatusTransition(request.ReservationId, request.FromReservationStatusId, request.ToReservationStatusId, request.ChangedAt);

        await _reservationStatusTransitionRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}

using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationPassenger;

public sealed class UpdateReservationPassengerHandler : IRequestHandler<UpdateReservationPassengerCommand>
{
    private readonly IReservationPassenger _reservationPassengerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateReservationPassengerHandler(IReservationPassenger reservationPassengerRepository, IUnitOfWork unitOfWork)
    {
        _reservationPassengerRepository = reservationPassengerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateReservationPassengerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _reservationPassengerRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.ReservationPassenger), request.Id);

        entity.Update(request.ReservationId, request.PassengerId, request.IsActive);

        _reservationPassengerRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

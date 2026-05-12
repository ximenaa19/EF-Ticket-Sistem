using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationPassenger;

public sealed class DeleteReservationPassengerHandler : IRequestHandler<DeleteReservationPassengerCommand>
{
    private readonly IReservationPassenger _reservationPassengerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteReservationPassengerHandler(IReservationPassenger reservationPassengerRepository, IUnitOfWork unitOfWork)
    {
        _reservationPassengerRepository = reservationPassengerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteReservationPassengerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _reservationPassengerRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.ReservationPassenger), request.Id);

        _reservationPassengerRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

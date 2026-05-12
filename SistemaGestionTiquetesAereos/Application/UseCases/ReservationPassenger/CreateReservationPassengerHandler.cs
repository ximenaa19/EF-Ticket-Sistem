using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationPassenger;

public sealed class CreateReservationPassengerHandler : IRequestHandler<CreateReservationPassengerCommand, Guid>
{
    private readonly IReservationPassenger _reservationPassengerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateReservationPassengerHandler(IReservationPassenger reservationPassengerRepository, IUnitOfWork unitOfWork)
    {
        _reservationPassengerRepository = reservationPassengerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateReservationPassengerCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.ReservationPassenger(request.ReservationId, request.PassengerId);

        await _reservationPassengerRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}

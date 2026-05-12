using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Reservation;

public sealed class CreateReservationHandler : IRequestHandler<CreateReservationCommand, Guid>
{
    private readonly IReservation _reservationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateReservationHandler(IReservation reservationRepository, IUnitOfWork unitOfWork)
    {
        _reservationRepository = reservationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        if (await _reservationRepository.ExistsByReservationCodeAsync(request.ReservationCode, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("Reservation with ReservationCode '" + request.ReservationCode + "' already exists.");
        }
        var entity = new Domain.Entities.Reservation(request.ClientId, request.ReservationStatusId, request.ReservationCode, request.ReservedAt, request.TotalAmount, request.Currency);

        await _reservationRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}

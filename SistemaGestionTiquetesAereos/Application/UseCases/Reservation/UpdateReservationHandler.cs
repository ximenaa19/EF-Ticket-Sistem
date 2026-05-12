using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.Reservation;

public sealed class UpdateReservationHandler : IRequestHandler<UpdateReservationCommand>
{
    private readonly IReservation _reservationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateReservationHandler(IReservation reservationRepository, IUnitOfWork unitOfWork)
    {
        _reservationRepository = reservationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _reservationRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.Reservation), request.Id);

        if (await _reservationRepository.ExistsByReservationCodeAsync(request.ReservationCode, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("Reservation with ReservationCode '" + request.ReservationCode + "' already exists.");
        }
        entity.Update(request.ClientId, request.ReservationStatusId, request.ReservationCode, request.ReservedAt, request.TotalAmount, request.Currency, request.IsActive);

        _reservationRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

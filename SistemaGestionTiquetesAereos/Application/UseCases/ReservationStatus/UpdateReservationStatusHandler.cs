using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationStatus;

public sealed class UpdateReservationStatusHandler : IRequestHandler<UpdateReservationStatusCommand>
{
    private readonly IReservationStatus _reservationStatusRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateReservationStatusHandler(IReservationStatus reservationStatusRepository, IUnitOfWork unitOfWork)
    {
        _reservationStatusRepository = reservationStatusRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateReservationStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _reservationStatusRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Domain.Entities.ReservationStatus), request.Id);

        if (await _reservationStatusRepository.ExistsByNameAsync(request.Name, request.Id, cancellationToken))
        {
            throw new DuplicateEntityException("ReservationStatus with Name '" + request.Name + "' already exists.");
        }
        entity.Update(request.Name, request.IsActive);

        _reservationStatusRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

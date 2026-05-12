using AirlineTicketSystem.Application.Abstractions;
using AirlineTicketSystem.Domain.Exceptions;
using MediatR;

namespace AirlineTicketSystem.Application.UseCases.ReservationStatus;

public sealed class CreateReservationStatusHandler : IRequestHandler<CreateReservationStatusCommand, Guid>
{
    private readonly IReservationStatus _reservationStatusRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateReservationStatusHandler(IReservationStatus reservationStatusRepository, IUnitOfWork unitOfWork)
    {
        _reservationStatusRepository = reservationStatusRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateReservationStatusCommand request, CancellationToken cancellationToken)
    {
        if (await _reservationStatusRepository.ExistsByNameAsync(request.Name, cancellationToken: cancellationToken))
        {
            throw new DuplicateEntityException("ReservationStatus with Name '" + request.Name + "' already exists.");
        }
        var entity = new Domain.Entities.ReservationStatus(request.Name);

        await _reservationStatusRepository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
